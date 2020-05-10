using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RESULT : MonoBehaviour
{
    //**********
    //どのUIか
    //**********
    public GameObject TimeText;
    public GameObject TimeScore;

    //**************
    //他スクリプト
    //**************
    public UITime UItime;

    //*******
    //変数
    //*******
    float timetext;
    int timescore;

    // Start is called before the first frame update
    void Start()
    {

        timetext = UITime.GetTimeScore();

    }

    // Update is called once per frame
    void Update()
    {

        TimeText.GetComponent<Text>().text = "TIME : " + ((int)timetext).ToString("000");

    }
}
