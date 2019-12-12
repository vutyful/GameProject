using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Move : MonoBehaviour
{
    /*
     * 설정해주어야 할 것.
     * 1.PlayerObject에 RigidBody의 Freeze Rotation x, y, z 설정과 Rigidbody 생성 및 해당 스크립트연동
     * 2.Inspector에서 public으로 지정된 jump와 jumpSpeed (둘다 5정도로 주면 충분)
     * 3.바닥 Quad의 Tag = Ground 생성 및 지정 해줄 것, Physic Material 생성 및 정지, 운동 마찰력 설정 (각 0.2정도)
     *   Friction Combine은 minimum지정해 줄 것
     * 4.Player 캐릭터의 하단 중앙부분에 작게 튀어나온 Object를 하나생성하고 
     *   해당 Object에 Landing 스크립트를 연결 및 body로 PlayerObject를 지정해 줄 것
     * 5.해당 Object는 IsTrigger를 체크해 줄 것
     * 6.Edit > ProjectSettings > Input > Horizontal의 Gravity와 Sensitivity 각 2로 지정해 줄 것.  
     */
    public bool isJumping;
    public float jump = 8;
    public float jumpSpeed = 5;
    public int hp = 5;
    public GameObject weapon;
    public GameObject mcamera;

    public float cooltime = 0f;
    float delay;
    float hitdel = 3f;
    float speed;
    float hor;
    float ver;
    Animator animator;
    bool hold = true;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5 * Time.deltaTime; //프레임당 이동속도

        if (hold)
        {


            hor = Input.GetAxis("Horizontal"); //키보드입력값 좌우
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
                mcamera.GetComponent<MainCamera_Action>().offsetX = -4;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                mcamera.GetComponent<MainCamera_Action>().offsetX = 4;

            }
        }


        //foot 판정이 true일때, 키를 입력시 이동, 입력 시간에 따른 부하를 줌
        if (!isJumping)
        {
            transform.Translate(Vector3.right * hor * speed, Space.World); //물체가 회전하면 방향이 바뀌기 때문에 월드좌표를 기준으로 이동하도록함.

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                GetComponent<Rigidbody>().AddForce(new Vector3(hor * jumpSpeed, jump, 0), ForceMode.Impulse);
            }
        }


        if (hp < 1 || this.transform.position.y <= -3.0f)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooltime <= 0)
        {
            cooltime = 10;
            hold = false;
            if (transform.eulerAngles.y > 40 && transform.eulerAngles.y < 100)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.right * 15.0f, ForceMode.Impulse);
                weapon.transform.rotation = Quaternion.Euler(0, 180, 100);
            }
            else if (transform.eulerAngles.y > 200)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.left * 15.0f, ForceMode.Impulse);
                weapon.transform.rotation = Quaternion.Euler(0, 180, -100);
            }

            if (cooltime < 9.0f)
                weapon.transform.rotation = Quaternion.Euler(0, 180, 0);
            hold = true;
        }
        cooltime -= Time.deltaTime;
        hitdel -= Time.deltaTime;
        delay += Time.deltaTime;
        if (hitdel < 1.4)
        {
            animator.SetInteger("animation", 3);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))//attack
        {
            delay = 0;

            if (transform.eulerAngles.y > 40 && transform.eulerAngles.y < 100)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 180, 100);
            }
            else if (transform.eulerAngles.y > 200)
            {
                weapon.transform.rotation = Quaternion.Euler(0, 180, -100);
            }
        }
        if (delay > 0.3)
            weapon.transform.rotation = Quaternion.Euler(0, 180, 0);
        
    }
     


    /*
     *적에게 부딛혔을때 넉백 및 땅에 있지않을때 점프 불가설정 
     * hitdel이 0이하가 되지않으면 피격판정 x
     * 맞고난후 hitdel을 2로 변경후 Time.deltaTime으로 값을 빼주어 딜레이 설정.
     * 
     * */




    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isJumping = false;
            
        }
        if (coll.gameObject.tag == "Enemy" && hitdel <= 0) 
        {

            animator.SetInteger("animation", 4);
            if (this.transform.position.x - coll.transform.position.x < 0)
            {
                GetComponent< Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(Vector3.left * 3.0f, ForceMode.Impulse);
            }
            else if (this.transform.position.x - coll.transform.position.x >= 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(Vector3.left * -3.0f, ForceMode.Impulse);
            }
            hitdel = 2;
            hp -= 1;
        }
        if (coll.gameObject.tag == "Niddle" && hitdel <= 0)
        {
            if (this.transform.position.x - coll.transform.position.x < 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(Vector3.left * 3.0f, ForceMode.Impulse);
            }
            else if (this.transform.position.x - coll.transform.position.x >= 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 3.0f, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(Vector3.left * -3.0f, ForceMode.Impulse);
            }
            hitdel = 1;
            hp -= 1;

        }

    }
  
}