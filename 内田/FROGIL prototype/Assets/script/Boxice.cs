using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//*********************************
// 油がかかると動く箱(氷)
//*********************************

public class Boxice : MonoBehaviour
{

    //***********
    // 対象設定
    //***********
    public string OilTag;    //油

    //オブジェクトに油を当ててから表示されるUI
    public GameObject showobject;
    public GameObject showObject2;

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
    public float oillimit = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();

        //showobject = GameObject.Find("ObjectOil_5");
        //showObject2 = GameObject.Find("ObjectOil_5sotowaku");

        if (showobject)
        {
            showobject.SetActive(false);
            showObject2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oilflag == true)
        {
            rbody.constraints = RigidbodyConstraints.None;
            rbody.constraints = RigidbodyConstraints.FreezeRotation;
            showobject.SetActive(true);
            showObject2.SetActive(true);
            this.showobject.GetComponent<Image>().fillAmount -= 0.2f * Time.deltaTime;
        }
        if(this.showobject.GetComponent<Image>().fillAmount <= 0)
        {
            oilflag = false;
        }
            if (oilflag == false)
        {
            rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            showobject.SetActive(false);
            showObject2.SetActive(false);
            this.showobject.GetComponent<Image>().fillAmount = 1.0f;
        }
    }

    //**********************
    // 油と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == OilTag)
        {
           oilflag = true;
        }
    }
}
