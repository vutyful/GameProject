using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash_destory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().duration + 1f);
        }
    }
}
