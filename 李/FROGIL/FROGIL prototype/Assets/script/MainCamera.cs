using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public float speed;   //速度
    public float radius;  //半径

    public GameObject center;  //視点

    float posx;
    float posz;

    //キー
    public string PushKeyRight;
    public string PushKeyLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(PushKeyRight))
        {
            posx = radius * Mathf.Sin(Time.time * speed);
            posz = radius * Mathf.Cos(Time.time * speed);

            this.gameObject.transform.position = new Vector3(posx, 0, posz);
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyLeft))
        {
            posx = radius * Mathf.Sin(Time.time * -speed);
            posz = radius * Mathf.Cos(Time.time * -speed);

            this.gameObject.transform.position = new Vector3(posx, 0, posz);
            this.gameObject.transform.LookAt(center.transform);
        }

    }
}
