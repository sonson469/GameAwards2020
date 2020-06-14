using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//***********************************************************
// 連動する箱
//***********************************************************

public class BoxIn1 : MonoBehaviour
{

    //ターゲットのスクリプトとオブジェクト
    public Box TargetScript;
    public GameObject TargetBox;

    //プレイヤータグ
    public string PlayerTag;
    //プレイヤーフラグ
    public bool playerflag = false;

    //自分のスクリプト(油かかる処理とかのやつ)
    public Box MyScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (TargetScript.oilflag && TargetScript.interlock == false)
        {
            MyScript.oilflag = true;
        }

        if (playerflag == false)
        {
            MyScript.rbody.velocity = TargetScript.rbody.velocity;
        }

        if (MyScript.oilflag)
        {
            TargetScript.interlock = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == PlayerTag)
        {
            playerflag = true;
        }

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == PlayerTag)
        {
            playerflag = false;
        }
    }
}
