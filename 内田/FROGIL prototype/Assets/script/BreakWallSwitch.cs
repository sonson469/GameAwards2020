using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallSwitch : MonoBehaviour
{

    public string BoxTag;
    public string BoxoilTag;

    public GameObject BreakWall;

    public float limit = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == BoxTag)
        {

            BreakWall.SetActive(false);

            Invoke("CreateWall", limit);

        }

        if (collider.gameObject.tag == BoxoilTag)
        {

            BreakWall.SetActive(false);
            Invoke("CreateWall", limit);

        }
    }

    void CreateWall()
    {
        BreakWall.SetActive(true);
    }
}
