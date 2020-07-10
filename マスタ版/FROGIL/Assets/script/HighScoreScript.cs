using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//**********************
// ハイスコアを表示
//**********************

public class HighScoreScript : MonoBehaviour
{
    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームデータキー"HighScore"が無ければ
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            // ゲームデータキー"HighScore"に"0"を設定
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString("0000");
    }
}
