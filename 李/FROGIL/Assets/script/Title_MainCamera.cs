using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_MainCamera : MonoBehaviour
{
    

    public GameObject center;  //視点

    private Vector3 pos;

    //カメラ座標取得
    private Vector3 CameraPos;

    // Start is called before the first frame update
    void Start()
    {

        this.gameObject.transform.LookAt(center.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.transform.LookAt(center.transform);

    }
}