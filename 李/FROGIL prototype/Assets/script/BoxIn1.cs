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

    //自分のスクリプト(油かかる処理とかのやつ)
    public Box MyScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (TargetScript.oilflag)
        {
            MyScript.oilflag = true;
        }

        MyScript.rbody.velocity = TargetScript.rbody.velocity;

    }
}
