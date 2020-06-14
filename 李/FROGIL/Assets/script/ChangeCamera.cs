using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    [SerializeField]
    public GameObject MainCamera;
    [SerializeField]
    public GameObject TPSCamera;

    public string PushKey = "1";
    bool pushflag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(PushKey))
        {
            if (pushflag == false)
            {
                pushflag = true;

                MainCamera.SetActive(!MainCamera.activeSelf);
                TPSCamera.SetActive(!TPSCamera.activeSelf);

            }
        }
        else
        {
            //押す解除
            pushflag = false;
        }

    }
}
