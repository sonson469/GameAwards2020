using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************************************
// スイッチ押したら起こる処理
//************************************

public class SwitchScript : MonoBehaviour
{

    public string BoxTag;
    public GameObject Create;

    public int num;       //1 生成 2 消す

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //**********************
    // 箱と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (num == 1)   //作る
        {
            if (collider.gameObject.tag == BoxTag)
            {

                Create.SetActive(true);

            }
        }
        if(num == 2)    //消す
        {
            if (collider.gameObject.tag == BoxTag)
            {

                Create.SetActive(false);

            }
        }
    }
}
