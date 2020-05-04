using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPointer : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;
    [SerializeField] private Sprite markerSprite;

    public float borderSize = 200f;

    //public GameObject objectiveObject;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private Image pointerImage;

    private QuestManager questManager;

    private void Awake()
    {
        //targetPosition = objectiveObject.transform.position;
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>(); // find pointer rect transform
        pointerImage = transform.Find("Pointer").GetComponent<Image>(); // find pointer image
    }

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        targetPosition = questManager.objectiveTarget.transform.position;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        
        // check if target is out of border area
        bool isOffScreen =
            targetPositionScreenPoint.x <= borderSize ||
            targetPositionScreenPoint.x >= Screen.width - borderSize ||
            targetPositionScreenPoint.y <= borderSize ||
            targetPositionScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            pointerImage.sprite = arrowSprite; // change sprite to arrow

            RotatePointerTowardsTargetPosition();

            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            
            // stops pointer from going outside of border area
            if (cappedTargetScreenPosition.x <= 0) cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x >= Screen.width) cappedTargetScreenPosition.x = Screen.width - borderSize;
            if (cappedTargetScreenPosition.y <= 0) cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y >= Screen.height) cappedTargetScreenPosition.y = Screen.height - borderSize;

            // cap pointer to got go out of border area
            cappedTargetScreenPosition.x = Mathf.Clamp(cappedTargetScreenPosition.x, borderSize, Screen.width - borderSize);
            cappedTargetScreenPosition.y = Mathf.Clamp(cappedTargetScreenPosition.y, borderSize, Screen.height - borderSize);

            pointerRectTransform.position = cappedTargetScreenPosition; // set position
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f); // reset z position
        }
        else // if on screen
        {
            pointerImage.sprite = markerSprite; // change sprite to marker

            pointerRectTransform.position = targetPositionScreenPoint; // set pointer to target locatoin
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f); // reset z position
            pointerRectTransform.localEulerAngles = Vector3.zero; // reset rotation
        }
    }

    private void RotatePointerTowardsTargetPosition()
    {
        Vector3 toPosition = Camera.main.WorldToScreenPoint(targetPosition);
        Vector3 fromPosition = pointerRectTransform.position;
        Vector3 dir = (toPosition - fromPosition).normalized; // get direction to target
        
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; // returns negative angle

        pointerRectTransform.localEulerAngles = new Vector3(0, 0, -angle); // rotate towards angle
    }
}
