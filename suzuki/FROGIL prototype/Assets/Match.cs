using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Match : MonoBehaviour
{
    public string tagname;
    public GameObject MatchI;
    public GameObject GrassFire;
    GrassFire script;
    // Start is called before the first frame update
    void Start()
    {
        MatchI.SetActive(false);
        GrassFire = GameObject.Find("Grass");
        script = GrassFire.GetComponent<GrassFire>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            script.MatchFlag = true;
            MatchI.SetActive(true);
            Destroy(this.gameObject);
            
           

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
