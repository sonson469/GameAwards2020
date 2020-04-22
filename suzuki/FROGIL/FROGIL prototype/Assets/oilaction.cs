using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilaction : MonoBehaviour
{

    public GameObject newPrefab;
    public GameObject Player_action;
    Player_action script;

    public string PushKey = "z";
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0.5f;

    

    bool pushflag = false;

    public float oil;

    // Start is called before the first frame update
    void Start()
    {
        Player_action = GameObject.Find("Player");
        script = Player_action.GetComponent<Player_action>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        oil = script.oilmator;
        //Debug.Log(oil);
        if (Input.GetKey(PushKey) && oil > 0.0f)
        {
            if (pushflag == false && script.oilmator >= 0.0f)
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
