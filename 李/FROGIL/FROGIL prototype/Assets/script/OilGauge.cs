using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilGauge : MonoBehaviour
{

    //油5回のとき
    public GameObject oilGauge51;
    public GameObject oilGauge52;
    public GameObject oilGauge53;
    public GameObject oilGauge54;
    public GameObject oilGauge55;

    //油8回のとき
    public GameObject oilGauge81;
    public GameObject oilGauge82;
    public GameObject oilGauge83;
    public GameObject oilGauge84;
    public GameObject oilGauge85;
    public GameObject oilGauge86;
    public GameObject oilGauge87;
    public GameObject oilGauge88;


    //スクリプト
    public Player_action oilaction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //**************
        //油5回のとき
        //**************
        if (oilaction.num == 5)
        {

            if (oilaction.oilUInum5 == 5)
            {
                oilGauge55.SetActive(true);
            }
            if (oilaction.oilUInum5 == 4)
            {
                oilGauge55.SetActive(false);
                oilGauge54.SetActive(true);
            }
            if (oilaction.oilUInum5 == 3)
            {
                oilGauge54.SetActive(false);
                oilGauge53.SetActive(true);
            }
            if (oilaction.oilUInum5 == 2)
            {
                oilGauge53.SetActive(false);
                oilGauge52.SetActive(true);
            }
            if (oilaction.oilUInum5 == 1)
            {
                oilGauge52.SetActive(false);
                oilGauge51.SetActive(true);
            }
            if (oilaction.oilUInum5 == 0)
            {
                oilGauge51.SetActive(false);
                oilGauge55.SetActive(true);
            }
        }

        //***********
        //油8回のとき
        //***********
        if (oilaction.num == 8)
        {

            if (oilaction.oilUInum == 8)
            {
                oilGauge88.SetActive(true);
            }
            if (oilaction.oilUInum == 7)
            {
                oilGauge88.SetActive(false);
                oilGauge87.SetActive(true);
            }
            if (oilaction.oilUInum == 6)
            {
                oilGauge87.SetActive(false);
                oilGauge86.SetActive(true);
            }
            if (oilaction.oilUInum == 5)
            {
                oilGauge86.SetActive(false);
                oilGauge85.SetActive(true);
            }
            if (oilaction.oilUInum == 4)
            {
                oilGauge85.SetActive(false);
                oilGauge84.SetActive(true);
            }
            if (oilaction.oilUInum == 3)
            {
                oilGauge84.SetActive(false);
                oilGauge83.SetActive(true);
            }
            if (oilaction.oilUInum == 2)
            {
                oilGauge83.SetActive(false);
                oilGauge82.SetActive(true);
            }
            if (oilaction.oilUInum == 1)
            {
                oilGauge82.SetActive(false);
                oilGauge81.SetActive(true);
            }
            if (oilaction.oilUInum == 0)
            {
                oilGauge81.SetActive(false);
                oilGauge88.SetActive(true);
            }
        }

    }

}
