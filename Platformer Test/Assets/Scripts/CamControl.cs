using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    private Vector3 playerPos;
    private Vector3 camPos;
    // Update is called once per frame

    /*
        플레이어 위치를 따라가되, 유기적으로 따라가게 하면 보기 좋다.
        정해진 거리에 1/n 만큼 움직이면 자연스러워 보인다.

    */
    void Update()
    {   
        // 더 나은 알고리즘이 있으면 추가 바람
        playerPos = player.transform.position;
        camPos = transform.position; // 포맷은 
        
        Vector3 Line = (playerPos - camPos)/15; 
        Vector3 Final = Line + camPos;
        Final.z = -10f;
        transform.position = Final; 
    }
}
