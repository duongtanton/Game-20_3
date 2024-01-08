using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int value;
    public TextMeshPro textMeshPro;
    // Start is called before the f irst frame update
    void Start()
    {
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = value.ToString();
    }
    
    public void SetValue(int value)
    {
        this.value = value;
    }

    public void Change(int value)
    {
        this.value += value;
    }
}
