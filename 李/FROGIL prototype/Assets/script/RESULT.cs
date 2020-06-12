using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RESULT : MonoBehaviour
{
    //**********
    //どのUIか
    //**********
    /*public GameObject TimeText;
    public GameObject TimeScore;

    public GameObject SupplyText;
    public GameObject SupplyScore;

    public GameObject EnemyText;
    public GameObject EnemyScore;

    public GameObject ScoreText;*/

    //************
    // ボタン
    //************
    /*public GameObject Button; //まとめて
    public GameObject NextButton;
    public GameObject SelectButton;
    public GameObject TitleButton;
    private Button Next;
    private Button Select;
    private Button Title;*/

    //**************
    //他スクリプト
    //**************

    //*******
    //変数
    //*******
    /*float timetext;
    float timescore;

    int supplytext;
    int supplyscore;

    int enemytext;
    int enemyscore;

    int score;*/

    // Start is called before the first frame update
    void Start()
    {

        /*timetext = UITime.GetTimeScore();
        timescore = UITime.GetTimeScore2();
        supplytext = OilSupply.GetSupplyScore();
        supplyscore = OilSupply.GetSupplyScore2();
        enemytext = Enemy.GetEnemyScore();
        enemyscore = Enemy.GetEnemyScore2();
        score = ScoreScript.GetScore();

        Next = NextButton.GetComponent<Button>();
        Select = SelectButton.GetComponent<Button>();
        Title = TitleButton.GetComponent<Button>();
        Next.Select();*/

    }

    // Update is called once per frame
    void Update()
    {

        /*TimeText.GetComponent<Text>().text = ":  " + ((int)timetext).ToString("000");
        TimeScore.GetComponent<Text>().text = ((int)timescore).ToString("-000");
        SupplyText.GetComponent<Text>().text = ":  " + (supplytext).ToString("000");
        SupplyScore.GetComponent<Text>().text =(supplyscore).ToString("-000");
        EnemyText.GetComponent<Text>().text = ":  " + (enemytext).ToString("000");
        EnemyScore.GetComponent<Text>().text = (enemyscore).ToString("-000");
        ScoreText.GetComponent<Text>().text = "スコア  :  " + (score).ToString("0000");*/

    }

   /* public void GoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
    */
}
