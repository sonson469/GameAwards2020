using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //時間制限処理
    GameObject Timertext;
    float time = 90.0f;
    //オイル処理
    GameObject oilGauge;
    float Oil = 1;
    // Start is called before the first frame update
    void Start()
    {
        //タイムオブジェクト見つける
        Time.timeScale = 1;
        this.Timertext = GameObject.Find("Time");
        //オイルオブジェクト見つける
        this.oilGauge = GameObject.Find("oilGauge");
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
        if(Oil >1)
        {
            Oil = 1;
        }
        if(Oil < 0)
        {
            Oil = 0;
        }
        if (Oil <= 0)
        {
            this.oilGauge.GetComponent<Image>().fillAmount +=0.005f;
            Oil += 0.005f;
        }


    }

    public void DecreseOil()
    {
        
            if (Oil > 0)
            {
                this.oilGauge.GetComponent<Image>().fillAmount -= 0.25f;
                Oil -= 0.25f;
            }
            
            
        
        


    }

}
