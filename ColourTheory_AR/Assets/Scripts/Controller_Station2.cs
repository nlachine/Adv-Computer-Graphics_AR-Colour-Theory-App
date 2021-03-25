using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller_Station2 : MonoBehaviour
{

    //---- Utility Scripts ----//
    [Header("Utility Scripts")]
    MaterialAnimations materialAnimator;


    //---- Colour Flashing Controls ----//
    [Header("Flashing Controls")]
    [Range(0.0f, 1.0f)]
    public float flashAmplitude = 0.5f;
    [Range(0.0f, 1.0f)]
    public float flashOffset = 1f;
    [Range(0, 10)]
    public int flashSpeed = 5;

    //---- Declare Colour Wheel Game Objects and Mesh Renderers ----//
    public GameObject colourWheel;
    [Header("CW Pieces")]
    GameObject redPiece;
    Renderer redRenderer;
    GameObject redOrangePiece;
    Renderer redOrangeRenderer;
    GameObject orangePiece;
    Renderer orangeRenderer;
    GameObject yellowOrangePiece;
    Renderer yellowOrangeRenderer;
    GameObject yellowPiece;
    Renderer yellowRenderer;
    GameObject yellowGreenPiece;
    Renderer yellowGreenRenderer;
    GameObject greenPiece;
    Renderer greenRenderer;
    GameObject blueGreenPiece;
    Renderer blueGreenRenderer;
    GameObject bluePiece;
    Renderer blueRenderer;
    GameObject bluePurplePiece;
    Renderer bluePurpleRenderer;
    GameObject purplePiece;
    Renderer purpleRenderer;
    GameObject redPurplePiece;
    Renderer redPurpleRenderer;

    //---- Declare Colour Wheel Materials (Drag In) ----//
    [Header("CW Materials")]
    public List<Material> colourWheelMats;


    //---- Variables ----//
    int currentStep = 1;    // Indicates which step they are one
                            // 1 - Hue
                            // 2 - Saturation
                            // 3 - Value
                            // 4 - Tints/Shades/Tones
    public Button nextButton;
    public Button prevButton;
    public Text headerText;
    public Slider universalSlider;
    public Slider intensitySlider;
    public Text hueDescription;
    public Text saturationDescription;
    public Text valueDescription;
    public Text tintDescription;
    public Text toneDescription;
    public Text shadeDescription;


    // Start is called before the first frame update
    void Start()
    {
        //---- Get Utility Scripts ----//
        materialAnimator = this.GetComponent<MaterialAnimations>();

        //---- Set Default Parameters ----//
        flashAmplitude = 0.5f;
        flashOffset = 1f;
        flashSpeed = 5;

        prevButton.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);
        intensitySlider.gameObject.SetActive(false);

        //---- Get Colour Wheel Game Objects and Mesh Renderers ----//
        redPiece = colourWheel.gameObject.transform.Find("1_Red").GetChild(0).gameObject;
        redOrangePiece = colourWheel.gameObject.transform.Find("2_Red-Orange").GetChild(0).gameObject;
        orangePiece = colourWheel.gameObject.transform.Find("3_Orange").GetChild(0).gameObject;
        yellowOrangePiece = colourWheel.gameObject.transform.Find("4_Yellow-Orange").GetChild(0).gameObject;
        yellowPiece = colourWheel.gameObject.transform.Find("5_Yellow").GetChild(0).gameObject;
        yellowGreenPiece = colourWheel.gameObject.transform.Find("6_Yellow-Green").GetChild(0).gameObject;
        greenPiece = colourWheel.gameObject.transform.Find("7_Green").GetChild(0).gameObject;
        blueGreenPiece = colourWheel.gameObject.transform.Find("8_Blue-Green").GetChild(0).gameObject;
        bluePiece = colourWheel.gameObject.transform.Find("9_Blue").GetChild(0).gameObject;
        bluePurplePiece = colourWheel.gameObject.transform.Find("10_Blue-Purple").GetChild(0).gameObject;
        purplePiece = colourWheel.gameObject.transform.Find("11_Purple").GetChild(0).gameObject;
        redPurplePiece = colourWheel.gameObject.transform.Find("12_Red-Purple").GetChild(0).gameObject;

        redRenderer = redPiece.GetComponent<MeshRenderer>();
        redOrangeRenderer = redOrangePiece.GetComponent<MeshRenderer>();
        orangeRenderer = orangePiece.GetComponent<MeshRenderer>();
        yellowOrangeRenderer = yellowOrangePiece.GetComponent<MeshRenderer>();
        yellowRenderer = yellowPiece.GetComponent<MeshRenderer>();
        yellowGreenRenderer = yellowGreenPiece.GetComponent<MeshRenderer>();
        greenRenderer = greenPiece.GetComponent<MeshRenderer>();
        blueGreenRenderer = blueGreenPiece.GetComponent<MeshRenderer>();
        blueRenderer = bluePiece.GetComponent<MeshRenderer>();
        bluePurpleRenderer = bluePurplePiece.GetComponent<MeshRenderer>();
        purpleRenderer = purplePiece.GetComponent<MeshRenderer>();
        redPurpleRenderer = redPurplePiece.GetComponent<MeshRenderer>();

        //---- Set Materials on Pieces ----//
        redRenderer.material = colourWheelMats[0];
        redOrangeRenderer.material = colourWheelMats[1];
        orangeRenderer.material = colourWheelMats[2];
        yellowOrangeRenderer.material = colourWheelMats[3];
        yellowRenderer.material = colourWheelMats[4];
        yellowGreenRenderer.material = colourWheelMats[5];
        greenRenderer.material = colourWheelMats[6];
        blueGreenRenderer.material = colourWheelMats[7];
        blueRenderer.material = colourWheelMats[8];
        bluePurpleRenderer.material = colourWheelMats[9];
        purpleRenderer.material = colourWheelMats[10];
        redPurpleRenderer.material = colourWheelMats[11];

    }

    public void changeStep(bool increment)
    {
        if (increment)
        {
            currentStep++;
        }
        else
        {
            currentStep--;
        }

        switch (currentStep)
        {
            case 1: //Hue Step
                HueStep();
                break;
            case 2: //Saturation Step
                SaturationStep();
                break;
            case 3: //Value Step
                ValueStep();
                break;
            case 4: //Tint Step
                TintStep();
                break;
            case 5: //Tone Step
                ToneStep();
                break;
            case 6: //Shade Step
                ShadeStep();
                break;
            default: //Otherwise
                break;
        }
    }
    void HueStep()
    {
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        headerText.text = "HUE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        hueDescription.gameObject.SetActive(true);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);
    }
    void SaturationStep()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SATURATION";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(true);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

    }
    void ValueStep()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "VALUE";

        intensitySlider.gameObject.SetActive(false);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(true);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

    }
    void TintStep()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "TINT";

        intensitySlider.gameObject.SetActive(true);
        universalSlider.gameObject.SetActive(true);

        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(true);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

    }
    void ToneStep()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "TONE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(true);
        shadeDescription.gameObject.SetActive(false);

    }
    void ShadeStep()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        headerText.text = "SHADE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(true);

    }

    void SaturationChanged()
    {
        float universalValue = universalSlider.value;
        Debug.Log(colourWheel.transform.childCount);
        for(int i = 0; i < colourWheel.transform.childCount; i++)
        {
            Renderer tempRenderer = colourWheel.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>();
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            tempRenderer.material.color = Color.HSVToRGB(H, universalValue, V);
        }
    }
    void ValueChanged()
    {
        float universalValue = universalSlider.value;
        Debug.Log(colourWheel.transform.childCount);
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            Renderer tempRenderer = colourWheel.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>();
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            tempRenderer.material.color = Color.HSVToRGB(H, S, universalValue);
        }
    }
    void TintChanged()
    {
        //float intensityValue = intensitySlider.value;
        //float universalValue = universalSlider.value;
        //Debug.Log(colourWheel.transform.childCount);
        //for (int i = 0; i < colourWheel.transform.childCount; i++)
        //{
        //    Color grey = new Color(intensityValue * universalValue, intensityValue * universalValue, intensityValue * universalValue);
        //    Renderer tempRenderer = colourWheel.transform.GetChild(i).transform.GetChild(0).GetComponent<MeshRenderer>();
        //    tempRenderer.material.color = colourWheelMats[i].color + grey;
        //}
    }
    void ToneChanged()
    {
    }
    void ShadeChanged()
    {
    }

    public void OnSliderChange()
    {
        switch (currentStep)
        {
            case 2: //Saturation Step
                SaturationChanged();
                break;
            case 3: //Value Step
                ValueChanged();
                break;
            case 4: //Tint Step
                TintChanged();
                break;
            case 5: //Tone Step
                ToneChanged();
                break;
            case 6: //Shade Step
                ShadeChanged();
                break;
            default: //Otherwise
                break;
        }
    }

    void Update()
    {
        //---- Example on flashing colour. ----//
        //materialAnimator.FlashingAlpha(redRenderer, flashAmplitude, flashSpeed, flashOffset);
    }
}
