using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    [SerializeField]
    public GameObject MainCamera;
    [SerializeField]
    public GameObject TPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("1"))
        {
            MainCamera.SetActive(!MainCamera.activeSelf);
            TPSCamera.SetActive(!TPSCamera.activeSelf);
        }

    }
}
