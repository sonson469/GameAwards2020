using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public string RightKey = "l";
    public string LeftKey = "j";
    public string MaeKey = "k";
    public string UsiroKey = "i";

    public string UpRightKey = "h";
    public string UpLeftKey = "f";
    public string UpMaeKey = "g";
    public string UpUsiroKey = "t";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 下-----------------------------------------------------------------------------
        if (Input.GetKeyDown(MaeKey))
        {
            this.gameObject.transform.position = new Vector3(-10.0f, 8.0f, -18.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(RightKey))
        {
            this.gameObject.transform.position = new Vector3(20.0f, 8.0f, 12.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 270.0f, 0.0f);
        }
        if (Input.GetKeyDown(LeftKey))
        {
            this.gameObject.transform.position = new Vector3(-40.0f, 8.0f, 12.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 90.0f, 0.0f);
        }
        if (Input.GetKeyDown(UsiroKey))
        {
            this.gameObject.transform.position = new Vector3(-10.0f, 8.0f, 42.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 180.0f, 0.0f);
        }

        // 上------------------------------------------------------------------------------------
        if (Input.GetKeyDown(UpMaeKey))
        {
            this.gameObject.transform.position = new Vector3(-10.0f, 15.0f, -16.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(UpRightKey))
        {
            this.gameObject.transform.position = new Vector3(18.0f, 15.0f, 12.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 270.0f, 0.0f);
        }
        if (Input.GetKeyDown(UpLeftKey))
        {
            this.gameObject.transform.position = new Vector3(-38.0f, 15.0f, 12.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 90.0f, 0.0f);
        }
        if (Input.GetKeyDown(UpUsiroKey))
        {
            this.gameObject.transform.position = new Vector3(-10.0f, 15.0f, 40.0f);
            this.gameObject.transform.rotation = Quaternion.Euler(20.0f, 180.0f, 0.0f);
        }

    }
}
