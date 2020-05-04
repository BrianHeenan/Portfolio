/*
 * Name: Hunter Duncan
 * Date: 10/16/18
 * Credit: Shawn Kendall, FSGDN
 * Purpose: AI state machine
 */
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEditor;

public class NavAgentStateMachine_Best : FSGDN.StateMachine.MachineBehaviour
{
    [SerializeField]
    NavPoint[] myNavPoints = new NavPoint[0];
    int navIndex = 0;
   
    [SerializeField]
    public GameObject AlarmPoint = null;
    [HideInInspector]
    public GameObject Player = null;
    public float detectionRadius = 15f;
    public float attackRange = 5f;
    [HideInInspector]
    public Vector3 dis;
    float dir;
    [Tooltip("Set active for enemy to randomly move")]
    public bool randomMove = false;
    public float roamRadius = 20f;
    Vector3 startPosition;
    [HideInInspector]
    public Vector3 finalPosition;
    [HideInInspector]
    public EnemyHealth myHealth;
    [HideInInspector]
    public bool inRange;
    [HideInInspector]
    public bool beenToAlarm = false;
    [HideInInspector]
    public bool runAway = false;

    public override void AddStates()
    {
        AddState<PatrolState_Best>();
        AddState<IdleState_Best>();
        AddState<PauseState>();
        AddState<AlarmState>();
        AddState<PursueState>();
        AddState<RandomMoveState>();
        AddState<RunAwayState>();

        SetInitialState<PatrolState_Best>();
    }

    #region Move Functions

    [HideInInspector]
    public bool bSwitch = false;

    public void pickNextNavPoint() // if true read nav point array backwards, else read nav point array forward
    {
        if (bSwitch)
        {
            --navIndex;
            if (navIndex < 0)
                navIndex = myNavPoints.Length - 1;
            SetMainColor(Color.blue);
        }
        else
        {
            ++navIndex;
            if (navIndex >= myNavPoints.Length)
                navIndex = 0;
            SetMainColor(Color.green);
        }
    }

    public void FindDestination() // Go to nav point
    {
        GetComponent<NavMeshAgent>().SetDestination(myNavPoints[navIndex].transform.position);
    }

    public void GoToAlarm() // Go to alarm point
    {
        GetComponent<NavMeshAgent>().SetDestination(AlarmPoint.transform.position);
    }

    public void GoToPlayer() // Go to player
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
    }

    public void RunAway() // Move away from player
    {
        Vector3 safeSpot = transform.position + dis;
        GetComponent<NavMeshAgent>().SetDestination(safeSpot);
    }

    public void GoToRandom() // Go to random point
    {
        Vector3 randomDirection = Random.onUnitSphere * roamRadius;
        randomDirection += startPosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        finalPosition = hit.position;
        finalPosition.y = transform.position.y;
        GetComponent<NavMeshAgent>().SetDestination(finalPosition);
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NavPoint>())
            ChangeState<IdleState_Best>();
        else if (other.gameObject.GetComponent<AlarmPoint>())
            ChangeState<PatrolState_Best>();
    }

    #region Debug helper functions

    // Helper function for setting the object color
    public void SetMainColor(Color color)
    {
        //GetComponent<Renderer>().material.color = color;
    }
    
    bool bPaused = false;
    FSGDN.StateMachine.State lastState = null;

    // Helper function for pausing agent
    public void Pause()
    {
        // toggle paused value
        bPaused = !bPaused;

        if (bPaused)
        {
            // store current state for use when unpausing
            lastState = currentState;

            // change state to Pause
            ChangeState<PauseState>();
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            // restore stored state when pausing earlier
            ChangeState(lastState.GetType());
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    // Helper function for changing which direction agent reads array of nav points
    public void Switch()
    {
        bSwitch = !bSwitch;
        pickNextNavPoint();
        FindDestination();
    }

    [HideInInspector]
    public bool bAngry = false;

    // Helper function for setting agent to alarm state and back to patrol state
    public void Alarm()
    {
        bAngry = !bAngry;
        
        if (bAngry)
        {
            ChangeState<AlarmState>();
        }
        else
        {
            ChangeState<PatrolState_Best>();
        }
    }

    // Helper function for selecting which agent in scene is the active agent
    public void SetHighlight(bool highlightOn)
    {
        if (highlightOn)
        {
            //Highlight.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            //Highlight.GetComponent<Renderer>().material.color = Color.grey;
        }
    }
    #endregion

    public void Distance() // Distance to player
    {
        dis = transform.position - Player.transform.position;
    }

    public void Dot() // Direction to player
    {
        dir = Vector3.Dot(transform.position, Player.transform.position);
    }

    public override void Start()
    {
        base.Start();
        startPosition = transform.position;
        myHealth = GetComponent<EnemyHealth>();
        Player = FindObjectOfType<PlayerHealth>().gameObject;
    }

    public override void Update()
    {
        // since this overrides the state machine’s Update()
        // it is very important to call parent class’ Update()
        // because that is where the state machine does it’s work for us
        base.Update();
        Distance();
        Dot();

        if (myHealth.currentHealth <= (myHealth.maxHealth * 0.1f) || runAway)
        {
            ChangeState<RunAwayState>();
        }
        else if (myHealth.currentHealth <= (myHealth.maxHealth * 0.3f) && AlarmPoint != null)
        {
            ChangeState<AlarmState>();
        }
        else if (!IsCurrentState<PursueState>())
        {
            if (dis.magnitude <= detectionRadius)
            {
                if (dir >= .75f)
                {
                    ChangeState<PursueState>();
                }
            }
        }
    }
}

#region AI States

// New base class for NavAgent states that gives us some utility
// functions to help clean things up even more
public class NavAgentState : FSGDN.StateMachine.State
{
    // Nice accessor for getting our state machine script reference
    protected NavAgentStateMachine_Best NavAgentStateMachine()
    {
        return ((NavAgentStateMachine_Best)machine);
    }
}

// Sets Guard to a patroling state
public class PatrolState_Best : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        if (NavAgentStateMachine().bSwitch)
            NavAgentStateMachine().SetMainColor(Color.blue);
        else
            NavAgentStateMachine().SetMainColor(Color.green);
        if (NavAgentStateMachine().randomMove)
            machine.ChangeState<RandomMoveState>();
        else
            NavAgentStateMachine().FindDestination();
    }
}

// Sets Guard to an idle state
public class IdleState_Best : NavAgentState
{
    float timer = 0;

    public override void Enter()
    {
        base.Enter();
        timer = 0;
        NavAgentStateMachine().SetMainColor(new Color(0.0f, 0.5f, 0.0f));
    }

    public override void Execute()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            machine.ChangeState<PatrolState_Best>();
            NavAgentStateMachine().pickNextNavPoint();
        }
    }
}

// Sets Guard to a paused state
public class PauseState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().SetMainColor(Color.grey);
    }
}

// Sets Guard to an alarmed state
public class AlarmState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().SetMainColor(Color.red);
        NavAgentStateMachine().inRange = false;
        NavAgentStateMachine().GoToAlarm();
    }

    public override void Execute()
    {
        if (NavAgentStateMachine().beenToAlarm)
        {
            machine.ChangeState<PatrolState_Best>();
        }
        else if (NavAgentStateMachine().myHealth.currentHealth >= 
            (NavAgentStateMachine().myHealth.maxHealth * 0.61f))
        {
            machine.ChangeState<PatrolState_Best>();
        }
        else if(NavAgentStateMachine().transform.position.magnitude <= NavAgentStateMachine().AlarmPoint.transform.position.magnitude * 2f)
        {
            NavAgentStateMachine().beenToAlarm = true;
            machine.ChangeState<PatrolState_Best>();
        }
    }
}

// Sets Guard to pursue state
public class PursueState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().SetMainColor(Color.magenta);
        NavAgentStateMachine().GoToPlayer();
    }

    public override void Execute()
    {
        Vector3 lookAtPlayer = NavAgentStateMachine().Player.transform.position;
        lookAtPlayer.y = NavAgentStateMachine().transform.position.y;
        NavAgentStateMachine().transform.LookAt(lookAtPlayer);
        NavAgentStateMachine().GoToPlayer();

        if(NavAgentStateMachine().dis.magnitude <= NavAgentStateMachine().attackRange)
        {
            NavAgentStateMachine().inRange = true;
        }
        else
        {
            NavAgentStateMachine().inRange = false;
        }

        if (NavAgentStateMachine().dis.magnitude >= NavAgentStateMachine().detectionRadius)
        {
            NavAgentStateMachine().inRange = false;
            machine.ChangeState<PatrolState_Best>();
        }
    }
}

// Sets Guard to move in a random circle
public class RandomMoveState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().GoToRandom();
    }

    public override void Execute()
    {
        float distanceToPoint = Vector3.Distance(NavAgentStateMachine().transform.position, NavAgentStateMachine().finalPosition);
        if (NavAgentStateMachine().transform.position.magnitude >= distanceToPoint)
        {
            NavAgentStateMachine().GoToRandom();
        }
    }
}

// Sets Guard to run away
public class RunAwayState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().inRange = false;
        NavAgentStateMachine().RunAway();
    }

    public override void Execute()
    {
        if(NavAgentStateMachine().dis.magnitude >= NavAgentStateMachine().detectionRadius)
        {
            machine.ChangeState<PatrolState_Best>();
        }
    }
}
#endregion
