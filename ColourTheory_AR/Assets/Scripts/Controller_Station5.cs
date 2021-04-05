using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller_Station5 : MonoBehaviour
{

    //---- Utility Scripts ----//
    [Header("Utility Scripts")]
    //MaterialAnimations _materialAnimator;
    //ColourWheel _colourWheel;
    HandleColour _handleColour;

    //---- Colour Flashing Controls ----//
    [Header("Flashing Controls")]
    [Range(0.0f, 1.0f)]
    public float flashAmplitude = 0.5f;
    [Range(0.0f, 1.0f)]
    public float flashOffset = 1f;
    [Range(0, 10)]
    public int flashSpeed = 5;

    //public List<GameObject> colourWheelPieces = new List<GameObject>(12);
    //public List<Renderer> colourWheelRenderers = new List<Renderer>(12);
    //---- Declare Colour Wheel Materials (Drag In 12) ----//
    //public List<Material> colourWheelMats = new List<Material>(12);


    //---- Variables ----//
    int currentStep = 1;    // Indicates which step they are one
                            // 1 - Hue
                            // 2 - Saturation
                            // 3 - Value
                            // 4 - Tints/Shades/Tones
    //public GameObject gameUI;
    public Canvas Station5_UI;

    public Button startButton;
    public Button nextButton;
    public Button prevButton;
    public GameObject headerTextBackground;
    public Text headerText;
    public Slider RedCyanSlider;
    public Slider GreenYellowSlider;
    public Slider BlueMagentaSlider;
    public Slider GreySlider;
    public Text hueDescription;
    public Text saturationDescription;
    public Text valueDescription;
    public Text tintDescription;
    public Text toneDescription;
    public Text shadeDescription;
    public GameObject StartUI;
    public GameObject textBackground;
    public GameObject CompleteUI;
    public Material mixingMaterial;


    // Start is called before the first frame update
    void Start()
    {
        //---- Get Utility Scripts ----//
        //_materialAnimator = this.GetComponent<MaterialAnimations>();
        //_colourWheel = this.GetComponent<ColourWheel>();

        //---- Set Default Parameters ----//
        setDefaults();

        //---- Get Colour Wheel Game Objects and Mesh Renderers ----//
        //_colourWheel.setWheelPieces(colourWheelPieces);
        //_colourWheel.setWheelRenderers(colourWheelPieces, colourWheelRenderers);

        //---- Set Materials on Pieces ----//
        //_colourWheel.ResetDefaultColours(colourWheelRenderers);

    }

    public void changeStep(bool increment)
    {
        //_colourWheel.ResetDefaultColours(colourWheelRenderers);

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
            case 1: //RGB Step
                RGBstep();
                break;
            case 2: //RYB Step
                RYBstep();
                break;
            case 3: //CMYK Step
                CMYKstep();
                break;
            case 4: //Complete Step
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

        mixingMaterial.color = new Color(0, 0, 0);

        StartUI.gameObject.SetActive(true);

        startButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        RedCyanSlider.gameObject.SetActive(false);
        GreenYellowSlider.gameObject.SetActive(false);
        BlueMagentaSlider.gameObject.SetActive(false);
        GreySlider.gameObject.SetActive(false);

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

    float getRedCyanValue()
    {
        return RedCyanSlider.value;
    }
    float getGreenYellowValue()
    {
        return GreenYellowSlider.value;
    }
    float getBlueMagentaValue()
    {
        return BlueMagentaSlider.value;
    }
    float getGreyValue()
    {
        return GreySlider.value;
    }


    public void RGBstep()
    {
        HueChanged();
        StartUI.gameObject.SetActive(false);

        mixingMaterial.color = new Color(0, 0, 0);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        headerText.text = "ADDITIVE-RGB";

        RedCyanSlider.gameObject.SetActive(true);
        GreenYellowSlider.gameObject.SetActive(true);
        BlueMagentaSlider.gameObject.SetActive(true);
        GreySlider.gameObject.SetActive(false);

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
    public void RYBstep()
    {
        SaturationChanged();
        StartUI.gameObject.SetActive(false);

        mixingMaterial.color = new Color(0, 0, 0);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SUBTRACTIVE-RYB";

        RedCyanSlider.gameObject.SetActive(true);
        GreenYellowSlider.gameObject.SetActive(true);
        BlueMagentaSlider.gameObject.SetActive(true);
        GreySlider.gameObject.SetActive(false);

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
    public void CMYKstep()
    {
        ValueChanged();
        StartUI.gameObject.SetActive(false);

        mixingMaterial.color = new Color(0, 0, 0);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SUBTRACTIVE-CYMK";

        RedCyanSlider.gameObject.SetActive(true);;
        GreenYellowSlider.gameObject.SetActive(true);
        BlueMagentaSlider.gameObject.SetActive(true);
        GreySlider.gameObject.SetActive(true);

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
        //TintChanged();
        //StartUI.gameObject.SetActive(false);
        //
        //startButton.gameObject.SetActive(false);
        //prevButton.gameObject.SetActive(true);
        //nextButton.gameObject.SetActive(true);
        //headerText.text = "TINT";
        //
        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(true);
        //universalSlider.transform.Find("TextLeft").GetComponent<Text>().text = "Less";
        //universalSlider.transform.Find("TextRight").GetComponent<Text>().text = "More";
        //
        //headerTextBackground.SetActive(true);
        //textBackground.gameObject.SetActive(true);
        //hueDescription.gameObject.SetActive(false);
        //saturationDescription.gameObject.SetActive(false);
        //valueDescription.gameObject.SetActive(false);
        //tintDescription.gameObject.SetActive(true);
        //toneDescription.gameObject.SetActive(false);
        //shadeDescription.gameObject.SetActive(false);
        //
        //CompleteUI.gameObject.SetActive(false);
    }
    public void ToneStep()
    {
        //ToneChanged();
        //StartUI.gameObject.SetActive(false);
        //
        //startButton.gameObject.SetActive(false);
        //prevButton.gameObject.SetActive(true);
        //nextButton.gameObject.SetActive(true);
        //headerText.text = "TONE";
        //
        //intensitySlider.gameObject.SetActive(true);
        //universalSlider.gameObject.SetActive(true);
        //universalSlider.transform.Find("TextLeft").GetComponent<Text>().text = "Less";
        //universalSlider.transform.Find("TextRight").GetComponent<Text>().text = "More";
        //
        //headerTextBackground.SetActive(true);
        //textBackground.gameObject.SetActive(true);
        //hueDescription.gameObject.SetActive(false);
        //saturationDescription.gameObject.SetActive(false);
        //valueDescription.gameObject.SetActive(false);
        //tintDescription.gameObject.SetActive(false);
        //toneDescription.gameObject.SetActive(true);
        //shadeDescription.gameObject.SetActive(false);
        //
        //CompleteUI.gameObject.SetActive(false);
    }
    public void ShadeStep()
    {
       // ShadeChanged();
       // StartUI.gameObject.SetActive(false);
       //
       // startButton.gameObject.SetActive(false);
       // prevButton.gameObject.SetActive(true);
       // nextButton.gameObject.SetActive(true);
       // headerText.text = "SHADE";
       //
       // intensitySlider.gameObject.SetActive(false);
       // universalSlider.gameObject.SetActive(true);
       // universalSlider.transform.Find("TextLeft").GetComponent<Text>().text = "Less";
       // universalSlider.transform.Find("TextRight").GetComponent<Text>().text = "More";
       //
       // headerTextBackground.SetActive(true);
       // textBackground.gameObject.SetActive(true);
       // hueDescription.gameObject.SetActive(false);
       // saturationDescription.gameObject.SetActive(false);
       // valueDescription.gameObject.SetActive(false);
       // tintDescription.gameObject.SetActive(false);
       // toneDescription.gameObject.SetActive(false);
       // shadeDescription.gameObject.SetActive(true);
       //
       // CompleteUI.gameObject.SetActive(false);
    }

    public void GameStep()
    {
       // _colourWheel.getColourWheel().gameObject.SetActive(false);
       // Station5_UI.gameObject.SetActive(false);
       // gameUI.gameObject.SetActive(true);
    }

    public void CompleteStep()
    {
        Station5_UI.gameObject.SetActive(true);
        //gameUI.gameObject.SetActive(false);

        mixingMaterial.color = new Color(0, 0, 0);

        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        headerText.text = "COMPLETE";

        RedCyanSlider.gameObject.SetActive(false);

        GreenYellowSlider.gameObject.SetActive(false);

        BlueMagentaSlider.gameObject.SetActive(false);

        GreySlider.gameObject.SetActive(false);

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

    void HueChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //colourWheelRenderers[i].material.color = Color.HSVToRGB(getUniversalValue(), 1.0f, 1.0f);
        //}
    }
    void SaturationChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //float H, S, V;
        //    //Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
        //    //colourWheelRenderers[i].material.color = Color.HSVToRGB(H, getUniversalValue(), V);
        //}
    }
    void ValueChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //float H, S, V;
        //    //Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
        //    //colourWheelRenderers[i].material.color = Color.HSVToRGB(H, S, getUniversalValue());
        //}
    }
    void TintChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.white, getUniversalValue());
        //}
    }
    void ToneChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //Color grey = new Color(getIntensityValue(), getIntensityValue(), getIntensityValue());
        //    //colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, grey, getUniversalValue());
        //}
    }
    void ShadeChanged()
    {
        //for (int i = 0; i < colourWheelRenderers.Count; i++)
        //{
        //    //colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.black, getUniversalValue());
        //}
    }

    public void OnSliderChange()
    {
        switch (currentStep)
        {
            case 1: //Hue Step
                HueChanged();
                break;
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
