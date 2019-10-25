using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_swing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoAttack();
    }
    public float attackSpeed = 300f;
    public bool attacking = false;

    
    void DoAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * attackSpeed);
        }
        if (Input.GetKeyDown(KeyCode.X) && !attacking)
        {
            GetComponent<Rigidbody>().AddForce(Vector2.down * attackSpeed);
        }
    }
}
