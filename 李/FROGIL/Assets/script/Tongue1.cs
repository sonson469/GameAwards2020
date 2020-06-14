using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue1 : MonoBehaviour
{

    // ターゲットオブジェクトのTransformを格納する変数
    public Transform target;

    //下移動中
    private float plus;
    public float minus;
    private float stoptime;
    //舌が出て若干止まる
    private bool stop = false;
    //変動幅
    public float movemax;
    //舌が出る速度
    public float speed;

    //キー
    public string PushKey;

    //格納用
    Vector3 position;

    //押してる状態か
    // private bool pushflag = false;

    //舌を出してるか
    public bool action;

    public float limit;

    //*******************
    // 他スクリプト取得
    //*******************
    public OnKeyPress_MoveRotateGravity player;

    // Start is called before the first frame update
    void Start()
    {
        plus = 0f;
        minus = 0f;
        stoptime = 0f;

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // オブジェクトの座標を格納
        position = transform.position;

        // 舌を出してない
        if (action == false)
        {
            // ターゲットの座標を入れる
            position.x = target.position.x;
            position.z = target.position.z;
            // positionの値をオブジェクト座標に格納
            transform.position = position;
        }
        // 舌を出してる
        else
        {
            //舌前進
            if (player.tongueflagMae)
            {
                plus += speed * Time.deltaTime;
                this.transform.position += this.gameObject.transform.forward * speed * Time.deltaTime;
                if (plus >= 1.8f)
                {
                    player.tongueflagMae = false;
                    stop = true;
                }
            }
            if (stop)
            {
                stoptime += Time.deltaTime;
                if (stoptime >= 0.7f)
                {
                    stop = false;
                    player.tongueflagUsiro = true;
                }
            }
            if (player.tongueflagUsiro)
            {
                minus += speed * Time.deltaTime;
                this.transform.position -= this.gameObject.transform.forward * speed * Time.deltaTime;
                if (minus >= 1.8f)
                {
                    action = false;
                    plus = 0f;
                    minus = 0f;
                    stoptime = 0f;
                    this.gameObject.SetActive(false);
                    player.tongueflagUsiro = false;
                    player.stop = false;
                }
            }

            //舌前進
            /*if (plusz <= movemax)
            {
                plusz += speed * Time.deltaTime;
                Vector3 move = new Vector3(0, 0, plusz);

                move = this.transform.rotation * move;
                position += move * Time.deltaTime;
                transform.position = position;
            }
            //舌後退
            else
            {
                minusz += speed * Time.deltaTime;
                Vector3 move = new Vector3(0, 0, minusz);

                move = this.transform.rotation * move;
                position -= move * Time.deltaTime;
                transform.position = position;

                //舌をしまう
                if (minusz >= movemax)
                {
                    plusz = 0;
                    minusz = 0;
                    action = false;
                    player.stop = false;
                    this.gameObject.SetActive(false);
                    player.tongueflag = false;
                }
            }*/

        }

        //舌を出す
        if (player.stop == true)
        {
            if (action == false)
            {
                //座標を整える
                Vector3 pos = new Vector3(0, 0, 0.87f);
                pos = this.transform.rotation * pos;
                position += pos;
                // positionの値をオブジェクト座標に格納
                transform.position = position;

                Invoke("Action", limit);

            }
        }
    }

    //****************
    // 舌出しON
    //****************
    void Action()
    {
        action = true;
        player.tongueflagMae = true;
    }
}
