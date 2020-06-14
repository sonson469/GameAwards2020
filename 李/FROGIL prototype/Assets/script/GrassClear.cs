using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassClear : MonoBehaviour
{
    public string tagname;

    public bool ClearFlag;

    public GameObject ClearUI;
    public GameObject ClearBuck;


    // Start is called before the first frame update
    void Start()
    {
        ClearFlag = false;
        ClearUI.SetActive(false);
        ClearBuck.SetActive(false);
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
            Time.timeScale = 0f;
            ClearUI.SetActive(true);
            ClearBuck.SetActive(true);
        }
        
    }
}
