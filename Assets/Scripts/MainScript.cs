using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Transform chickenTransform;
    public int numberOfChickens = 10;
    public Chicken chicken;
    public List<Chicken> chickens;
    public AudioClip backgoundSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgoundSound;
        audioSource.volume -= 0.9f;
        audioSource.Play();
        SpawnChickens();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnChickens()
    {
        // Spawn multiple chickens
        for (int i = 0; i < numberOfChickens; i++)
        {
           Instantiate(chickens[Random.Range(0, chickens.Count)], chickenTransform.position, transform.rotation);
        }
    }
}
