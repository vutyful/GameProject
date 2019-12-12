using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour
{
    public GameObject player;
    Player_Move uihp;
    public Texture2D icon = null;
    int x;
    void OnGUI()
    {


        // Make a background box
        x = uihp.hp;
        GUI.Box(new Rect(10, 10, 40, 40), uihp.hp.ToString());
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
       
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        uihp = player.GetComponent<Player_Move>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
