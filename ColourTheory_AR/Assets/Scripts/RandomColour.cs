using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    public void Randomize(){
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 1f, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
