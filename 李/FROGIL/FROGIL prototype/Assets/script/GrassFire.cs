using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFire : MonoBehaviour
{
    //衝突対象
    public string tagname;

    //燃やすやつ
    public GameObject Fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {

            Fire.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
