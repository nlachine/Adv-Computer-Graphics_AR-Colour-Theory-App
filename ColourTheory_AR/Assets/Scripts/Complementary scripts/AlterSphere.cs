using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterSphere : MonoBehaviour
{
    public Slider redSlider, yellowSlider, blueSlider;

    [SerializeField]
    Material AlterMaterial;
    [SerializeField]
    Material ComplementaryMaterial;
    [SerializeField]
    Material ResultMaterial;

    [SerializeField]
    HandleColour _handleColour;

    private Color AlterColorRYB;
    private Color AlterColorRGB;

    private Color ComplementaryColorRYB;
    private Color ComplementaryColorRGB;

    private Color ResultColorRYB;
    private Color ResultColorRGB;

    private bool isReset = false;

    float tolerance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        isReset = true;
    }

    void setUp()
    {
        //randomizes the altered color and converts to rgb to be read by unity
        AlterColorRYB = AlterMaterial.color;
        AlterColorRYB = _handleColour.RandomizeRGB();
        AlterColorRGB = _handleColour.RYBToRGB(AlterColorRYB.r, AlterColorRYB.g, AlterColorRYB.b);
        AlterMaterial.color = AlterColorRGB;

        //randomizes the complementary color and converts to rgb to be read by unity
        ComplementaryColorRYB = ComplementaryMaterial.color;
        ComplementaryColorRYB = _handleColour.RandomizeRGB();
        ComplementaryColorRGB = _handleColour.RYBToRGB(ComplementaryColorRYB.r, ComplementaryColorRYB.g, ComplementaryColorRYB.b);
        ComplementaryMaterial.color = ComplementaryColorRGB;
        Debug.Log(1 - ComplementaryColorRYB.r);
        Debug.Log(1 - ComplementaryColorRYB.g);
        Debug.Log(1 - ComplementaryColorRYB.b);

        //sets the values of the slider to match the rgb of the altered color
        redSlider.value = AlterColorRYB.r;
        yellowSlider.value = AlterColorRYB.g;
        blueSlider.value = AlterColorRYB.b;
    }
    public void sliderUpdate()
    {
        //Has start function complete
        if (!isReset)
            return;

        //Save RYB values from slider
        AlterColorRYB.r = redSlider.value;
        AlterColorRYB.g = yellowSlider.value; //yellow
        AlterColorRYB.b = blueSlider.value;

        //Convert slider to RGB for display
        AlterColorRGB = _handleColour.RYBToRGB(AlterColorRYB.r, AlterColorRYB.g, AlterColorRYB.b);
        AlterMaterial.color = AlterColorRGB;


    }

    public void CheckCorrect()
    {
        //this checks to see if the Altered color value is within the tolerance range of being correct to its complementary
        if (AlterColorRYB.r <= (1 - ComplementaryColorRYB.r) + tolerance && AlterColorRYB.r >= (1 - ComplementaryColorRYB.r) - tolerance ||
            AlterColorRYB.g <= (1 - ComplementaryColorRYB.g) + tolerance && AlterColorRYB.g >= (1 - ComplementaryColorRYB.g) - tolerance ||
            AlterColorRYB.b <= (1 - ComplementaryColorRYB.b) + tolerance && AlterColorRYB.b >= (1 - ComplementaryColorRYB.b) - tolerance)
        {
            setUp();// if correct run set up again and repeat the game
        }
    }

    void Update()
    {
        //sets the result color to be the sum of the 1 - (Alter + Complementary) to get close to white as possible
        ResultColorRYB.r = 1 -(AlterColorRYB.r + ComplementaryColorRYB.r);
        ResultColorRYB.g = 1 -(AlterColorRYB.g + ComplementaryColorRYB.g);
        ResultColorRYB.b = 1 -(AlterColorRYB.b + ComplementaryColorRYB.b);
        ResultColorRGB = _handleColour.RYBToRGB(ResultColorRYB.r, ResultColorRYB.g, ResultColorRYB.b);
        ResultMaterial.color = ResultColorRGB;
    }
}
