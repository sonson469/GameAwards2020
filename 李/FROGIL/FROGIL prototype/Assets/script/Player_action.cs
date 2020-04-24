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
    //クールタイム
    public bool Use;
    public float cooltime;
    public float oilmator;

    bool pushflag = false;

    // Start is called before the first frame update
    void Start()
    {
        Use = true;
        cooltime = 0.0f;
        oilmator = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //8回使うと５秒間使えなくなる
        if(Input.GetKey(PushKey))
        {
            if(pushflag == false && Use == true && oilmator > 0.0f)
            {
                pushflag = true;
                //Use = false;
                oilmator -= 1.0f;

                Vector3 newpos = this.transform.position;

                Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);

                offset = this.transform.rotation * offset;
                newpos = newpos + offset;

                //プレハブからゲームオブジェクトcreate
                GameObject newGameObject = Instantiate(newPrefab) as GameObject;
                newGameObject.transform.position = newpos;
                //投げる
                //Rigidbody rbody = newGameObject.GetComponent<Rigidbody>();
                Vector3 throwV = new Vector3(throwX, throwY, throwZ);
                throwV = this.transform.rotation * throwV;
                //rbody.AddForce(throwV, ForceMode.Impulse);

                GameObject director = GameObject.Find("GameDirector");
                director.GetComponent<UI>().DecreseOil();
                

            }
            

        }
        else
        {
            //押す解除
            pushflag = false;

        }

        if (oilmator <= 0.0f)
        {
            Use = false;



            if (Use == false)
            {
                cooltime += Time.deltaTime;

            }
            if (cooltime >= 5.0f)
            {
                Use = true;
                cooltime = 0.0f;
                oilmator = 8.0f;
            }
        }
        
    }
}
