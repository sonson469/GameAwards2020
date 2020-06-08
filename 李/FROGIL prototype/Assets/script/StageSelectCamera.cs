using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//********************************
// カメラが動いてステージを選ぶ
//********************************

public class StageSelectCamera : MonoBehaviour
{

    public float Speed;
    private bool Right;
    private bool Left;
    private bool Push;
    public int num;
    private float Posx;

    public GameObject TargetL;
    public GameObject TargetR;
    public GameObject TargetL2;
    public GameObject TargetR2;

    // Start is called before the first frame update
    void Start()
    {
        num = 1;
        Push = false;
        Right = false;
        Left = false;
        Speed = 40.0f;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetAxis("Horizontal") == 1 && Push == false)
        {
            Push = true;
            num++;
            transform.Translate(20f, 0, 0);
        }
        if (Input.GetAxis("Horizontal") == -1 && Push == false && transform.position.x >= 20)
        {
            Push = true;
            num--;
            transform.Translate(-20f, 0, 0);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Push = false;
        }*/

        if(num == 1)
        {
            TargetL2.SetActive(true);
        }
        if (num >= 2)
        {
            TargetL2.SetActive(false);
        }

        if (Input.GetButtonDown("Oil"))
        {
            if (num == 1)
            {
                SceneManager.LoadScene("Stage1");
            }
            if (num == 2)
            {
                SceneManager.LoadScene("Stage2");
            }
            if (num == 3)
            {
                SceneManager.LoadScene("Stage3");
            }
            if (num == 4)
            {
                SceneManager.LoadScene("Stage4");
            }
            if (num == 5)
            {
                SceneManager.LoadScene("Stage5");
            }
        }

        /*if (transform.position.x == 0f)
        {
            if (Input.GetAxis("Horizontal") == 1)
            {
                transform.position = new Vector3(20f, 0f, transform.position.z);
                num = 2;
            }
            if (Input.GetAxis("Horizontal") == -1)
            {
            }
            if (Input.GetButtonDown("Oil"))
            {
                SceneManager.LoadScene("Stage1");
            }
        }*/




        
        if(Input.GetAxis("Horizontal") == 1 && Right == false)
        {
            Right = true;
            num++;
        } 
        if (Right)
        {

            transform.Translate(Speed * Time.deltaTime, 0, 0);

            if (this.transform.position.x >= num * 10f + (num - 2) * 10f)
            {
                Right = false;
               // Posx = this.transform.position.x;
            }
        }

        if(Input.GetAxis("Horizontal") == -1 && Left == false)
        {
            Left = true;
            num--;
        }
        if (Left && this.transform.position.x >= 1)
        {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);

            if (this.transform.position.x <= num * 10f + (num - 2) * 10f)
            {
                Left = false;
               // Posx = this.transform.position.x;
            }
        }

    }
}
