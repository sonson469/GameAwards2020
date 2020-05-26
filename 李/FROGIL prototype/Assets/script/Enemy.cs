using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public string tagname;

    //通常状態
    public GameObject DefTag;
    //油状態
    public GameObject OilTag;

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
        if (collider.gameObject.tag == tagname)
        {
            OilTag.SetActive(true);
            DefTag.SetActive(false);
            Invoke("Release", 8.0f);
        }
    }

    void Release()
    {
        OilTag.SetActive(false);
        DefTag.SetActive(true);
    }
}
