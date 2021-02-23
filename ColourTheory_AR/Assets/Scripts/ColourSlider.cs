using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSlider : MonoBehaviour
{
    //public Slider slider_red, slider_green, slider_blue;
    public Slider slider_red, slider_yellow, slider_blue;
    private Color outputColour;
    private Renderer _Renderer;
    private Material _Material;
    public bool isReset = false;


    public GameObject matchSphere;
    public RandomColour s_randomColour;
    private Material matchMaterial;
    float tolerance = 0.10f;

    //Colour Constants
    float[] white = { 1.0f, 1.0f, 1.0f };
    float[] red = { 1.0f, 0.0f, 0.0f };
    float[] yellow = { 1.0f, 1.0f, 0.0f };
    float[] blue = { 0.163f, 0.373f, 0.6f };
    float[] violet = { 0.5f, 0.0f, 0.5f };
    float[] green = { 0.0f, 0.66f, 0.2f };
    float[] orange = { 1.0f, 0.5f, 0.0f };
    float[] black = { 0.2f, 0.094f, 0.0f };

    public void sliderUpdate()
    {
        if (!isReset)
            return;

        // outputColour.r = slider_red.value;
        // outputColour.g = slider_green.value;
        // outputColour.b = slider_blue.value;
        float r = slider_red.value;
        float y = slider_yellow.value;
        float b = slider_blue.value;

        //Debug.Log("R:"+ outputColour.r + " G:" + outputColour.g + " B:"+ outputColour.b);
        for (int i = 0; i < 3; i++)
        {
            float tempColour = white[i] * (1 - r) * (1 - b) * (1 - y) +
            red[i] * r * (1 - b) * (1 - y) +
            blue[i] * (1 - r) * b * (1 - y) +
            violet[i] * r * b * (1 - y) +
            yellow[i] * (1 - r) * (1 - b) * y +
            orange[i] * r * (1 - b) * y +
            green[i] * (1 - r) * b * y +
            black[i] * r * b * y;
            
            if (i == 0)
                outputColour.r = tempColour;
            if (i == 1)
                outputColour.g = tempColour;
            if (i == 2)
                outputColour.b = tempColour;
        }

        _Material.color = outputColour;
        float r_difference = matchMaterial.color.r - outputColour.r;
        float g_difference = matchMaterial.color.g - outputColour.g;
        float b_difference = matchMaterial.color.b - outputColour.b;

        if (r_difference <= tolerance && r_difference >= -tolerance && g_difference <= tolerance && g_difference >= -tolerance && b_difference <= tolerance && b_difference >= -tolerance)
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
    outputColour = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
    _Material.color = outputColour;
    slider_red.value = outputColour.r;
    slider_yellow.value = outputColour.g;
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
