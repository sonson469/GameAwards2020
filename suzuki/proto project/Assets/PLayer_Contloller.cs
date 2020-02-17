using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Contloller : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }


    }
}
