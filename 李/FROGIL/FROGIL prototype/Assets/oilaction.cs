using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilaction : MonoBehaviour
{

    public GameObject newPrefab;
    public string PushKey = "z";
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0.5f;



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

            }
        }
        else
        {
            //押す解除
            pushflag = false;
        }
    }
}
