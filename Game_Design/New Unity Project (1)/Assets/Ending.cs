using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public int end = 0;
    public GameObject scriptbox;
    public Text txt;
    public Text skiptxt;
    public Text nametxt;

    float time = 0;

    const int GOLD = 500;
    const int PLAYER = 5;

    public int gold;
    public int player;

    int index = 0;

    string[] end1 = new string[]
   {
       "5년이 지난 어느날",
       "이웃 마을과 좋은 관계를 지속하던 어느날 뒷산에 커다란 광산이 발견되어,\n나라에서 제일가는 부자 마을이 되었습니다.",
       "HAPPY ENDING!\n행복한 마을 치킨 빌리지"
   };

    string[] end2 = new string[]
  {
       "3년이 지난 어느날",
       "오랜 흉년으로 마을은 가난에 허덕이게 되었습니다.",
       "좋은 인연을 지속했던 펭 마을은 결국 관계를 끊겨서 도움을 요청할 곳도 없습니다.",
       "빚에 허덕인 마을은 결국 망해 돈이 많던 마을깨기 단에게 팔렸습니다.",
       "NORMAL ENDING\n역시 돈이 최고"
  };

    string[] end3 = new string[]
{
       "2년이 지난 어느날",
       "마을은 노동력이 아주 부족합니다.\n 젊은 병아리들이 전부 다른 마을로 갔기 때문입니다.",
       "결국 마을을 지킬 인력도 없어 \n마을 깨기 단에게 다시 침략 당합니다.",
       "마을은 망했습니다.",
       "BAD ENDING\n부족한 병아리들"
};

    // Start is called before the first frame update
    void Start()
    {
        //엔딩이 안났을 때
        if(end == 0)
        {
            scriptbox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(end == 4)
        {
            Time.timeScale = 0;
            
            txt.text = "이제 정말 우리 마을은 안전할거야!!!";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                scriptbox.SetActive(false);
                SceneManager.LoadScene("Ending");
            }
        }
        if(end == 5)
        {
            if(gold >= GOLD && player >= PLAYER)
            {
                txt.text = end1[index];
            }
            if (player < PLAYER)
            {
                txt.text = end3[index];
            }
            if (gold < GOLD)
            {
                txt.text = end2[index];
            }
            if (Input.GetKeyDown(KeyCode.Return))   //enter
            {
                index++;    //배열 증가
            }
            if (index >= end1.Length)
            {
                index = 0;
                SceneManager.LoadScene("Start");
                return;
            }
        }
    }
}
