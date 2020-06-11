using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFrog : MonoBehaviour
{

    public GameObject center;
    public float speed = 3;
    Vector3 oldpos;

    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);

        Vector3 diff = transform.position - oldpos;
        oldpos = transform.position;
        transform.rotation = Quaternion.LookRotation(diff);
    }
}
