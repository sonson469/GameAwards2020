using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSupply : MonoBehaviour
{
    public string Tongue;
    private bool TongueFlag = false;
    public bool SupplyFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TongueFlag == true && SupplyFlag == false)
        {
            TongueFlag = false;
            this.gameObject.SetActive(false);
            SupplyFlag = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Tongue)
        {
            TongueFlag = true;

        }
    }
}
