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
    public string OilTag;    //油
    public string switchTag;
    public GameObject Slope1;

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

    //*******************
    // その他変数
    //*******************
    public float oillimit = 10.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rbody = this.GetComponent<Rigidbody>();

        //showobject = GameObject.Find("ObjectOil_10");

        //showObject2 = GameObject.Find("ObjectOil_10sotowaku");
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
            this.showobject.GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime;
        }
        if(oilflag == false)
        {
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

            rbody.constraints = RigidbodyConstraints.None;
            rbody.constraints = RigidbodyConstraints.FreezeRotation;
            oilflag = true;
            Invoke("oiloff", oillimit);

            showobject.SetActive(true);
            showObject2.SetActive(true);
            //Invoke("Update", 10);
            


        }
        

        if (collider.gameObject.tag == switchTag)
        {
            Slope1.SetActive(true);
        }


    }

    void oiloff()
    {
        oilflag = false;
        rbody.constraints = RigidbodyConstraints.FreezeAll;
    }

}
