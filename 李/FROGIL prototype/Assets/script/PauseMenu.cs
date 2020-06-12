using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Pause;

    public GrassClear Clear;


    public bool PauseFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Menu") && !Clear.ClearFlag)
        {
            Pause.SetActive(!Pause.activeSelf);
        }
        if (Pause.activeSelf)
        {
            PauseFlag = true;
            Time.timeScale = 0f;
        }
        if(!Pause.activeSelf && !Clear.ClearFlag)
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
