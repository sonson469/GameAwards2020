using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMove : MonoBehaviour
{

    public string PushTag;
    public GameObject MoveField;  //動くやつ

    //public rbodyScript targetrbody;

    public float speedx = 0f;
    public float speedy = 0f;
    public float speedz = 0f;

    public float Plus;
    public float Minus;

    public bool moveflag = false;
    //public bool plusflag = false;        //プラスの上限にいるか
    //public bool minusflag = false;       //マイナスの上限にいるか


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (moveflag==true)
        {
            MoveField.transform.Translate(-speedx * Time.deltaTime, -speedy * Time.deltaTime, -speedz * Time.deltaTime);
        }
        if ( MoveField.transform.position.x < Minus)
        {
            moveflag = false;
        }
    }

    //**********************
    // 箱と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if ( collider.gameObject.tag == PushTag)
        {
            moveflag = true;
        }
    }
    
}

