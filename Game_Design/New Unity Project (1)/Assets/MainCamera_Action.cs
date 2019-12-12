using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCamera_Action : MonoBehaviour
{
    public int Stage = 0;
    public GameObject scriptbox;
    public Text txt;
    public Text skiptxt;
    public Text nametxt;

    public GameObject player;

    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;

    public GameObject floor;
    public Texture2D icon = null;

    public int mobcount = 5;

    public GameObject goal;
    public GameObject npc;

    Vector3 cameraPosition;

    int playerhp = 0;

    bool IsPause = false; // pause 유무
    int index = 0;
    public bool isDialogue = false;

    /*스테이지1 몬스터 다 잡고*/
    string[] dialogue1 = new string[]
    {
        "??????",
        "어디선가 인기척이 느껴진다.",
        "인기척의 주인을 찾자!"
    };

    /*스테이지1 상인 만나고*/
    string[] dialogue2 = new string[]
    {
        "나를 구해줘서 고마워. 나는 이웃 마을에서 온 상인 펭이라고 해.",
        "우리 주민들을 구해준 내가 더 고맙지 혹시 이 습격에 대해서 뭔가 알고있니?",
        "습격한 이들은 \"마을 깨기 단\"이라고 작은 마을들을 습격하는 몹쓸 놈들이야.\n이들은 아주 끈질겨서 벗어나기가 쉽지 않아.",
        "벗어나려면 어떻게 해야해??",
        "사막 저편에 있는 본거지를 치면 돼.\n하지만, 완벽한 방법은 큰 마을로 성장하는 수 밖에 없어.",
        "만약 도움이 필요하면 말해 우린 돈은 많지만,\n 주민 수가 부족하거든\n주민들이 이주한 만큼 돈을 줄 수 있어.",
        "알았어.. 일단 도움을 준다니 고마워",
        "-펭으로 부터 돈을 받았습니다.\n-상점이 열렸습니다.[펭 상인]\n\"-마을 깨기 단\"을 전부 처치해 큰 마을로 성장해야 안전하단 걸 알았습니다."
    };

    /*스테이지1 네이태그*/
    string[] nameTag = new string[]
    {
        "상인 펭", "용감한 병아리", "상인 펭","용감한 병아리", "상인 펭", "상인 펭", "용감한 병아리", "[SYSTEM]"
    };

    string[] dialogue3 = new string[]
    {
        "\"마을 깨기 단\"을 전부 물리쳤다!!!",
        "우린 이제 안전할 수 있어! 마지막으로 마을을 정비하고 축제를 열자!!",
        "[어디선가 기이한 목소리가 들려온다.]",
        "????",
        "너희들의 마을이 계속 안전할거라고 생각하지 마라....",
        "[목소리가 사라졌다.]",
        "이제 마을로 돌아자가."
    };

    string[] nameTag3 = new string[]
    {
        "병아리", "병아리", "","병아리", "마을 깨기 단", "", "병아리"
    };

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0; 스테이지 시작시 대화창 뜰경우 포즈
    }

    // Update is called once per frame
    void Update()
    {
        playerhp = player.GetComponent<Player_Move>().hp;

        if (Stage == 1)
            Stage_1();
        if(Stage == 4)
        {
            if(mobcount == 0)
            {
                Time.timeScale = 0;

                txt.text = dialogue3[index];
                nametxt.text = nameTag3[index];
                skiptxt.text = "Press Enter Key >>";
                scriptbox.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    index++;
                }
                if (index >= dialogue3.Length)
                {
                    scriptbox.SetActive(false);
                    isDialogue = false;
                    Time.timeScale = 1;

                    SceneManager.LoadScene("Main2");

                    return;
                }
                return;
            }
        }
    }

   
    void Stage_1()
    {
        /*펭귄이랑 플레이어 거리 측정*/
        float cubeDistance = Vector3.Distance(player.transform.position, npc.transform.position);

        //스테이지1
        if (mobcount == 0 && goal.transform.position.x < player.transform.position.x && IsPause == false)
        {
            Debug.Log("goal");
            Time.timeScale = 0;

            txt.text = dialogue1[index];    //대화창
            skiptxt.text = "Press Enter Key >>";    //enter키 누르라는 말
            nametxt.text = "용감한 병아리";   // 네임태그
            scriptbox.SetActive(true);  //UI활성화
            if (Input.GetKeyDown(KeyCode.Return))   //enter
            {
                index++;    //배열 증가
            }
            if (index >= dialogue1.Length)
            {
                scriptbox.SetActive(false); //UI비활성화
                IsPause = true;
                isDialogue = true;
                index = 0;
                Time.timeScale = 1;
                return;
            }
            return;
        }

        //스테이지1
        if (cubeDistance <= 6.0f && isDialogue)
        {
           
            if (index == 0)
            {
                player.transform.position = new Vector3(npc.transform.position.x - 5f, npc.transform.position.y, player.transform.position.z);
            }


            Time.timeScale = 0;

            txt.text = dialogue2[index];
            nametxt.text = nameTag[index];
            skiptxt.text = "Press Enter Key >>";
            scriptbox.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                index++;
            }
            if (index >= dialogue2.Length)
            {
                scriptbox.SetActive(false);
                isDialogue = false;
                Time.timeScale = 1;

                SceneManager.LoadScene("Main2");

                return;
            }
            return;

        }
    }


    /*
     * 현재 캐릭터의 위치 + 좌표값에 카메라 고정
     * 캐릭터를따라 계속 카메라가 따라오며
     * 카메라의 높이는 가장 아래 바닥에 고정함
     * */
    void LateUpdate()
    {
        
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = floor.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;
        
        transform.position = cameraPosition;
    }

    void OnGUI()
    {
        for (int count = 0; count < playerhp; count++) {
            GUI.DrawTexture(new Rect(count*40, Screen.height - 420, 64, 64), icon);
        }
    }
}
