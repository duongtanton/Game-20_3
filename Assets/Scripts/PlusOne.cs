using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour
{

    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 0.2f;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
