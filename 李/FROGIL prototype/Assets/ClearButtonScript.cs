using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearButtonScript : MonoBehaviour
{

    public GameObject NextButton;
    public GameObject SelectButton;
    public GameObject TitleButton;

    public GameObject ClearButton;

    private Button Next;
    private Button Select;
    private Button Title;

    public float realDeltaTime;
    public float lastRealTime;

    public UITime timerisult;
    public GameObject TimeText;

    public int num;

    float Timer;

    // Start is called before the first frame update
    void Start()
    {

        ClearButton.SetActive(false);

        Next = NextButton.GetComponent<Button>();
        Select = SelectButton.GetComponent<Button>();
        Title = TitleButton.GetComponent<Button>();

        //最初に選択されてるやつ
        Next.Select();
    }

    // Update is called once per frame
    void Update()
    {
        CalcRealDeltaTime();

        Timer += realDeltaTime;

        if(Timer >= 1)
        {
            CreateButton();
        }

        TimeText.GetComponent<Text>().text = "タイム  :  " + ((int)timerisult.seconds).ToString("000");
    }

    void CreateButton()
    {
        ClearButton.SetActive(true);
    }

    //現実時間基準でデルタ時間を求める.
    public void CalcRealDeltaTime()
    {
        if (lastRealTime == 0)
        {
            lastRealTime = Time.realtimeSinceStartup;
        }
        realDeltaTime = Time.realtimeSinceStartup - lastRealTime;
        lastRealTime = Time.realtimeSinceStartup;
    }

    public void GoNextStage()
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
        if (num == 6)
        {
            SceneManager.LoadScene("Stage6");
        }
        if (num == 7)
        {
            SceneManager.LoadScene("Stage7");
        }
        if (num == 8)
        {
            SceneManager.LoadScene("Stage8");
        }
        if (num == 9)
        {
            SceneManager.LoadScene("Stage9");
        }
    }

    public void GoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
