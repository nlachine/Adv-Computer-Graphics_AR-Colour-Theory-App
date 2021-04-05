using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller_Station1 : MonoBehaviour
{

    //---- Utility Scripts ----//
    [Header("Utility Scripts")]
    MaterialAnimations _materialAnimator;
    ColourWheel _colourWheel;


    //---- Colour Flashing Controls ----//
    [Header("Flashing Controls")]
    [Range(0.0f, 1.0f)]
    public float flashAmplitude = 0.5f;
    [Range(0.0f, 1.0f)]
    public float flashOffset = 1f;
    [Range(0, 10)]
    public int flashSpeed = 5;

    public List<GameObject> colourWheelPieces = new List<GameObject>(12);
    public List<Renderer> colourWheelRenderers = new List<Renderer>(12);
    //---- Declare Colour Wheel Materials (Drag In 12) ----//
    public List<Material> colourWheelMats = new List<Material>(12);


    //---- Variables ----//
    int currentStep = 0;    // Indicates which step they are one
                            // 1 - Primary Colours
                            // 2 - Secondary Colours
                            // 3 - Tertiary Colours
                            // 4 - Warm & Cool Colours
    public Canvas Station1_UI;

    public Button startButton;
    public Button nextButton;
    public Button prevButton;
    public GameObject headerTextBackground;
    public Text headerText;
    public Slider universalSlider;
    public Slider intensitySlider;
    public Text PrimaryColourDescription;
    public Text SecondaryColourDescription;
    public Text TertiaryColourDescription;
    public Text WarmColourDescription;
    public Text CoolColourDescription;
    public Text gameDescription;
    public GameObject StartUI;
    public GameObject textBackground;
    public GameObject CompleteUI;
    

    //Station 1 Specific
    public GameObject MinigameObjectHolder;
    public List<GameObject> MinigameObjects;

    // Start is called before the first frame update
    void Start()
    {
        //---- Get Utility Scripts ----//
        _materialAnimator = this.GetComponent<MaterialAnimations>();
        _colourWheel = this.GetComponent<ColourWheel>();

        //---- Set Default Parameters ----//
        setDefaults();

        //---- Get Colour Wheel Game Objects and Mesh Renderers ----//
        _colourWheel.setWheelPieces(colourWheelPieces);
        _colourWheel.setWheelRenderers(colourWheelPieces, colourWheelRenderers);

        //---- Set Materials on Pieces ----//
        _colourWheel.ResetDefaultColours(colourWheelRenderers);
    }

    public void changeStep(bool increment)
    {
        _colourWheel.ResetDefaultColours(colourWheelRenderers);

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
                PrimaryColourStep();
                break;
            case 2: //Saturation Step
                SecondaryColourStep();
                break;
            case 3: //Value Step
                TertiaryColourStep();
                break;
            case 4: //Tint Step
                WarmColourStep();
                break;
            case 5: //Tone Step
                CoolColourStep();
                break;
            case 6: //Shade Step
                GameStep();
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
        currentStep = 0;
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
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);
        textBackground.transform.Find("btnGame").gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);
        textBackground.transform.Find("btnGame").gameObject.SetActive(false);

    }

    float getUniversalValue()
    {
        return universalSlider.value;
    }
    float getIntensityValue()
    {
        return intensitySlider.value;
    }


    public void PrimaryColourStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        headerText.text = "PRIMARY COLOURS";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(true);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);

        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            if (i != 0 && i != 4 && i != 8)
                colourWheelRenderers[i].material.color = Color.white;
        }
    }
    public void SecondaryColourStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "SECONDARY COLOURS";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(true);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);

        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            if (i != 0 && i != 4 && i != 8 && i != 2 && i != 6 && i != 10)
                colourWheelRenderers[i].material.color = Color.white;
        }
    }
    public void TertiaryColourStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "TERTIARY COLOURS";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(true);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);
    }
    public void WarmColourStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "WARM COLOURS";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(true);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);

        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            if (i > 5)
                colourWheelRenderers[i].material.color = Color.white;
        }
    }
    public void CoolColourStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "COOL COLOURS";

        //intensitySlider.gameObject.SetActive(true);
        //universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(true);
        gameDescription.gameObject.SetActive(false);
        textBackground.transform.Find("btnGame").gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(false);

        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            if (i <= 5)
                colourWheelRenderers[i].material.color = Color.white;
        }
    }
    public void GameStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "GAME TIME";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(true);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(true);
        textBackground.transform.Find("btnGame").gameObject.SetActive(true);

        CompleteUI.gameObject.SetActive(false);

        //Station 1 Specific
        MinigameObjectHolder.SetActive(true);
        textBackground.transform.Find("btnGame").gameObject.SetActive(true);


        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            if (i != 0 && i != 4 && i != 8)
                colourWheelRenderers[i].material.color = Color.white;
        }

        foreach (GameObject item in MinigameObjects)
        {
            item.SetActive(true);
            item.transform.localPosition = item.GetComponent<MouseClickAndDrag>().getOriginalPos();
        }
    }
    public void CompleteStep()
    {
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        headerText.text = "COMPLETE";

        //intensitySlider.gameObject.SetActive(false);
        //universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(false);
        textBackground.gameObject.SetActive(false);
        PrimaryColourDescription.gameObject.SetActive(false);
        SecondaryColourDescription.gameObject.SetActive(false);
        TertiaryColourDescription.gameObject.SetActive(false);
        WarmColourDescription.gameObject.SetActive(false);
        CoolColourDescription.gameObject.SetActive(false);
        gameDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(true);
    }

    public void startGame()
    {
        textBackground.gameObject.SetActive(false);
        textBackground.transform.Find("btnGame").gameObject.SetActive(false);
    }

    void SaturationChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            colourWheelRenderers[i].material.color = Color.HSVToRGB(H, getUniversalValue(), V);
        }
    }
    void ValueChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            float H, S, V;
            Color.RGBToHSV(colourWheelMats[i].color, out H, out S, out V);
            colourWheelRenderers[i].material.color = Color.HSVToRGB(H, S, getUniversalValue());
        }
    }
    void TintChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.white, getUniversalValue());
        }
    }
    void ToneChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            Color grey = new Color(getIntensityValue(), getIntensityValue(), getIntensityValue());
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, grey, getUniversalValue());
        }
    }
    void ShadeChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            colourWheelRenderers[i].material.color = Color.Lerp(colourWheelMats[i].color, Color.black, getUniversalValue());
        }
    }


    void Update()
    {
        switch (currentStep)
        {
            case 1: //Primary Step
                _materialAnimator.FlashingAlpha(colourWheelRenderers[0], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[4], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[8], flashAmplitude, flashSpeed, flashOffset);
                break;
            case 2: //Secondary Step
                _materialAnimator.FlashingAlpha(colourWheelRenderers[2], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[6], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[10], flashAmplitude, flashSpeed, flashOffset);
                break;
            case 3: //Tertiary Step
                _materialAnimator.FlashingAlpha(colourWheelRenderers[1], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[3], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[5], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[7], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[9], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[11], flashAmplitude, flashSpeed, flashOffset);
                break;
            case 4: //Tint Step
                _materialAnimator.FlashingAlpha(colourWheelRenderers[0], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[1], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[2], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[3], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[4], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[5], flashAmplitude, flashSpeed, flashOffset);
                break;
            case 5: //Tone Step
                _materialAnimator.FlashingAlpha(colourWheelRenderers[6], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[7], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[8], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[9], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[10], flashAmplitude, flashSpeed, flashOffset);
                _materialAnimator.FlashingAlpha(colourWheelRenderers[11], flashAmplitude, flashSpeed, flashOffset);
                break;
            default: //Otherwise
                break;
        }
    }
}
