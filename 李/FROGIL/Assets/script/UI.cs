using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //時間制限処理
    GameObject Timertext;
    //float time = 90.0f;
    //オイル処理
    GameObject oilGauge8;
    GameObject oilGauge5;
    GameObject oilGauge3;


    public GameObject Player_action;
    Player_action script;
    public float oil8;
    public float oil5;
    public float oil3;
    // Start is called before the first frame update
    void Start()
    {
        //タイムオブジェクト見つける
       // Time.timeScale = 1;
       // this.Timertext = GameObject.Find("Time");
        //オイルオブジェクト見つける
        this.oilGauge8 = GameObject.Find("oilGauge8");
        this.oilGauge5 = GameObject.Find("oilGauge5");
        this.oilGauge3 = GameObject.Find("oilGauge3");
        Player_action = GameObject.Find("Player");
        script = Player_action.GetComponent<Player_action>();
    }

    // Update is called once per frame
    void Update()
    {
        oil8 = script.oilmator;
        oil5 = script.oilmator5;
        oil3 = script.oilmator3;
        //Debug.Log(oil);
        // this.time -= Time.deltaTime;
        //this.Timertext.GetComponent<Text>().text = this.time.ToString("F1");
        //時間切れ、処理止める
        //if(time <= 0)
        //{
        //this.time = 0;
        //Time.timeScale = 0;
        //}
        if (script.num == 8)
        {
            if (oil8 == 0)
            {
                this.oilGauge8.GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime;
            }
        }

        if (script.num == 5)
        {
            if (oil5 == 0)
            {
                this.oilGauge5.GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime;
            }
        }

        if (script.num == 3)
        {
            if (oil3 == 0)
            {
                this.oilGauge3.GetComponent<Image>().fillAmount += 0.2f * Time.deltaTime;
            }
        }

    }

    public void DecreseOil()
    {

        if (script.num == 8)
        {
            if (oil8 > 0)
            {
                this.oilGauge8.GetComponent<Image>().fillAmount -= 0.125f;
            }
        }
        if (script.num == 5)
        {
            if (oil5 > 0)
            {
                this.oilGauge5.GetComponent<Image>().fillAmount -= 0.2f;
            }
        }
        if (script.num == 3)
        {
            if(oil3 > 0)
            {
                this.oilGauge3.GetComponent<Image>().fillAmount -= 1.0f / 3.0f;
            }
            
        }

    }

}
