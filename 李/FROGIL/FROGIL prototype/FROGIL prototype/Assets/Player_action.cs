using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_action : MonoBehaviour
{
    public GameObject newPrefab;
    public string PushKey = "z";
    public float throwX = 0;
    public float throwY = 3;
    public float throwZ = 4;
    public float offsetX = 0f;
    public float offsetY = 1f;
    public float offsetZ = 0.5f;

    

    bool pushflag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(PushKey))
        {
            if(pushflag == false)
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
                Vector3 throwV = new Vector3(throwX, throwY, throwZ);
                throwV = this.transform.rotation * throwV;
                rbody.AddForce(throwV, ForceMode.Impulse);

            }
        }
        else
        {
            //押す解除
            pushflag = false;
        }
    }
}
