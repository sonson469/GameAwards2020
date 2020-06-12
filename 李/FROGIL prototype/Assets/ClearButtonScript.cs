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

    public void GoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
