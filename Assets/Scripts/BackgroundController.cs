using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollspeed = 2.0f; // ändrar hastigheten på bakrunden
    public float resetTime = 5.0f; // ändrar när bakrunden restetar och går tillbaka till start position

    private float timer;



    // Update is called once per frame
    void Update()
    {
       //gör så att bakrunden rör sig
        transform.Translate(Vector3.left * scrollspeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            transform.position = new Vector3 (17, transform.position.y, transform.position.z);
            timer = 0f;
        }
    }
}
