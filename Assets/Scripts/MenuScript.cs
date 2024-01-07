using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public AudioClip backgoundSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgoundSound;
        audioSource.volume -= 0.9f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
