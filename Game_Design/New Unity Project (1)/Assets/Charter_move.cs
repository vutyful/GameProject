using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charter_move : MonoBehaviour
{
    private Animator anime;

    public float speed = 10.0f;
    float jumpPower = 7.0f;
    Rigidbody rigdbody;
    Vector3 movement;
    bool isJumping;
    int hp = 6;
    GameObject player;
    private float h;

    void Update()
    {
        h=Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        Debug.Log(player);
        if (hp == 0)
        {
            Destroy(player);
        }
    }


void Awake()
    {
        player = GameObject.Find("Toon Chicken");
        rigdbody = GetComponent<Rigidbody> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rigdbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       
        Run(h);
        Jump();
        Turn();

    }
    void Run(float h)
    {
        movement.Set(h, 0, 0);
        movement = movement.normalized * speed * Time.deltaTime;
     

        rigdbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                rigdbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }

            else
            {
                return;
            }
        }

    }
    // Update is called once per frame
    void Turn()
    {
        if (h == 0)
            return;
        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigdbody.MoveRotation(newRotation);
    }
    void OnCollisionEnter(Collision coll)
    {
       
        if (coll.gameObject.tag == "Enemy")
        {
            Vector3 originPoint = new Vector3();
            Debug.Log("d");
            originPoint.x = rigdbody.transform.position.x-1*Time.deltaTime;
            originPoint.y = rigdbody.transform.position.y+1*Time.deltaTime;
            originPoint.z = rigdbody.transform.position.z;
            hp -= 1;
            Debug.Log(hp);
            rigdbody.transform.position = originPoint;

        }
    }


}
