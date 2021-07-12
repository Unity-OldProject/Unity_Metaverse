using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class CarManager : MonoBehaviour
{
    public GameObject indicator;
    public GameObject myCar;

    ARRaycastManager arManager;
    GameObject placeObject;

    

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(false);

        arManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();

        if (EventSystem.current.currentSelectedGameObject)
        {
            return;
        }

        if(indicator.activeInHierarchy && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if(placeObject == null)
                {
                    placeObject = Instantiate(myCar, indicator.transform.position, indicator.transform.rotation);
                }
                else
                {
                    placeObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);

                }
                
            }
        }
    }

    void DetectGround()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if(arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            indicator.SetActive(true);

            indicator.transform.position = hitInfos[0].pose.position;
            indicator.transform.rotation = hitInfos[0].pose.rotation;

            indicator.transform.position += indicator.transform.up * 0.1f;
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
