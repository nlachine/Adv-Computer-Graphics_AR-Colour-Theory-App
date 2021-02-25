using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterSphere : MonoBehaviour
{
    public Slider redSlider, yellowSlider, blueSlider;

    [SerializeField]
    Material AlterMaterial;

    private Color AlterColorRYB;
    private Color AlterColorRGB;
    private HandleColour _handleColour;

    // Start is called before the first frame update
    void Start()
    {
        AlterColorRYB = AlterMaterial.color;
        AlterColorRYB = _handleColour.Randomize();
        AlterColorRGB = _handleColour.ConvertToRGB(AlterColorRYB.r, AlterColorRYB.g, AlterColorRYB.b);
        AlterMaterial.color = AlterColorRGB;

        redSlider.value = AlterColorRYB.r;
        yellowSlider.value = AlterColorRYB.g;
        blueSlider.value = AlterColorRYB.b;
    }

    public void sliderUpdate()
    {

        //Save RYB values from slider
        AlterColorRYB.r = redSlider.value;
        AlterColorRYB.g = yellowSlider.value; //yellow
        AlterColorRYB.b = blueSlider.value;

        //Convert slider to RGB for display
        AlterColorRGB = _handleColour.ConvertToRGB(AlterColorRYB.r, AlterColorRYB.g, AlterColorRYB.b);
        AlterMaterial.color = AlterColorRGB;
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
