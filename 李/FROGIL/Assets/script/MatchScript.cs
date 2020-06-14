using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatchScript : MonoBehaviour
{
    public string tagname;
    public GameObject MatchON;
    public GameObject MatchOFF;
    public bool MatchFlag;
    
    // Start is called before the first frame update
    void Start()
    {
        MatchON.SetActive(false);
        MatchOFF.SetActive(true);
        MatchFlag = false;
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            MatchFlag = true;
            MatchOFF.SetActive(false);
            MatchON.SetActive(true);
            Destroy(this.gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
