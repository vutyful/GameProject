using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public GameObject rat;
    public float hp = 5f;
    public float speed = 3.0f;
    public float monsterspeed = 3.0f;
    public GameObject Target;
    public GameObject mcamer;

    public float mtime = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            Destroy(rat);

            mcamer.GetComponent<MainCamera_Action>().mobcount -= 1;
        }
        mtime -= Time.deltaTime;

        if (System.Math.Abs(this.transform.position.x) - System.Math.Abs(Target.transform.position.x) < 10 && this.transform.position.x - Target.transform.position.x >0)
        {
            //speed = 5.0f;
            transform.rotation = Quaternion.Euler(0, 270, 0);
            Vector3 dir = Target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * monsterspeed * Time.deltaTime;
            mtime = 6f;
        } else if (System.Math.Abs(System.Math.Abs(this.transform.position.x) - System.Math.Abs(Target.transform.position.x)) < 10 &&this.transform.position.x -Target.transform.position.x < 0)
        {
            //speed = 5.0f;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            Vector3 dir = Target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * monsterspeed * Time.deltaTime;
            mtime = 6f;
        }
        else if (mtime < 6f && mtime > 4f)
        {

            speed = 3.0f;
            transform.rotation = Quaternion.Euler(0, 90, 0);

            transform.Translate(Vector3.right * monsterspeed * 1 * Time.deltaTime, Space.World);

        } else if (mtime < 4f && mtime >2f)
        {
            speed = 3.0f;
            transform.rotation = Quaternion.Euler(0, 270, 0);
              transform.Translate(Vector3.left * monsterspeed * 1 * Time.deltaTime, Space.World);
            
        } else if (mtime < 2f)
        {
            mtime = 6f;
        }

    }
}
