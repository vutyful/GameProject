using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//넣어줄것.

/*
 * 각종 장비 추가하고 장비에 지정해야 할 것 지정할것.
 * 텍스트박스 총 네 개 필요 각 소지금, 장비이름, 장비가격, 장비의 공격력
 * PlayerPrefs 사용하여 소지금 저장, 버튼 클릭 마지막에 소지금 저장할 것 + 소지금 로드할 것.
 * 물건 구매시 물건 소지상태 PlayerPrefs 수정할 것
 * 각종 장비 추가시 마다 PlayerPrefs 이름 공유 및 기록해둘것
 * UI사용하되 장비는 오브젝트 그대로 사용, 상점 배경, 디자인 확인하여 텍스트박스 및 소지금 배치할것 
 */

public class shopping : MonoBehaviour
{
    private RaycastHit hit;
    private bool selected;
    public Text gold; // 소지금
    public Text itemName; // 장비 이름
    public Text itemPrice; // 장비 가격
    public Text itemDamage; // 장비 공격력
 
    // Start is called before the first frame update
    void Start()
    {
        //상점 로드시에 지정해 줄 내용들, 선택된 장비가 없기 때문에 초기값 지정해 줌
        selected = false;
        gold.GetComponent<Text>().text = "1000";
        itemName.GetComponent<Text>().text = "-";
        itemPrice.GetComponent<Text>().text = "0";
        itemDamage.GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//마우스 왼쪽버튼이 눌렸을때
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Ray생성
            Debug.DrawRay(ray.origin, ray.direction * 10000, Color.red, 1, false);//화면상 Ray의 방향 확인

            if (Physics.Raycast(ray, out hit))//Ray와 충돌한 객체가 있을 경우
            {
                Debug.Log("touch");
                if (hit.transform.tag.Equals("item"))//객체의 태그가 item과 일치할 경우
                {
                    selected = true;
                    item itemScripts = hit.transform.GetComponent<item>(); //item의 경우 해당 오브젝트의 스크립트 명을 뜻함.

                    itemName.GetComponent<Text>().text = itemScripts.name;
                    itemPrice.GetComponent<Text>().text = itemScripts.price.ToString();
                    itemDamage.GetComponent<Text>().text = itemScripts.damage.ToString();
                    /*미구현 아마 선택시 셰이더 외각선 값 조정해 줄 생각.
                    if (null != itemScripts)//해당 스크립트가 존재할 경우
                        itemScripts.itemClick();//해당 스크립트 내 itemClick() 함수를 호출함.
                    */
                }
            }
            else
            {
                /*
                itemName.GetComponent<Text>().text = "-";
                itemPrice.GetComponent<Text>().text = "0";
                itemDamage.GetComponent<Text>().text = "0";
                */
                Debug.Log("empty");
            }
        }
    }

    public void BuyItem() //버튼 작동이기 때문에 public
    {
        //구매시 메시지 + 구매 실패시 메세지 출력해 줄것.
        int money = int.Parse(gold.GetComponent<Text>().text);
        money = money - int.Parse(itemPrice.GetComponent<Text>().text);
        if (selected && money>=0)//물건이 이미 선택이 되었을때만 작동
        {
            gold.GetComponent<Text>().text = money.ToString();
            itemName.GetComponent<Text>().text = "-";
            itemPrice.GetComponent<Text>().text = "0";
            itemDamage.GetComponent<Text>().text = "0";
            selected = false; //선택된 물건을 구매했기 때문에 선택상태 해제.
        }
    }
}
