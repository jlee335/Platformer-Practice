using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CameraMode : int{
    FollowCam,
    FocalCam,
    TransitionCam,
};
public class CamAreaTrigger : MonoBehaviour
{

    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other){
        // Change Camera focus point
        mainCamera.GetComponent<CamControl>().focusPos = transform.position;
        // Change Main Camera Mode
        mainCamera.GetComponent<CamControl>().cameraMode = CamControl.CameraMode.FocalCam;
    }
    void OnTriggerExit2D(Collider2D other){
            mainCamera.GetComponent<CamControl>().cameraMode = CamControl.CameraMode.FollowCam;
    }
}
