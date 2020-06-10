using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbodyScript : MonoBehaviour
{

    public Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
