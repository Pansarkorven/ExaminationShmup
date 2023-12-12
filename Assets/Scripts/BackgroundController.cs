using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollspeed = 2.0f; // �ndrar hastigheten p� bakrunden
    public float resetTime = 5.0f; // �ndrar n�r bakrunden restetar och g�r tillbaka till start position

    private float timer;



    // Update is called once per frame
    void Update()
    {
       //g�r s� att bakrunden r�r sig
        transform.Translate(Vector3.left * scrollspeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            transform.position = new Vector3 (17, transform.position.y, transform.position.z);
            timer = 0f;
        }
    }
}
