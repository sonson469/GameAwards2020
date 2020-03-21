using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncollision_Objects : MonoBehaviour
{
    public string tagname;
    //public string hidename;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == tagname)
        {

            Destroy(this.gameObject);
            //Time.timeScale = 0;
            /*GameObject hideobject = GameObject.Find(hidename);
            if(hideobject)
            {
                Time.timeScale = 0;
                //hideobject.SetActive(false);
            }*/
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
