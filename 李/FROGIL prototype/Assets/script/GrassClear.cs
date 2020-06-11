using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassClear : MonoBehaviour
{
    public string tagname;

    public bool ClearFlag;

    // Start is called before the first frame update
    void Start()
    {
        ClearFlag = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagname)
        {
            ClearFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (ClearFlag)
        {
            SceneManager.LoadScene("Result");
        }
        
    }
}
