using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*스테이지1 대화 박스 사라지게 만듦*/

public class RemoveText : MonoBehaviour
{
    public GameObject scriptbox;
    public Text txt;
    public float time;
    public bool isDialogue = true;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue)
        {
            time += UnityEngine.Time.deltaTime;
            if (time > 4)
            {
                Debug.Log("게임 설명");
                txt.text = "move: ←→\nJump: SpaceBar\nAttack: ctrl\nAccelerate: Shift";
                if(time > 10)
                {
                    Debug.Log("대화창 비활성화");
                    isDialogue = false;
                    scriptbox.SetActive(false);
                }
            }
        }
    }
}
