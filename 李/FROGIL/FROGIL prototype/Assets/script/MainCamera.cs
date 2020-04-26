using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public float speed = 40;   //速度
    public float radius = 30;  //回転半径

    public GameObject center;  //視点

    private Vector3 pos;

    //キー
    public string PushKeyRight = "j";
    public string PushKeyLeft = "l";
    public string PushKeyUp = "i";
    public string PushKeyDown = "k";

    //カメラ座標取得
    private Vector3 CameraPos;

    // Start is called before the first frame update
    void Start()
    {
        /*pos.x = radius * Mathf.Sin(-speed * Time.time) - 10.0f;
        pos.z = radius * Mathf.Cos(-speed * Time.time) + 12.0f;
        pos.z -= radius * 2;
        pos.y = 8.0f;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        this.gameObject.transform.LookAt(center.transform);*/

        Vector3 axis = transform.TransformDirection(Vector3.down);
        transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
        this.gameObject.transform.LookAt(center.transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(PushKeyRight))
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyLeft))
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyUp))
        {
            Vector3 axis = transform.TransformDirection(Vector3.left);
            transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyDown))
        {
            Vector3 axis = transform.TransformDirection(Vector3.right);
            transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(center.transform);
        }

    }
}
