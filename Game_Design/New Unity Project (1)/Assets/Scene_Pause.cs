using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene_Pause : MonoBehaviour
{
    public int index = 0;
    bool IsPause = false; // pause 유무
    public GameObject player;
    public GameObject Script_Box;
    
  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float cubeDistance = Vector3.Distance(player.transform.position, Script_Box.transform.position);
        if (cubeDistance<=3.0f) //일단 pause 넣기위해 단축키 T를 넣었음 추후 대화문 추가할때 변경바람
        {
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            if(IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }
    }



}
