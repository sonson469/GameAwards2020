using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    // ターゲットオブジェクトのTransformを格納する変数
    public Transform target;
    // ターゲットオブジェクトの座標からオフセットする値
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトの座標を格納
        Vector3 position = transform.position;
        // ターゲットオブジェクトの座標にオフセット値を加える
        position.x = target.position.x;
        position.z = target.position.z + offset;
        // posの値をオブジェクト座標に格納
        transform.position = position;
    }
}
