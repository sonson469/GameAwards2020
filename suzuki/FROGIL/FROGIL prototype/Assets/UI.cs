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
    

    public GameObject Player_action;
    Player_action script;
    public float oil;
    // Start is called before the first frame update
    void Start()
    {
        //タイムオブジェクト見つける
        Time.timeScale = 1;
        this.Timertext = GameObject.Find("Time");
        //オイルオブジェクト見つける
        this.oilGauge = GameObject.Find("oilGauge");
        Player_action = GameObject.Find("Player");
        script = Player_action.GetComponent<Player_action>();
    }

    // Update is called once per frame
    void Update()
    {
        oil = script.oilmator;
        //Debug.Log(oil);
        this.time -= Time.deltaTime;
        this.Timertext.GetComponent<Text>().text = this.time.ToString("F1");
        //時間切れ、処理止める
        if(time <= 0)
        {
            //this.time = 0;
            //Time.timeScale = 0;
        }

       
        if (oil <= 0)
        {
             this.oilGauge.GetComponent<Image>().fillAmount +=0.00085f;
              
        }


    }

    public void DecreseOil()
    {
        
            if (oil > 0)
            {
                this.oilGauge.GetComponent<Image>().fillAmount -= 0.125f;
                
            }
            

            
        
        


    }

}
