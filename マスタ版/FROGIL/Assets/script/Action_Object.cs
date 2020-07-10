using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Object : MonoBehaviour
{
    public float limitsec;
    public string tagname;

    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();

        Destroy(this.gameObject, limitsec);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            rbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}