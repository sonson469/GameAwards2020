using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIn : MonoBehaviour
{
    public bool Switchflag = false;

    //ターゲットのスクリプトとオブジェクト
    public SwitchIn TargetScript;
    public GameObject TargetSwitch;

    //自分のスクリプト(油かかる処理とかのやつ)
    public SwitchIn MyScript;

    public string PushTag;
    public GameObject Target;

    //public rbodyScript targetrbody;

   // public int num;       //1 生成 2 消す 3 落とす 4 押してる間消える

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TargetScript.Switchflag && MyScript.Switchflag)
        {
            Target.SetActive(false);
        }

    }

    //**********************
    // 箱と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == PushTag)
        {
            Switchflag = true;
        }
    }


}