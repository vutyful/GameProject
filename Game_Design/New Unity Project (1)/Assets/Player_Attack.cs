using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    RaycastHit hit; //적에대한 공격판정유무
    float MaxDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue  , 0.3f);
            if(Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance) && hit.collider.gameObject.tag == "Enemy")
            {
                if(this.transform.position.x < hit.transform.position.x) { 
                hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 4.0f, ForceMode.Impulse);
                hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * -4.0f, ForceMode.Impulse);
                } else
                {
                    hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 4.0f, ForceMode.Impulse);
                    hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * 4.0f, ForceMode.Impulse);
                }
                Enemy_Move enemy = hit.transform.gameObject.GetComponent<Enemy_Move>();
                enemy.hp -= 1;
            }
        }
    }
}
