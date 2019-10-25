using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;
    public GameObject floor;
    Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = floor.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
    }

}
