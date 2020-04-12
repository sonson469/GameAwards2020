using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Object : MonoBehaviour
{
    public float limitsec = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, limitsec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
