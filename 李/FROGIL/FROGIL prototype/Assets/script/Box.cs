using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//********************************
// 油がかかると動くようになる箱
//********************************

public class Box : MonoBehaviour
{
    //***********
    // 対象設定
    //***********
    public string OilTag;    //油

    //***********
    // フラグ
    //***********
    public bool oil;          //油がかかった


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
        
    }

    //**********************
    // 油と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == OilTag)
        {

            rbody.constraints = RigidbodyConstraints.None;
            rbody.constraints = RigidbodyConstraints.FreezePositionY;
            rbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

}
