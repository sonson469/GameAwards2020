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
    //private float vz = 0;                 // z方向のImputの値
    //private float vx = 0;                 // x方向のImputの値
    public bool stop = false;             //プレイヤー停止
    //float angle = 0;
    Vector3 direction;

    //舌ON
    public bool tongueflag;

    //****************
    // ジャンプ処理
    //****************
    public float jumppower = 6;           // ジャンプ力：Inspectorで指定
	bool pushFlag = false;                // スペースキーを押しっぱなしかどうか
	bool jumpFlag = false;                // ジャンプ状態かどうか
    public bool groundFlag = true;              // 足が何かに触れているかどうか

    //***********
    // キー取得
    //***********
    public string PushKey = "x";

    //*********************
    // 当たり判定対象
    //*********************
    public string Stage;

    //*******************
    // 他スクリプト取得
    //*******************
    public Tongue1 tongue;
    public new MoveCamera camera;

    //********************
    // オブジェクト取得
    //********************
    public GameObject tonguetag;

    //********************
    // コンポーネント用
    //********************
    private Rigidbody rbody;
    private Vector3 PlayerPos;                                    //プレイヤーのポジション
    Animator animator;

    // 初期化----------------------------------------------------------------------------------------------------------------------------
    //*******************************************************
    // 最初に、衝突しても回転させなくしておく（横回転は可)
    //*******************************************************
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        //rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        animator = GetComponentInChildren<Animator>();

        //最初の時点でのプレイヤーのポジションを取得
        PlayerPos = GetComponent<Transform>().position;
    }

    //ずっと行う-------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        //**********
        // 移動
        //**********
        if (stop == false)     //舌出してないとき
        {
            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            direction = cameraForward * Input.GetAxis("Vertical") * speed + Camera.main.transform.right * Input.GetAxis("Horizontal") * speed;

            //vz = Input.GetAxisRaw("Vertical") * speed;
            // vx = Input.GetAxisRaw("Horizontal") * speed;

            //プレイヤーのRigidbodyに対してInputにspeedを掛けた値で更新し移動
            //rbody.velocity = new Vector3(vx, 0, vz);
           

        }
        if (Input.GetButtonDown("Tongue"))
        {

            tongueflag = true;
            stop = true;
            tonguetag.SetActive(true);
        }

        animator.SetBool("Tongue", tongueflag);



        //************
        // ジャンプ
        //************
        // もし、スペースキーが押されたとき、足が何かに触れていたら
        if (Input.GetButton("Jump") && groundFlag)
		{
			if (pushFlag == false) // 押しっぱなしでなければ
			{
				pushFlag = true; // 押した状態に
				jumpFlag = true; // ジャンプの準備
			}
		} else
		{
			pushFlag = false; 	// 押した状態解除
		}
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

        if (stop == false)
        {
            rbody.AddForce(0, -20, 0, ForceMode.Impulse);

            rbody.velocity = new Vector3(direction.x, 0, direction.z);
            //rbody.AddForce(direction.x, 0, direction.z, ForceMode.Impulse);
            //プレイヤーがどの方向に進んでいるかわかるようにする
            Vector3 diff = rbody.velocity - PlayerPos;

            if (diff.magnitude > 0.01f) //0のときは変わらないようにする
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }
            animator.SetFloat("Speed", diff.magnitude);

        }

        //************
        // ジャンプ
        //************
        if (jumpFlag)      // もし,ジャンプするときならジャンプする
         {
        jumpFlag = false;
        rbody.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
         }
    }

    // 足が何かに触れたら-------------------------------------------------------------------------------------------------------------------------
     private void OnCollisionEnter(Collision collision)
     {
         groundFlag = true;
     }
     // 足に何も触れなかったら----------------------------------------------------------------------------------------------------------------------
     //private void OnCollisionExit(Collision collision)
     //{
         //groundFlag = false;
     //}
     

}
