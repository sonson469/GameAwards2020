using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 2f;
    public float rot = 360f;
    public float jumpforce = 1;

    float vx = 0;
    float vz = 0;

    bool pushflag = false;
    bool jumpflag = false;
    bool groundflag = false;

    Rigidbody rbody;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotation;

        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                rot * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );
            transform.LookAt(transform.position + forward);
        }
        characterController.Move(direction * speed * Time.deltaTime);


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

        if (jumpflag)
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
