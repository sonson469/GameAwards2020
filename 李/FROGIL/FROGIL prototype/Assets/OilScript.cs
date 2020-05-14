using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*****************************************************
// 油本体の処理
//*****************************************************

public class OilScript : MonoBehaviour
{
    //************
    // 変数など
    //************
    public float limitsec;  //消えるまでの時間
    public string tagname;  //地面タグ

    //********************
    // コンポーネント用
    //********************
    private Rigidbody rbody;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        Destroy(this.gameObject, limitsec);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            animator.SetBool("Ground", true);
            rbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
