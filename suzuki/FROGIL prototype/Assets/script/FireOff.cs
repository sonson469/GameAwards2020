using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOff : MonoBehaviour
{

    public float limit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("off", limit);
    }

    void off()
    {
        this.gameObject.SetActive(false);
    }
}
