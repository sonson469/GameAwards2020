using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") || Input.GetButtonDown("Tongue") || Input.GetButtonDown("Oil"))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
