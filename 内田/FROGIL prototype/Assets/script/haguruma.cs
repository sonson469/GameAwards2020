using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haguruma : MonoBehaviour
{

    //***********
    // 対象設定
    //***********
    public string OilTag; //油
    public string Tongue;  //舌
    public GameObject MoveField;  //動くやつ

    //*********
    // 変数
    //*********
    //移動方向指定と速度
    public float speedx = 0f;
    public float speedy = 0f;
    public float speedz = 0f;
    //上限
    public float Plus;
    public float Minus;

    //***********
    // フラグ
    //***********
    public bool oilflag = false;          //油がかかったか
    public bool gearflag = false;         //回転
    public bool tongueflag = false;       //舌
    public bool plusflag = false;        //プラスの上限にいるか
    public bool minusflag = false;       //マイナスの上限にいるか

    //********************
    // コンポーネント用
    //********************
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform習得
        //Transform myTransform = this.transform;
        if (oilflag && tongueflag)
        {
            gearflag = true;
        }
        if (gearflag)
        {
            if (plusflag)
            {
                transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);//毎秒90度回転する
                MoveField.transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, speedz * Time.deltaTime);
            }
            if (minusflag)
            {
                transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);//毎秒90度回転する
                MoveField.transform.Translate(-speedx * Time.deltaTime, -speedy * Time.deltaTime, -speedz * Time.deltaTime);
            }
        }

        if (speedy > 0)
        {
            if (plusflag && MoveField.transform.position.y > Plus)
            {
                plusflag = false;
                gearflag = false;
                tongueflag = false;
                minusflag = true;
            }
            if (minusflag && MoveField.transform.position.y < Minus)
            {
                minusflag = false;
                gearflag = false;
                tongueflag = false;
                plusflag = true;
            }
        }
        if (speedx > 0)
        {
            if (plusflag && MoveField.transform.position.x > Plus)
            {
                plusflag = false;
                gearflag = false;
                tongueflag = false;
                minusflag = true;
            }
            if (minusflag && MoveField.transform.position.x < Minus)
            {
                minusflag = false;
                gearflag = false;
                tongueflag = false;
                plusflag = true;
            }
        }
        if (speedz > 0)
        {
            if (plusflag && MoveField.transform.position.z > Plus)
            {
                plusflag = false;
                gearflag = false;
                tongueflag = false;
                minusflag = true;
            }
            if (minusflag && MoveField.transform.position.z < Minus)
            {
                minusflag = false;
                gearflag = false;
                tongueflag = false;
                plusflag = true;
            }
        }

    }

    //**********************
    // 重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == OilTag)//油と重なったら
        {
            oilflag = true;
        }
        if (collider.gameObject.tag == Tongue)//舌と重なったら
        {
            if (oilflag) //油がONの時だけ
            {
                tongueflag = true;
            }
        }
    }
}