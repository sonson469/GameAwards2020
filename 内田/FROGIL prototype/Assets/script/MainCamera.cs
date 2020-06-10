using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//****************************************************************
// メインカメラの回転、移動
//****************************************************************

public class MainCamera : MonoBehaviour
{

    public float speed = 40.0f;   //回転速度
    public float radius = 30.0f;  //回転半径

    public float UDspeed = 10.0f;  //上下移動速度
    public float MAspeed = 10.0f;

    public float MoveZpos = 10.0f;  //視点切り替えの移動距離

    public float MoveCameraSpeed = 3.0f; //プレイヤーに追従するときの速度
    
    public bool FieldFlag;
    public bool PlayerFlag;
    private bool PushFlag = false;

    public float distance;
    public float distancefield;

    public GameObject centerfield;  //視点
    public GameObject centerplayer;

    private Vector3 pos;

    public OnKeyPress_MoveRotateGravity PlayerScript;
    private Rigidbody rbody;

    //カメラ座標取得
    private Vector3 CameraPos;

    Vector3 movepos;
    Vector3 moveposfield;

    // Start is called before the first frame update
    void Start()
    {
        /*pos.x = radius * Mathf.Sin(-speed * Time.time) - 10.0f;
        pos.z = radius * Mathf.Cos(-speed * Time.time) + 12.0f;
        pos.z -= radius * 2;
        pos.y = 8.0f;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
        this.gameObject.transform.LookAt(center.transform);*/

        /*Vector3 axis = transform.TransformDirection(Vector3.down);
        transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
        this.gameObject.transform.LookAt(center.transform);*/
        
        FieldFlag = true;
        PlayerFlag = false;

        CameraPos = transform.position;

        rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 centerfieldpos = centerfield.transform.position;
        Vector3 centerplayerpos = centerplayer.transform.position;

        if (Input.GetButtonDown("CameraChange") && FieldFlag && !PushFlag)
        {
            PushFlag = true;
            FieldFlag = false;
            this.gameObject.transform.LookAt(centerplayer.transform);

            movepos = centerplayer.transform.position - transform.position;
            transform.position += transform.forward * (movepos.magnitude - distance);
           //transform.position += transform.forward * MoveZpos;
            PlayerFlag = true;
        }
        if (Input.GetButtonDown("CameraChange") && PlayerFlag && !PushFlag)
        {
            PushFlag = true;
            PlayerFlag = false;
            transform.position = CameraPos;
            this.gameObject.transform.LookAt(centerfield.transform);
            /*moveposfield = centerfield.transform.position - transform.position;
            this.gameObject.transform.LookAt(centerfield.transform);
            transform.position -= transform.forward * (moveposfield.magnitude - distancefield);
            Debug.Log(transform.forward);*/
            FieldFlag = true;
        }

        //*********************************
        // ステージ全体のとき
        //*********************************

        if(FieldFlag)
        {
            if (PushFlag)
            {
                PushFlag = false;
            }
            // 左右回転
            Vector3 axis = transform.TransformDirection(Vector3.up) * -Input.GetAxisRaw("Horizontal2");
            axis = transform.TransformDirection(Vector3.down) * -Input.GetAxisRaw("Horizontal2");
            transform.RotateAround(centerfield.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(centerfield.transform);

            //上下移動

            if (Input.GetAxisRaw("Vertical2") > 0.1)
            {
                Vector3 move = new Vector3(0, UDspeed, 0);
                move = this.transform.rotation * move;  // これでこのオブジェクトから見たX,Y,Zにできるよ(たぶん)

                position += move * Time.deltaTime;
                transform.position = position;                                      // カメラの座標を変える
                centerfieldpos += move * Time.deltaTime;
                centerfield.transform.position = centerfieldpos;
                this.gameObject.transform.LookAt(centerfield.transform);                 //視点を見る
            }
            if (Input.GetAxisRaw("Vertical2") < -0.1)
            {
                Vector3 move = new Vector3(0, UDspeed, 0);
                move = this.transform.rotation * move;  // これでこのオブジェクトから見たX,Y,Zにできるよ(たぶん)

                position += -move * Time.deltaTime;
                transform.position = position;                                      // カメラの座標を変える
                centerfieldpos += -move * Time.deltaTime;
                centerfield.transform.position = centerfieldpos;
                this.gameObject.transform.LookAt(centerfield.transform);                 //視点を見る
            }
        }

        //*********************
        // プレイヤー視点
        //*********************
        if (PlayerFlag)
        {

            if (PushFlag)
            {
                PushFlag = false;
            }

            /*if (PlayerScript.rbody.velocity.magnitude > 1.0f)
            {
                transform.position += centerplayer.transform.forward * MoveCameraSpeed * Time.deltaTime;
            }*/
            if (PlayerScript.rbody.velocity.y < -4.0f)
            {
                rbody.velocity = new Vector3(PlayerScript.rbody.velocity.x, 0, PlayerScript.rbody.velocity.z);
            }
            if(PlayerScript.rbody.velocity.y > -4.0f)
            {
                rbody.velocity = PlayerScript.rbody.velocity;
            }

            // 左右回転
            Vector3 axis = transform.TransformDirection(Vector3.up) * -Input.GetAxisRaw("Horizontal2");
            axis = transform.TransformDirection(Vector3.down) * -Input.GetAxisRaw("Horizontal2");
            transform.RotateAround(centerplayer.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(centerplayer.transform);
            // 上下回転
            axis = transform.TransformDirection(Vector3.left) * -Input.GetAxisRaw("Vertical2");
            axis = transform.TransformDirection(Vector3.right) * -Input.GetAxisRaw("Vertical2");
            transform.RotateAround(centerplayer.transform.position, axis, speed * Time.deltaTime);
            this.gameObject.transform.LookAt(centerplayer.transform);
        }

    }
}
