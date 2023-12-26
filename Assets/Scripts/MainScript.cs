using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Transform chickenTransform;
    public int numberOfChickens = 10;
    public Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
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
           Instantiate(chicken, chickenTransform.position, transform.rotation);
        }
    }
}
