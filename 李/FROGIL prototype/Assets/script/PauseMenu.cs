using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Pause;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private Button tudukeru;
    private Button yarinaosu;
    private Button akirameru;

    public bool PauseFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);

        tudukeru = Button1.GetComponent<Button>();
        yarinaosu = Button2.GetComponent<Button>();
        akirameru = Button3.GetComponent<Button>();

        //最初に選択されてるやつ
        tudukeru.Select();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Menu"))
        {
            Pause.SetActive(!Pause.activeSelf);
        }

        if (Pause.activeSelf)
        {
            PauseFlag = true;
            Time.timeScale = 0f;
     
        }
        else
        {
            PauseFlag = false;
            Time.timeScale = 1f;
        }

    }

    public void Keep()
    {
        Pause.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Retire()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameover");
    }
}
