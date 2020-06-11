using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Center : MonoBehaviour
{

    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, speed*Time.deltaTime, 0);

    }
}
