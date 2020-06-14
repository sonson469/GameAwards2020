using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{

    public GameObject PressObject;
    public GameObject StartButton;

    public GameObject Press;
    public GameObject Button1;
    public GameObject Button2;

    public GameObject Fadein;
    float alfa;


    private Button PressA;
    private Button StageSelect;
    private Button How;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;

        Time.timeScale = 1f;

        StartButton.SetActive(false);
        Fadein.SetActive(false);

        audioSource.Play();

        StageSelect = Button1.GetComponent<Button>();
        How = Button2.GetComponent<Button>();
        PressA = Press.GetComponent<Button>();

        //最初に選択されてるやつ
        PressA.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {
        PressObject.SetActive(false);
        StartButton.SetActive(true);
        StageSelect.Select();
    }
    public void GoStageSelect()
    {
        //+Time.deltaTime
        Fadein.SetActive(true);

        Invoke("Load", 1.0f);
        
        
    }
    public void HowPlay()
    {
        SceneManager.LoadScene("How");
    }

    public void Load()
    {
        SceneManager.LoadScene("StageSelect");
    }

}
