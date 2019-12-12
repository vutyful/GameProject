using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptActivate : MonoBehaviour
{
    public int stage = 0;
    public GameObject scriptbox;
    public Text txt;
    public Text nametxt;

    public GameObject npc;
    public GameObject player;

    bool isDialogue = true;
    int index = 0;
    float time;

    string[] dialogue2 = new string[]
    {
        "너기 \"마을 깨기 단\"의 수장이구나!!",
        "너를 없애 마을을 안전하게 만들거다!!!!"
    };


    string[] nameTag = new string[]
    {
        "상인 펭", "용감한 병아리", "상인 펭","용감한 병아리", "상인 펭", "상인 펭", "용감한 병아리", "[SYSTEM]"
    };

    // Start is called before the first frame update
    void Start()
    {
        scriptbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*펭귄이랑 플레이어 거리 측정*/
        float cubeDistance = Vector3.Distance(player.transform.position, npc.transform.position);

        if (stage == 2)
        {
            if (cubeDistance <= 6.0f && isDialogue)
            {
                time += UnityEngine.Time.deltaTime;

                txt.text = "전입신고는 언제든지 환영해!!";
                nametxt.text = "보초 펭귄";
                scriptbox.SetActive(true);

                if (time > 1)
                {
                    isDialogue = false;
                    scriptbox.SetActive(false);
                }

            }
        }Debug.Log(cubeDistance);
        if(stage == 4){
            if (cubeDistance <= 32.0f && isDialogue)
            {
                Time.timeScale = 0;

                txt.text = dialogue2[index];
                nametxt.text = "병아리";
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

                    return;
                }
                return;

            }
        }
       
        
    }
}
