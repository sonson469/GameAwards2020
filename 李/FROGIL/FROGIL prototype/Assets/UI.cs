using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    GameObject Timertext;
    float time = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        this.Timertext = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.Timertext.GetComponent<Text>().text = this.time.ToString("F1");
        //時間切れ、処理止める
        if(time <= 0)
        {
            //this.time = 0;
            //Time.timeScale = 0;
        }

    }
}
