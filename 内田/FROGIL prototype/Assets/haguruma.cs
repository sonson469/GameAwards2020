using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haguruma : MonoBehaviour
{

    //***********
    // 対象設定
    //***********
    public string OilTag; //油
    public string Tongue;

    //***********
    // フラグ
    //***********

    public bool oilflag = false;          //油がかかったか
    public bool gearflag = false;         //回転
    public Vector3 stageuppos;              //ステージアップの座標を入れる場所


    //********************
    // コンポーネント用
    //********************
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        stageuppos = GameObject.Find("stageup").transform.position;//上下するやつにstageuoの座標を入れる
    }

    // Update is called once per frame
    void Update()
    {
        //transform習得
        Transform myTransform = this.transform;
    }

    //**********************
    // 油と重なったら
    //**********************
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == OilTag)//油と重なったら
        {

            gearflag = true;
            rbody.constraints = RigidbodyConstraints.None;
            rbody.constraints = RigidbodyConstraints.FreezePosition;


            if (gearflag == true && collider.gameObject.tag == Tongue)//trueかつ舌と当たったら
            {
                transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);//毎秒90度回転する
                rbody.constraints = RigidbodyConstraints.None;
                Invoke("stageup", 4);
            }
        }
    }

    void stageup()
    {
        gearflag = false;
        //Vector3 newpos= GameObject.Find("stageup").transform.position;//newposにstageuoの座標を入れる
        //GameObject.Find("stageup").transform.position += Vector3 newpos(0f, 2.0f * Time.deltaTime, 0f);//毎秒Y軸に2増加
        stageuppos = new Vector3 (stageuppos.x, stageuppos.y +Mathf.PingPong(Time.time,2.0f),stageuppos.z);
        //Invoke("up", 2);
    }
    /*
    void up()
    {

        rbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    */
}
