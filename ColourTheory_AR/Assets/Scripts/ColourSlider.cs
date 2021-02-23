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
    public HandleColour s_handleColour;
    private Material matchMaterial;
    float tolerance = 0.10f;

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

        outputColour = s_handleColour.ConvertToRGB(r, y, b);

        // //Debug.Log("R:"+ outputColour.r + " G:" + outputColour.g + " B:"+ outputColour.b);
        // for (int i = 0; i < 3; i++)
        // {
        //     float tempColour = whiteRYB[i] * (1 - r) * (1 - b) * (1 - y)
        //                         + redRYB[i] * r * (1 - b) * (1 - y)
        //                         + blueRYB[i] * (1 - r) * b * (1 - y)
        //                         + violetRYB[i] * r * b * (1 - y)
        //                         + yellowRYB[i] * (1 - r) * (1 - b) * y
        //                         + orangeRYB[i] * r * (1 - b) * y
        //                         + greenRYB[i] * (1 - r) * b * y
        //                         + blackRYB[i] * r * b * y;

        //     if (i == 0)
        //         outputColour.r = tempColour;
        //     else if (i == 1)
        //         outputColour.g = tempColour;
        //     else if (i == 2)
        //         outputColour.b = tempColour;
        // }

        _Material.color = outputColour;
        float r_difference = matchMaterial.color.r - outputColour.r;
        float g_difference = matchMaterial.color.g - outputColour.g;
        float b_difference = matchMaterial.color.b - outputColour.b;

        if (r_difference <= tolerance && r_difference >= -tolerance && g_difference <= tolerance && g_difference >= -tolerance && b_difference <= tolerance && b_difference >= -tolerance)
        {
            matchMaterial.color = s_handleColour.Randomize();
            Debug.Log("Matched");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponent<MeshRenderer>();
        _Material = _Renderer.material;
        outputColour = s_handleColour.Randomize();
        _Material.color = s_handleColour.ConvertToRGB(outputColour.r, outputColour.g, outputColour.b);
        slider_red.value = outputColour.r;
        slider_yellow.value = outputColour.g;
        slider_blue.value = outputColour.b;
        isReset = true;

        matchMaterial = matchSphere.GetComponent<MeshRenderer>().material;
        s_handleColour = matchSphere.GetComponent<HandleColour>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
