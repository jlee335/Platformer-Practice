﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxXY : MonoBehaviour
{
    /*
    Parallax 효과를 통해 입체감이 있는 배경을 만드는 스크립트
    
    */
    public bool lockY;

    public float layer; // 레이어에 따라 parallax 이동 속도 달라짐
    GameObject background; // 전체 배경 가로 크기를 통해 각 배경들의 움직임 정도를 정함
    float bgWidth; // 가로 크기
    float bgHeight;
    GameObject camera; // 카메라 외부에서 지정

    float camX; // x 축만 이용할 것
    float camY;
    float diffX;
    float diffY;
    void Start(){
        camera = GameObject.Find("Main Camera");
        background = GameObject.Find("MapSizeIndicator");
        bgWidth = background.GetComponent<SpriteRenderer>().bounds.size.x; // bgWidth 구함
        bgHeight = background.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector3 init = new Vector3(camera.transform.position.x,transform.position.y,transform.position.z); // y 축은 변화 없음 
        transform.position = init;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        카메라를 따라가는 배경은, 카메라에게 주어진 거리의 1/n 씩 따라가게 된다. 
        */
        camX = camera.transform.position.x;
        camY = camera.transform.position.y;
        
        // layer 가 높을수록 더더욱 정적인(static) 움직임을 나타낸다. 0 은 아예 안 움직임 (다른 알고리즘도 사용 가능)
        diffY = 2*(background.transform.position.y - transform.position.y)/bgHeight * layer *2;
        diffX = 2*(background.transform.position.x - transform.position.x)/bgWidth * layer *2; // 전체 맵에 대한 플레이어의 이동 거리
        Vector3 dest;
        if (lockY){
            dest = new Vector3(camX + diffX,   transform.position.y   ,transform.position.z);
        }else{
            dest = new Vector3(camX + diffX,   camY + diffY   ,transform.position.z);
        }
        
        transform.position = dest;
    }
}
