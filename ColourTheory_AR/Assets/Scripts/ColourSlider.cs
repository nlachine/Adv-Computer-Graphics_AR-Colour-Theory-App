using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSlider : MonoBehaviour
{
    public Slider slider_red,slider_green,slider_blue;
    private Color outputColour;
    private Renderer _Renderer;
    private Material _Material;
    public bool isReset = false;


    public GameObject matchSphere;
    public RandomColour s_randomColour;
    private Material matchMaterial;
    float tolerance = 0.05f;


    public void sliderUpdate(){
        if (!isReset)
            return;

        outputColour.r = slider_red.value;
        outputColour.g = slider_green.value;
        outputColour.b = slider_blue.value;
        _Material.color = outputColour;

        //Debug.Log("R:"+ outputColour.r + " G:" + outputColour.g + " B:"+ outputColour.b);

        float r_difference = matchMaterial.color.r - outputColour.r;
        float g_difference = matchMaterial.color.g - outputColour.g;
        float b_difference = matchMaterial.color.b - outputColour.b;

        if ( r_difference <= tolerance && r_difference >= -tolerance && g_difference <= tolerance && g_difference >= -tolerance && b_difference <= tolerance && b_difference >= -tolerance)
        {
            s_randomColour.Randomize();
            Debug.Log("Matched");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponent<MeshRenderer>();
        _Material = _Renderer.material;
        outputColour = new Vector4(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f), 1);
        _Material.color = outputColour;
        slider_red.value = outputColour.r;
        slider_green.value = outputColour.g;
        slider_blue.value = outputColour.b;
        isReset = true;

        matchMaterial = matchSphere.GetComponent<MeshRenderer>().material;
        s_randomColour = matchSphere.GetComponent<RandomColour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
