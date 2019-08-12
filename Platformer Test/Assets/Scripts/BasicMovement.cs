using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
     public float runSpeed = 1f;
     public float jumpStrength = 10f;
     public float fallGravity = 0.1f;

     private bool flying = false;
    
    //public float zoomSize = 12;
    // Update is called once per frame
    Rigidbody2D rb;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>(); //rb값 초기화
        rb.freezeRotation = true; // 물체가 회전하는 것을 막음
    }
    void OnCollisionEnter2D(Collision2D hit){
        // 바닥이랑 충돌 (착지)
        if(hit.gameObject.tag == "Floor"){
            flying = false; // flying변수 전환으로 jump 가능
        }
        //기타등등 (아이템 줍기, 적 공격 받기. 등등등등...)

    }
    void Update()
    {
        // movement using keyboard
        Vector3 pos = transform.position;
        
        if (Input.GetKey("w")){ // JUMP
            // 땅에 닿지 않으면 jump 못하게 한다
            if(flying == false){
                rb.AddForce(new Vector2 (0f,jumpStrength), ForceMode2D.Impulse); // 객체에 FORCE 전달로 점프 구현
                flying = true; // 날고 있으므로 jump 제한
            }
        }
        if(flying == true && rb.velocity.y < 0 ){ // 떨어지고 있을 때 가속을 더 붙게 한다
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallGravity;
        }
        if (Input.GetKey("s")){ // DUCK
           
        }
        if (Input.GetKey("d")){ //앞으로 움직임
            //RIGHT
            pos.x += runSpeed;
        }
        if (Input.GetKey("a")){ //뒤로 움직임
            //LEFT
            pos.x -= runSpeed;
        }
    

        transform.position = pos; // transform.position 은 객체의 위치 변환. pos + - 한 것을 객체로 전달
    }
}
