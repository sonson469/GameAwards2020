using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//********************************
// 油がかかると動くようになる箱(ノーマル)
//********************************

public class Box : MonoBehaviour
{
    //***********
    // 対象設定
    //***********
    public string  OilTag;    //油

   //オブジェクトに油を当ててから表示されるUI
    public GameObject showobject;
    public GameObject showObject2;
    //通常状態
    public GameObject DefTag;
    //油状態
    public GameObject AburaTag;

    //***********
    // フラグ
    //***********
    public bool oilflag = false;          //油がかかった
    public bool interlock = false;         //連動状態


    //********************
    // コンポーネント用
    //********************
    public Rigidbody rbody;

    //パラメーターのイメージ
    public Image targetimage;

    //*******************
    // その他変数
    //*******************
    public float oillimit = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rbody = this.GetComponent<Rigidbody>();
        targetimage = this.showobject.GetComponent<Image>();

        //showobject = GameObject.Find("ObjectOil_10");

        //showObject2 = GameObject.Find("ObjectOil_10sotowaku");
        if (showobject)
        {
            showobject.SetActive(false);
            showobject.SetActive(false);

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (oilflag == true)
        {
            rbody.constraints = RigidbodyConstraints.None;
            rbody.constraints = RigidbodyConstraints.FreezeRotation;

            AburaTag.SetActive(true);
            DefTag.SetActive(false);
            
            showobject.SetActive(true);
            showObject2.SetActive(true);


            targetimage.fillAmount -= 0.1f * Time.deltaTime;
        
        }
        if(targetimage.fillAmount <= 0)
        {

            oilflag = false;
        }

        if(oilflag == false)
        {
            interlock = false;

            rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            AburaTag.SetActive(false);
            DefTag.SetActive(true);

            showobject.SetActive(false);
            showObject2.SetActive(false);

          
            targetimage.fillAmount = 1.0f;
        }
        
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
                oilflag = true;
            }
          
        }
    }

}
