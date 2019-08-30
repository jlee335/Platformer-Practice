﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    /*
    하나의 스크립트에 여러 카메라 모드를 지원할 것임
    1. 플레이어를 단순히 따라가는 스크립트
    2. Focal Point 에 중점으로 반응하는 스크립트
    */
    public enum CameraMode : int{
        FollowCam,
        FocalCam,
        TransitionCam,
    };

    public GameObject player;
    // Start is called before the first frame update
    private Vector3 playerPos;

    private Vector3 camPos;
    public float offsetX;
    public float offsetY;
    public CameraMode cameraMode;


    // Variables for FocalCam
    private Vector3 focusPos;

    /*
        플레이어 위치를 따라가되, 유기적으로 따라가게 하면 보기 좋다.
        정해진 거리에 1/n 만큼 움직이면 자연스러워 보인다.
    */

    void Update()
    {   
        // 더 나은 알고리즘이 있으면 추가 바람
        // NOTE: If cameraMode should change, give focusPos reference FIRST.

        if(cameraMode == CameraMode.FollowCam){
            playerPos = player.transform.position;
            camPos = transform.position; // 포맷은 
            Vector3 Line = (playerPos - camPos)/15; 
            Vector3 Final = Line + camPos + new Vector3(offsetX,offsetY,0f);;
            Final.z = -10f;
            transform.position = Final; 
            

        }else if(cameraMode == CameraMode.FocalCam){
            playerPos = player.transform.position;
            // focusPos 는 이미 주어져 있어야 함! 
            // focusPos 와 playerPos 사이의 Vector 를 만들고, focusPos 로부터 시작 1/10 거리로 카메라를 이동시키자

            camPos = transform.position; // 포맷은 
            Vector3 Line = (focusPos - playerPos)/10; 
            Vector3 Final = Line + focusPos;;
            Final.z = -10f;
            transform.position = Final; 


            
        }else{ // by default let this be TransitionCam

        }

    }
}
