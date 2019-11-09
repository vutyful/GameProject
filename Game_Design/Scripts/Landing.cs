using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //충돌한 물체 판정
    {
        //Debug.Log("touch");
        if (other.transform.tag == "Ground") //충돌한 물체가 Ground인지 판별
        {
            //Debug.Log("Landing");
            body.GetComponent<Player_Move>().isJumping = false; //플레이어의 isJumping을 초기화
        }
    }
}
