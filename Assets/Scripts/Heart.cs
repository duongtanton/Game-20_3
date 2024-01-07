using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool getActive()
    {
        Renderer renderer = GetComponent<Renderer>();
        return renderer.isVisible;
    }
}
