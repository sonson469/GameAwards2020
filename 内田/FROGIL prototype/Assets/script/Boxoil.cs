using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxoil : MonoBehaviour
{

    //***********
    // 対象設定
    //***********
    public string OilTag;    //油

    //***********
    // フラグ
    //***********
    public bool oilflag = false;          //油がかかった

    //********************
    // コンポーネント用
    //********************
    private Rigidbody rbody;

    //*********************
    // その他変数
    //*********************
    public float oillimit = 10.0f;

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
            if (oilflag == false)
            {
                rbody.constraints = RigidbodyConstraints.None;
                rbody.constraints = RigidbodyConstraints.FreezeRotation;
                oilflag = true;
                Invoke("oiloff", oillimit);
            }
        }
    }

    void oiloff()
    {
        oilflag = false;
        rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}
