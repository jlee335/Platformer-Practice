using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    /*
    Parallax 효과를 통해 입체감이 있는 배경을 만드는 스크립트
    
    */
    public float layer; // 레이어에 따라 parallax 이동 속도 달라짐
    public GameObject background; // 전체 배경 가로 크기를 통해 각 배경들의 움직임 정도를 정함
    float bgWidth; // 가로 크기
    public GameObject camera; // 카메라 외부에서 지정

    float camX; // x 축만 이용할 것
    float diffX;
    void Start(){
        bgWidth = background.GetComponent<SpriteRenderer>().bounds.size.x; // bgWidth 구함
        transform.position = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        카메라를 따라가는 배경은, 카메라에게 주어진 거리의 1/n 씩 따라가게 된다. 
        */
        camX = camera.transform.position.x;
        diffX = 2*(background.transform.position.x - transform.position.x)/bgWidth * layer *2; // 전체 맵에 대한 플레이어의 이동 거리
        Vector2 dest = new Vector2(camX + diffX,camera.transform.position.y);
        transform.position = dest;
    }
}
