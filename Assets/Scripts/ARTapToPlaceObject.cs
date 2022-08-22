using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTapToPlaceObject : MonoBehaviour
{       
    public GameObject greenCard;
    public GameObject yellowCard;
    public GameObject redCard;

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
        //Java pluginine eriþilmesi
        WifiPlugin.InitializeUnityPlugin("com.example.wifiplugin.WifiPlugin");

    }


    void Update()
    {
        UpdatePlacementPose();
        
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Objeye bastýrýlacak deðerlerin çaðýrýlmasý
            WifiPlugin.WifiStrength();
            WifiPlugin.WifiSpeed();
            //Obje yerleþtirmenin çaðýrýlmasý
            PlaceObject();
        }

    }

    //Obje yerleþtirme
    private void PlaceObject() 
    {
        // To Place object current camera position
        // position.x and position.y comes from camera
        // position.y comes from placementPose

        if (WifiPlugin.dBmResult >= -50)
        {
            Instantiate(greenCard, new Vector3(Camera.main.transform.position.x, placementPose.position.y, Camera.main.transform.position.z), placementPose.rotation);
        }
        else if (WifiPlugin.dBmResult < -50 && WifiPlugin.dBmResult > -70)
        {
            Instantiate(yellowCard, new Vector3(Camera.main.transform.position.x, placementPose.position.y, Camera.main.transform.position.z), placementPose.rotation);
        }
        else if (WifiPlugin.dBmResult <= -70)
        {
            Instantiate(redCard, new Vector3(Camera.main.transform.position.x, placementPose.position.y, Camera.main.transform.position.z), placementPose.rotation);
        }

        
    }
                                    

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {   
            placementPose = hits[0].pose;
           
        }

    }
}
