using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public float speed = 40.0f;   //回転速度
    public float radius = 30.0f;  //回転半径

    public float UDspeed = 10.0f;  //上下移動速度
    public float MAspeed = 10.0f;

    public GameObject center;  //視点

    private Vector3 pos;

    //キー
    //回転用
    public string PushKeyRight = "j";
    public string PushKeyLeft = "l";
    public string PushKeyUp = "i";
    public string PushKeyDown = "k";

    //上下移動用
    public string PushKeyPosUp = "u";
    public string PushKeyPosDown = "n";

    //前後移動用
    public string PushKeyPosMae = "o";
    public string PushKeyPosAto = "m";

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
        Vector3 position = transform.position;
        Vector3 centerpos = center.transform.position;

        //*************
        // 回転処理
        //*************
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

        //************
        // 上下移動
        //************
        if (Input.GetKey(PushKeyPosUp))
        {
            position.y += UDspeed * Time.deltaTime;
            transform.position = position;
            centerpos.y += UDspeed * Time.deltaTime;
            center.transform.position = centerpos;
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyPosDown))
        {
            position.y -= UDspeed * Time.deltaTime;
            transform.position = position;
            centerpos.y -= UDspeed * Time.deltaTime;
            center.transform.position = centerpos;
            this.gameObject.transform.LookAt(center.transform);
        }

        //***************
        // 前後移動
        //***************
        if (Input.GetKey(PushKeyPosMae))
        {
            Vector3 movepos = new Vector3(0, 0, MAspeed);
            movepos = this.transform.rotation * movepos;
            position += movepos * Time.deltaTime;
            transform.position = position;
            this.gameObject.transform.LookAt(center.transform);
        }
        if (Input.GetKey(PushKeyPosAto))
        {
            Vector3 movepos = new Vector3(0, 0, MAspeed);
            movepos = this.transform.rotation * movepos;
            position -= movepos * Time.deltaTime;
            transform.position = position;
            this.gameObject.transform.LookAt(center.transform);
        }
    }
}
