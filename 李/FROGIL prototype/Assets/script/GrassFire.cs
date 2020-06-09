using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFire : MonoBehaviour
{
    //衝突対象
    public string tagname;

    //燃やすやつ
    public GameObject Fire;
    public GameObject Fire2;
    public GameObject Fire3;
    public AudioSource audioSource;
    public AudioClip FireSE;

    private bool FireFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FireFlag)
        {
            FireFlag = false;
            audioSource.PlayOneShot(FireSE);
            Fire.SetActive(true);
            Fire2.SetActive(true);
            Fire3.SetActive(true);
            Invoke("DestroyGrass", 5);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == tagname)
        {
            FireFlag = true;
        }
    }
    void DestroyGrass()
    {
        Destroy(this.gameObject);
        audioSource.Stop();
    }

}
