using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//************************************
// 移動、ジャンプ、舌出してる間止まる
//************************************

public class OnKeyPress_MoveRotateGravity : MonoBehaviour
{
    //***********
    // 移動用
    //***********
    public float speed = 3f;              // スピード：Inspectorで指定
	//public float rotateSpeed = 360f;    // 回転スピード：Inspectorで指定
    private float vz = 0;                 // z方向のImputの値
    private float vx = 0;                 // x方向のImputの値
    public bool stop = false;             //プレイヤー停止
    //float angle = 0;

    //****************
    // ジャンプ処理
    //****************
    //public float jumppower = 6;           // ジャンプ力：Inspectorで指定
    public float jumping = 6;           // ジャンプ力：Inspectorで指定
	//bool pushFlag = false;                // スペースキーを押しっぱなしかどうか
	//bool jumpFlag = false;                // ジャンプ状態かどうか
	//bool groundFlag = false;              // 足が何かに触れているかどうか
    private bool groundFlag = true;//  地面に着地しているか判定する変数

    //***********
    // キー取得
    //***********
    public string PushKeyTongue = "x";
    public string PushKeyJump = "c";

    //*******************
    // 他スクリプト取得
    //*******************
    public Tongue1 tongue;

    //********************
    // オブジェクト取得
    //********************
    public GameObject tonguetag;
    public string Slope;

    //********************
    // コンポーネント用
    //********************
	private Rigidbody rbody;
    private Vector3 PlayerPos;                                    //プレイヤーのポジション

    // 初期化----------------------------------------------------------------------------------------------------------------------------
    //*******************************************************
    // 最初に、衝突しても回転させなくしておく（横回転は可)
    //*******************************************************
    void Start ()
	{
		rbody = this.GetComponent<Rigidbody>();

        //最初の時点でのプレイヤーのポジションを取得
        PlayerPos = GetComponent<Transform>().position;
    }

    //ずっと行う-------------------------------------------------------------------------------------------------------------------------
	void Update ()
	{
        //**********
        // 移動
        //**********
        if (stop == false)     //舌出してないとき
        {

            //angle = Input.GetAxisRaw("Horizontal") * rotateSpeed;
            vz = Input.GetAxisRaw("Vertical") * speed;
            vx = Input.GetAxisRaw("Horizontal") * speed;
            //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動
            rbody.velocity = new Vector3(vx, 0, vz);

            // 力を設定
            //Vector3 force = new Vector3(vx, 0, vz);
            // 力を加える
            //rbody.AddForce(force);

            //プレイヤーがどの方向に進んでいるかわかるようにする
            Vector3 diff = rbody.velocity - PlayerPos;

            if (diff.magnitude > 0.01f) //0のときは変わらないようにする
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }

        }
        if(Input.GetKeyDown(PushKeyTongue))
        {
            stop = true;
            tonguetag.SetActive(true);
        }

        if (groundFlag == true)//  もし、GroundFlagがtrueなら、
        {
            if (Input.GetKeyDown(PushKeyJump))//  もし、スペースキーがおされたなら、  
            {
                
                rbody.AddForce(Vector3.up * jumping);  // ジャンプ力をかける
                groundFlag = false;  // 地面から離れる
            }
        }

        //************
        // ジャンプ
        //************
        // もし、スペースキーが押されたとき、足が何かに触れていたら
        /*if (Input.GetKey("space") && groundFlag)
		{
			if (pushFlag == false) // 押しっぱなしでなければ
			{
				pushFlag = true; // 押した状態に
				jumpFlag = true; // ジャンプの準備
			}
		}
        else
		{
			pushFlag = false; 	// 押した状態解除
		}*/

        //***********
        // 坂
        //***********




    }

    // ずっと-------------------------------------------------------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        //**********
        // 移動
        //**********
        /*if (vz !=0) // 移動する
		{
			this.transform.Translate(0, 0,  vz / 50);
		}
        if (vx != 0) // 移動する
        {
            this.transform.Translate(vx / 50, 0, 0);
        }*/
        /*if (angle != 0) // 回転する
		{
			this.transform.Rotate(0, angle / 50, 0);
		}*/

        //************
        // ジャンプ
        //************
		/*if (jumpFlag)      // もし,ジャンプするときならジャンプする
        {
			jumpFlag = false;
			rbody.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
		}*/
	}

    // 足が何かに触れたら-------------------------------------------------------------------------------------------------------------------------
    /*private void OnTriggerStay(Collider collision)
	{
		groundFlag = true;
	}
    // 足に何も触れなかったら----------------------------------------------------------------------------------------------------------------------
    private void OnTriggerExit(Collider collision)
	{
		groundFlag = false;
	}*/

    void OnCollisionEnter(Collision collision)//  地面に触れた時の処理
    {
        if (collision.gameObject.tag == "Stage")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            groundFlag = true;//  Groundedをtrueにする

        }

        
    }

}
