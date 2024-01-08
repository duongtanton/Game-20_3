using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseDown()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
