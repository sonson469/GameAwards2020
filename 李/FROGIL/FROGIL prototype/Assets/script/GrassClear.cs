using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassClear : MonoBehaviour
{
    public string tagname;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagname)
        {

                SceneManager.LoadScene("Clear");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
