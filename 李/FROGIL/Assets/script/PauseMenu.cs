using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Pause;

    public GrassClear Clear;

    public AudioSource AudioSource;

    public AudioClip pause;
    public AudioClip retry;
    public AudioClip retire;


    public bool PauseFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        Pause.SetActive(false);
        AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Menu") && !Clear.ClearFlag)
        {
            AudioSource.PlayOneShot(pause);
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
        AudioSource.PlayOneShot(retry);
        Pause.SetActive(false);
    }

    public void Retry()
    {
        AudioSource.PlayOneShot(retry);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Retire()
    {
        AudioSource.PlayOneShot(retire);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameover");
    }
}
