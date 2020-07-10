using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Center : MonoBehaviour
{

    public float speed = 0.2f;
    bool flag;
    public GameObject FROGIL;
    public GameObject PressA;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        Invoke("Titleset", 1.5f);
        Invoke("PressSet", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            this.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    void Titleset()
    {
        FROGIL.SetActive(true);
        flag = true;
    }

    void PressSet()
    {
        PressA.SetActive(true);
    }

}
