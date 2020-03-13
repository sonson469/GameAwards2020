using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    //CharacterController characterController;

    //歩行速度
    public float Speed = 0.05f;

    //回転速度
    public float rot = 5f;

    //操作用
    public KeyCode key_up = KeyCode.W;          //前進
    public KeyCode key_right = KeyCode.D;       //右回転
    public KeyCode key_left = KeyCode.A;        //左回転

    // Start is called before the first frame update
    void Start()
    {

       //characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //前進
        if (Input.GetKey(key_up))
        {
            transform.position += transform.forward * Speed;
        }
        //右に向く
        if (Input.GetKey(key_right))
        {
            transform.Rotate(0, rot, 0);
        }
        //左に向く
        if (Input.GetKey(key_left))
        {
            transform.Rotate(0, rot * -1.0f, 0);
        }

    }
}
