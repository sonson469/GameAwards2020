using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、往復する
public class Forever_MoveCos : MonoBehaviour
{
	public float speedX = 0; // スピードX：Inspectorで指定
	public float speedZ = 1; // スピードZ：Inspectorで指定
	//public float second = 1; // かかる秒数：Inspectorで指定

    public string GroundTag;
    public bool GroundFlag;

    public bool RotFrag = false;

    private Rigidbody rbody;
    private Animator animator;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        //rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() // ずっと、往復する
	{
        //time += Time.deltaTime;
        //float s = Mathf.Cos(time * 3.14f / second);  // 移動量を求める
        //this.transform.Translate(speedX * s / 50, speedY * s / 50, speedZ * s / 50);

        if (GroundFlag)
        {
            rbody.AddForce(speedX, 0, speedZ, ForceMode.Impulse);

            animator.SetFloat("Speed", 1.0f);

            if (RotFrag)
            {

                RotFrag = false;
                speedX *= -1;
                speedZ *= -1;

                if(speedX > 0)
                {
                    transform.rotation = Quaternion.AngleAxis(360f, new Vector3(0, 1, 0));
                }
                if (speedX < 0)
                {
                    transform.rotation = Quaternion.AngleAxis(180f, new Vector3(0, 1, 0));
                }
                if (speedZ > 0)
                {
                    transform.rotation = Quaternion.AngleAxis(270f, new Vector3(0, 1, 0));
                }
                if (speedZ < 0)
                {
                    transform.rotation = Quaternion.AngleAxis(90f, new Vector3(0, 1, 0));
                }

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == GroundTag)
        {
            GroundFlag = true;
        }
        else
        {
            RotFrag = true;
        }
    }
}
