using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Contloller : MonoBehaviour
{
    public float speed = 2;
    public float jumpforce = 1;

    float vx = 0;
    float vz = 0;

    bool pushflag   = false;
    bool jumpflag   = false;
    bool groundflag = false;

    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();

        rbody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    // Update is called once per frame
    void Update()
    {
        vx = Input.GetAxisRaw("Horizontal") * speed;
        vz = Input.GetAxisRaw("Vertical")   * speed;

        //spacekey Push
        if (Input.GetKey("space") && groundflag)
        {
            if (pushflag == false)
            {
                pushflag = true;
                jumpflag = true;

            }
        }
        else
        {
            pushflag = false;
        }


        


    }

    private void FixedUpdate()
    {
        if ((vx != 0) || (vz != 0))
        {
           
            this.transform.Translate(vx / 50, 0, vz / 50);
        }

        if(jumpflag)
        {

            jumpflag = false;
            rbody.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);


        }


    }

    void OnTriggerStay(Collider collision)
    {

        groundflag = true;
    }
    void OnTriggerExit(Collider collision)
    {
        groundflag = false;
    }



}
