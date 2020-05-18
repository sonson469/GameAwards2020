using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilGauge : MonoBehaviour
{

    public GameObject oilGauge1;
    public GameObject oilGauge2;
    public GameObject oilGauge3;
    public GameObject oilGauge4;
    public GameObject oilGauge5;
    public GameObject oilGauge6;
    public GameObject oilGauge7;
    public GameObject oilGauge8;

    //スクリプト
    public Player_action oilaction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(oilaction.oilUInum == 8)
        {
            oilGauge8.SetActive(true);
        }
        if(oilaction.oilUInum == 7)
        {
            oilGauge8.SetActive(false);
            oilGauge7.SetActive(true);
        }
        if(oilaction.oilUInum == 6)
        {
            oilGauge7.SetActive(false);
            oilGauge6.SetActive(true);
        }
        if(oilaction.oilUInum == 5)
        {
            oilGauge6.SetActive(false);
            oilGauge5.SetActive(true);
        }
        if(oilaction.oilUInum == 4)
        {
            oilGauge5.SetActive(false);
            oilGauge4.SetActive(true);
        }
        if(oilaction.oilUInum == 3)
        {
            oilGauge4.SetActive(false);
            oilGauge3.SetActive(true);
        }
        if(oilaction.oilUInum == 2)
        {
            oilGauge3.SetActive(false);
            oilGauge2.SetActive(true);
        }
        if(oilaction.oilUInum == 1)
        {
            oilGauge2.SetActive(false);
            oilGauge1.SetActive(true);
        }
        if(oilaction.oilUInum == 0)
        {
            oilGauge1.SetActive(false);
            oilGauge8.SetActive(true);
        }

    }

}
