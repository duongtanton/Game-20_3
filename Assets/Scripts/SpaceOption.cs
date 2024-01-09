using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
