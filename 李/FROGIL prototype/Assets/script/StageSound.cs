using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSound : MonoBehaviour
{

    public GrassClear Clear;

    public AudioSource audioSource;
    //public AudioClip

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Clear.ClearFlag)
        {
            audioSource.Stop();
        }
    }
}
