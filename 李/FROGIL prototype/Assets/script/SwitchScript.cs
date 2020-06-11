using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************************************
// スイッチ押したら起こる処理
//************************************

public class SwitchScript : MonoBehaviour
{

    public string PushTag;
    public GameObject Target;

    public rbodyScript targetrbody;

    public int num;       //1 生成 2 消す 3 落とす 4 押してる間消える

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
            if (collider.gameObject.tag == PushTag)
            {

                Target.SetActive(true);

            }
        }
        if(num == 2)    //消す
        {
            if (collider.gameObject.tag == PushTag)
            {

                Target.SetActive(false);

            }
        }
        if (num == 3)    //落とす
        {
            if (collider.gameObject.tag == PushTag)
            {

                targetrbody.rbody.constraints = RigidbodyConstraints.None;
                targetrbody.rbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            }
        }
        if (num == 4)    //消す
        {
            if (collider.gameObject.tag == PushTag)
            {

                Target.SetActive(false);

            }
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (num == 4)    //生成
        {
            if (other.gameObject.tag == PushTag)
            {

                Target.SetActive(true);

            }
        }
    }
}
