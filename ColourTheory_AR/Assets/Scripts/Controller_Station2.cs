using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller_Station2 : MonoBehaviour
{

    //---- Utility Scripts ----//
    [Header("Utility Scripts")]
    MaterialAnimations _materialAnimator;


    //---- Colour Flashing Controls ----//
    [Header("Flashing Controls")]
    [Range(0.0f, 1.0f)]
    public float flashAmplitude = 0.5f;
    [Range(0.0f, 1.0f)]
    public float flashOffset = 1f;
    [Range(0, 10)]
    public int flashSpeed = 5;

    //---- Declare Colour Wheel Game Objects and Mesh Renderers ----//
    [Header("Colour Wheel")]
    public GameObject colourWheel;
    public List<GameObject> colourWheelPieces = new List<GameObject>(12);
    public List<Renderer> colourWheelRenderers = new List<Renderer>(12);
    //---- Declare Colour Wheel Materials (Drag In 12) ----//
    public List<Material> colourWheelMats = new List<Material>(12);


    //---- Variables ----//
    int currentStep = 1;    // Indicates which step they are one
                            // 1 - Hue
                            // 2 - Saturation
                            // 3 - Value
                            // 4 - Tints/Shades/Tones
    public Canvas Station2_UI;

    public Button startButton;
    public Button nextButton;
    public Button prevButton;
    public GameObject headerTextBackground;
    public Text headerText;
    public Slider universalSlider;
    public Slider intensitySlider;
    public Text hueDescription;
    public Text saturationDescription;
    public Text valueDescription;
    public Text tintDescription;
    public Text toneDescription;
    public Text shadeDescription;
    public GameObject StartUI;
    public GameObject textBackground;
    public GameObject CompleteUI;


    // Start is called before the first frame update
    void Start()
    {
        //---- Get Utility Scripts ----//
        _materialAnimator = this.GetComponent<MaterialAnimations>();

        //---- Set Default Parameters ----//
        setDefaults();

        //---- Get Colour Wheel Game Objects and Mesh Renderers ----//
        setWheelPieces();
        setWheelRenderers();

        //---- Set Materials on Pieces ----//
        ResetDefaultColours();

    }

    public void changeStep(bool increment)
    {
        ResetDefaultColours();

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
            case 7: //Learning Module Complete
                CompleteStep();
                break;
            default: //Otherwise
                break;
        }
    }

    void setDefaults()
    {
        currentStep = 1;
        flashAmplitude = 0.5f;
        flashOffset = 1f;
        flashSpeed = 5;

        StartUI.gameObject.SetActive(true);

        startButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(false);
        textBackground.gameObject.SetActive(false);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }

    void setWheelPieces()
    {
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("0_Red").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("1_Red-Orange").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("2_Orange").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("3_Yellow-Orange").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("4_Yellow").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("5_Yellow-Green").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("6_Green").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("7_Blue-Green").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("8_Blue").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("9_Blue-Purple").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("10_Purple").GetChild(0).gameObject);
        colourWheelPieces.Add(colourWheel.gameObject.transform.Find("11_Red-Purple").GetChild(0).gameObject);
    }

    void setWheelRenderers()
    {      
        colourWheelRenderers.Add(colourWheelPieces[0].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[1].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[2].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[3].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[4].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[5].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[6].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[7].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[8].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[9].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[10].GetComponent<MeshRenderer>());
        colourWheelRenderers.Add(colourWheelPieces[11].GetComponent<MeshRenderer>());
    }

    void ResetDefaultColours()
    {
        //---- Set Materials on Pieces ----//
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            colourWheelRenderers[i].material = colourWheelMats[i];
        }
    }
    float getUniversalValue()
    {
        return universalSlider.value;
    }
    float getIntensityValue()
    {
        return intensitySlider.value;
    }


    public void HueStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        headerText.text = "HUE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(true);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void SaturationStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SATURATION";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(true);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void ValueStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "VALUE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(true);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void TintStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "TINT";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(true);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void ToneStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "TONE";

        intensitySlider.gameObject.SetActive(true);
        universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(true);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void ShadeStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SHADE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(true);

        CompleteUI.gameObject.SetActive(false);
    }
    public void CompleteStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        headerText.text = "COMPLETE";

        intensitySlider.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(false);
        textBackground.gameObject.SetActive(false);
        hueDescription.gameObject.SetActive(false);
        saturationDescription.gameObject.SetActive(false);
        valueDescription.gameObject.SetActive(false);
        tintDescription.gameObject.SetActive(false);
        toneDescription.gameObject.SetActive(false);
        shadeDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(true);
    }

    void SaturationChanged()
    {
        for(int i = 0; i < colourWheel.transform.childCount; i++)
        {
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            colourWheelRenderers[i].material.color = Color.HSVToRGB(H, getUniversalValue(), V);
        }
    }
    void ValueChanged()
    {
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            colourWheelRenderers[i].material.color = Color.HSVToRGB(H, S, getUniversalValue());
        }
    }
    void TintChanged()
    {
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.white, getUniversalValue()); 
        }
    }
    void ToneChanged()
    {
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            Color grey = new Color(getIntensityValue(), getIntensityValue(), getIntensityValue());
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, grey, getUniversalValue());
        }
    }
    void ShadeChanged()
    {
        for (int i = 0; i < colourWheel.transform.childCount; i++)
        {
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.black, getUniversalValue());
        }
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
        //_materialAnimator.FlashingAlpha(redRenderer, flashAmplitude, flashSpeed, flashOffset);
    }
}
