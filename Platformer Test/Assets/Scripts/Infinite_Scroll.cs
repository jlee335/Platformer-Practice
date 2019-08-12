using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite_Scroll : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    public Material mat; // 임시방편, renderer.material.SetTextureOffset 등이 작동을 안함
    Renderer renderer;
    void Start()
    {
        //renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2 (speed,0f);
        mat.mainTextureOffset += offset;
        // renderer.material.mainTextureOffset += offset;
        //Debug.Log(mat.mainTextureOffset);
    }
}
