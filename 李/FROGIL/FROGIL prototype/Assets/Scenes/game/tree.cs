using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //衝突判定
        if (collision.gameObject.tag == "Frog")
        {
            //相手のタグがBallならば、自分を消す
            Destroy(this.gameObject);
        }
    }


}
