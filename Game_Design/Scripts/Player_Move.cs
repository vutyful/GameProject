using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float jump;
    public float jumpSpeed;
    float speed;
    float hor;
    float ver;


    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5 * Time.deltaTime; //프레임당 이동속도
        hor = Input.GetAxis("Horizontal"); //키보드입력값 좌우
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
    }
}
