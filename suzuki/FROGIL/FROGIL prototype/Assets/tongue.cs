using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tongue : MonoBehaviour
{
    public GameObject newPrefab;
    public string PushKey = "x";
    public float offsetX = 0.01f;
    public float offsetY = 0.193f;
    public float offsetZ = 0.33f;



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

                Vector3 newpos = this.transform.position;

                Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);

                offset = this.transform.rotation * offset;
                newpos = newpos + offset;

                //プレハブからゲームオブジェクトcreate
                GameObject newGameObject = Instantiate(newPrefab) as GameObject;
                newGameObject.transform.position = newpos;
                //投げる
                Rigidbody rbody = newGameObject.GetComponent<Rigidbody>();
               

            }
        }
        else
        {
            //押す解除
            pushflag = false;
        }
    }
}
