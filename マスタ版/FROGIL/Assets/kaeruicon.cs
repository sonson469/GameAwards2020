using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kaeruicon : MonoBehaviour
{

    public GameObject kaeru1;
    public GameObject kaeru2;

    public ClearButtonScript timescript;
    
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        kaeru1.SetActive(true);
        kaeru2.SetActive(false);
        timer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timescript.CalcRealDeltaTime();
        timer += timescript.realDeltaTime;

        if (timer > 0.5f && timer < 1f)
        {
            kaeru1.SetActive(false);
            kaeru2.SetActive(true);
        }
        if (timer > 1f)
        {
            kaeru1.SetActive(true);
            kaeru2.SetActive(false);
            timer = 0;
        }

    }
}
