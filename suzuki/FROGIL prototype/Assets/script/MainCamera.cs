﻿using System.Collections;
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

    public GameObject center;  //視点

    private Vector3 pos;

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

        // 左右回転
        /*Vector3 axis = transform.TransformDirection(Vector3.left)* Input.GetAxisRaw("Vertical2");
        axis = transform.TransformDirection(Vector3.right) * Input.GetAxisRaw("Vertical2");
        transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
        this.gameObject.transform.LookAt(center.transform);*/

        // 上下回転
        Vector3 axis = transform.TransformDirection(Vector3.up) * -Input.GetAxisRaw("Horizontal2");
        axis = transform.TransformDirection(Vector3.down) * -Input.GetAxisRaw("Horizontal2");
        transform.RotateAround(center.transform.position, axis, speed * Time.deltaTime);
        this.gameObject.transform.LookAt(center.transform);

        //*************
        // 移動処理
        //*************
        //if (Input.GetButton("CameraChange"))
        //{

        if(Input.GetAxisRaw("Vertical2") > 0.1)
        {
            Vector3 move = new Vector3(0, UDspeed, 0);
            move = this.transform.rotation * move;  // これでこのオブジェクトから見たX,Y,Zにできるよ(たぶん)

            position += move * Time.deltaTime;
            transform.position = position;                                      // カメラの座標を変える
            centerpos += move * Time.deltaTime;
            center.transform.position = centerpos;
            this.gameObject.transform.LookAt(center.transform);                 //視点を見る
        }
        if (Input.GetAxisRaw("Vertical2") < -0.1)
        {
            Vector3 move = new Vector3(0, UDspeed, 0);
            move = this.transform.rotation * move;  // これでこのオブジェクトから見たX,Y,Zにできるよ(たぶん)

            position += -move * Time.deltaTime;
            transform.position = position;                                      // カメラの座標を変える
            centerpos += -move * Time.deltaTime;
            center.transform.position = centerpos;
            this.gameObject.transform.LookAt(center.transform);                 //視点を見る
        }

        // 左右移動
        /* Vector3 move2 = new Vector3(UDspeed, 0, 0);
         move2 = this.transform.rotation * move2;

         position += move2 * Time.deltaTime * Input.GetAxisRaw("Vertical2");
         transform.position = position;
         centerpos += move2 * Time.deltaTime * Input.GetAxisRaw("Vertical2");
         center.transform.position = centerpos;

         this.gameObject.transform.LookAt(center.transform);   */       //上下とほぼ同じ

        // }

        //***************
        // 前後移動
        //***************
        /*Vector3 movepos = new Vector3(0, 0, MAspeed);
        movepos = this.transform.rotation * movepos;
        position += movepos * Time.deltaTime * Input.GetAxis("CameraUp");
        transform.position = position;
        this.gameObject.transform.LookAt(center.transform);*/
    }
}
