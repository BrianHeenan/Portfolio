using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 25;
    public GameObject meleeWeapon;
    public GameObject rangeWeapon;
    PlayerHealth playerHealth;
    float timer;
    float prevSpeed = 1;
    public bool isAttacking = false;
    public bool isCharging = false;
    UIController UI;
    [Tooltip("Place healthParticle from under PlayerCharacter_BaseRig here.")]
    public ParticleSystem healthParticle;
    [Tooltip("GameObject to shoot")]
    public GameObject projectile;
    [Tooltip("GameObject where projectile will spawn")]
    public GameObject projectileSpawnPoint;
    [Tooltip("Speed of projectile")]
    public float projectileSpeed = 15f;
    [Tooltip("How fast the accuracy shrinks.")]
    public float accuracyShrinkSpeed = 2;
    float tempAccuracy;
    [Tooltip("How far the view distance is.")]
    public float viewRadius = 5;
    [Range(0, 360)] [Tooltip("How accuate the shot it.")]
    public float accuracyAngle = 60;
    
    public LayerMask obstacleMask;

    public float meshResolution = 1;
    public int edgeResolveIterations = 4;
    public float edgeDstThreshold = 0.5f;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    
    public bool isReticleActive = false;
    
    // Global cooldown
    public bool isGlobalCoolDown = false;
    public float GlobalCurrent;
    public float GlobalMax;
    HitBox hitBox;
    void Awake()
    {
        // Setting up my references.
        playerHealth = GetComponent<PlayerHealth>();
        hitBox = FindObjectOfType<HitBox>();
    }

    void Start()
    {
        UI = FindObjectOfType<UIController>();

        tempAccuracy = accuracyAngle;
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks)
        {
            isAttacking = false;
            isCharging = false;
            
            timer = 0f;
        }

        if (isGlobalCoolDown)
        {
            GlobalCurrent += Time.deltaTime;
            if (GlobalCurrent >= GlobalMax)
            {
                isGlobalCoolDown = false;
                GlobalCurrent = 0;
            }
        }

        #region Melee Controls
        if (meleeWeapon.activeInHierarchy)
        {
            timeBetweenAttacks = .75f;

            GetComponent<Animator>().SetBool("isSword1", isAttacking);

            if (Input.GetMouseButtonDown(0) && UI.stealControl == false)
            {
                if (playerHealth.currentHealth > 0 && !isAttacking)
                {
                    isAttacking = true; // says player is attacking
                    hitBox.ChanageStatus(0);
                    meleeWeapon.GetComponent<AudioSource>().Play();
                }
            }
        }
        #endregion

        #region Ranged Controls
        else if (rangeWeapon.activeInHierarchy)
        {
            timeBetweenAttacks = 0.75f;

            if (Input.GetMouseButton(0) && UI.stealControl == false) // holding left mouse button
            {
                if (playerHealth.currentHealth > 0 && !isReticleActive && !isAttacking)
                {
                    isCharging = true;
                }
            }
            if (isCharging)
            {
                RaiseAccuracy();
                GetComponent<Animator>().SetBool("isCharging", true);
            }
            else
            {
                ContinueAnimation();
            }

            if (Input.GetMouseButtonUp(0) && UI.stealControl == false) // releasing left mouse button
            {
                if (playerHealth.currentHealth > 0 && !isReticleActive && isCharging)
                {
                    ContinueAnimation();
                    isCharging = false;
                    BowSkills BS = FindObjectOfType<BowSkills>();
                    if (BS.playerAnimator.GetBool("isRainingDown") == false)
                    {
                        Shoot();
                    }
                    else
                    {
                        viewMesh.Clear();
                    }
                    rangeWeapon.GetComponent<AudioSource>().Play();
                    GetComponent<Animator>().SetBool("isCharging", false);
                }
            }

            if (Input.GetMouseButtonDown(0) && UI.stealControl == false && isReticleActive) // clicking left mouse button
            {
                BowSkills BS = FindObjectOfType<BowSkills>();
                if (BS.target.activeInHierarchy == true)
                {
                    RangedSlot4Placeholder Rslot4 = FindObjectOfType<RangedSlot4Placeholder>();
                    Rslot4.GetComponentInChildren<SKill>().VolleyActivate();
                    BS.playerAnimator.SetBool("isRainingDown", true);
                    BS.target.SetActive(false);
                    isReticleActive = false;
                }
            }
        }
        #endregion

        #region Skill Controls
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isAttacking)
        {
            Slot1Placeholder slot1 = FindObjectOfType<Slot1Placeholder>();
            slot1.GetComponentInChildren<SKill>().ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !isAttacking)
        {
            Slot2Placeholder slot2 = FindObjectOfType<Slot2Placeholder>();
            slot2.GetComponentInChildren<SKill>().ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !isAttacking)
        {
            Slot3Placeholder slot3 = FindObjectOfType<Slot3Placeholder>();
            slot3.GetComponentInChildren<SKill>().ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !isAttacking)
        {
            RangedSlot4Placeholder rSlot4 = FindObjectOfType<RangedSlot4Placeholder>();
            Slot4Placeholder slot4 = FindObjectOfType<Slot4Placeholder>();
            if (meleeWeapon.activeInHierarchy)
            {
                slot4.GetComponentInChildren<SKill>().ActivateSkill();
            }

            else if (rangeWeapon.activeInHierarchy)
            {
                rSlot4.GetComponentInChildren<SKill>().ReticleCall();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject slotQ = FindObjectOfType<SlotQPlaceholder>().gameObject;
            SKill currentSkill = slotQ.GetComponentInChildren<SKill>();

            if (currentSkill.onCooldown == false)
            {
                if (playerHealth.currentHealth >= 0 || playerHealth.currentHealth < playerHealth.healthMax)
                {
                    playerHealth.currentHealth += 15;
                    healthParticle.Play();
                    currentSkill.onCooldown = true;
                }
                else
                {
                    return;
                }
            }
        }
        #endregion
    }

    public void TurnOnHitBox()
    {
        hitBox.Activate();
    }

    public void TurnOffHitBox()
    {
        hitBox.Deactive();
    }

    public void PauseAnimation()
    {
        var animator = GetComponent<Animator>();
        prevSpeed = animator.speed;
        animator.speed = 0;
    }

    public void ContinueAnimation()
    {
        var animator = GetComponent<Animator>();
        animator.speed = prevSpeed;
    }

    void RaiseAccuracy()
    {
        isAttacking = true;
        // reduces the spread of the bow
        if(accuracyAngle >= 5)
        {
            accuracyAngle -= accuracyAngle * (accuracyShrinkSpeed * Time.deltaTime);
        }
        Mathf.Clamp(accuracyAngle, 5, tempAccuracy); // clamps the accuracy
        DrawFieldOfView(); // creates the bow fov cone
    }

    public void Shoot()
    {
        viewMesh.Clear(); // clears the bow fov cone

        float angle = Random.Range(-accuracyAngle, accuracyAngle); // gets a random number for accuracy angle

        GameObject clone = Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation); // spawns a clone of the arrow

        clone.transform.rotation = transform.rotation; 
        clone.transform.Rotate(0, angle, 0); // sets the clone's rotation to the direction it will go

        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * projectileSpeed, ForceMode.VelocityChange); // adds force to the arrow

        accuracyAngle = tempAccuracy; // resets the accuracy for the next shot
    }

    #region BowFOVCone

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(accuracyAngle * meshResolution);
        float stepAngleSize = accuracyAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - accuracyAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i > 0)
            {
                bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
                if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }
            }
            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();

        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
    {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
            if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
        {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }

    public struct EdgeInfo
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
    #endregion
}
