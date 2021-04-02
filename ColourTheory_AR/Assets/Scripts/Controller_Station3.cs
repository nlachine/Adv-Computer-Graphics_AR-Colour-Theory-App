using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Controller_Station3 : MonoBehaviour
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
    int currentStep = 1;    // Indicates which step they are one
                            // 1 - Hue
                            // 2 - Saturation
                            // 3 - Value
                            // 4 - Tints/Shades/Tones
    int colourWheelIndex = 0; //Indicates which piece of the colour wheel to base the scheme on.
    public Canvas Station3_UI;
    public GameObject gameUI;
    public Button startButton;
    public Button nextButton;
    public Button prevButton;
    public GameObject headerTextBackground;
    public Text headerText;
    public Slider universalSlider;
    public Button switchButton;
    public Text monochromaticDescription;
    public Text complimentaryDescription;
    public Text analogousDescription;
    public GameObject StartUI;
    public GameObject textBackground;
    public GameObject CompleteUI;

    //Quiz Variables
    public SchemeQuestion[] questions;
    private static List<SchemeQuestion> unansweredQuestions;
    private SchemeQuestion currentQuestion;

    public GameObject quizObj1, quizObj2, quizObj3;
    public int correctCount, questionGoal;
    public Text outcomeText;

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

        //---- Set Questions ----//
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<SchemeQuestion>();
        }
        GetCurrentQuestion();

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
            case 1: //Monochromatic Step
                MonochromaticStep();
                break;
            case 2: //Complimentary Step
                ComplimentaryStep();
                break;
            case 3: //Analgous Step
                AnalogousStep();
                break;
            case 4: //Game Step
                GameStep();
                break;
            case 5: //Learning Module Complete
                CompleteStep();
                break;
            default: //Otherwise
                break;
        }
    }

    void setDefaults()
    {
        currentStep = 1;
        colourWheelIndex = 0;
        flashAmplitude = 0.5f;
        flashOffset = 1f;
        flashSpeed = 5;

        correctCount = 0;
        outcomeText.text = correctCount + "/" + questionGoal + " Correct";

        StartUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
        quizObj1.gameObject.SetActive(false);
        quizObj2.gameObject.SetActive(false);
        quizObj3.gameObject.SetActive(false);

        startButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);

        switchButton.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);
        universalSlider.transform.Find("TextLeft").transform.GetComponent<Text>().text = "";
        universalSlider.transform.Find("TextRight").transform.GetComponent<Text>().text = "";

        headerTextBackground.SetActive(false);
        textBackground.gameObject.SetActive(false);
        monochromaticDescription.gameObject.SetActive(false);
        complimentaryDescription.gameObject.SetActive(false);
        analogousDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }

    float getUniversalValue()
    {
        return universalSlider.value;
    }

    public void MonochromaticStep()
    {
        MonochromaticChanged();
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "MONOCHROMATIC";

        switchButton.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(true);
        universalSlider.transform.Find("TextLeft").transform.GetComponent<Text>().text = "";
        universalSlider.transform.Find("TextRight").transform.GetComponent<Text>().text = "";

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        monochromaticDescription.gameObject.SetActive(true);
        complimentaryDescription.gameObject.SetActive(false);
        analogousDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void ComplimentaryStep()
    {
        switchScheme();
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "COMPLIMENTARY";

        switchButton.gameObject.SetActive(true);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        monochromaticDescription.gameObject.SetActive(false);
        complimentaryDescription.gameObject.SetActive(true);
        analogousDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(false);
    }
    public void AnalogousStep()
    {
        switchScheme();
        StartUI.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        headerText.text = "ANALOGOUS";

        switchButton.gameObject.SetActive(true);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(true);
        monochromaticDescription.gameObject.SetActive(false);
        complimentaryDescription.gameObject.SetActive(false);
        analogousDescription.gameObject.SetActive(true);

        CompleteUI.gameObject.SetActive(false);
    }

    public void GameStep()
    {
        StartUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        quizObj1.gameObject.SetActive(true);
        quizObj2.gameObject.SetActive(true);
        quizObj3.gameObject.SetActive(true);
        _colourWheel.getColourWheel().SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        headerText.text = "QUIZ";

        switchButton.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(true);
        textBackground.gameObject.SetActive(false);
        monochromaticDescription.gameObject.SetActive(false);
        complimentaryDescription.gameObject.SetActive(false);
        analogousDescription.gameObject.SetActive(true);

        CompleteUI.gameObject.SetActive(false);
    }
    public void CompleteStep()
    {
        StartUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        quizObj1.gameObject.SetActive(false);
        quizObj2.gameObject.SetActive(false);
        quizObj3.gameObject.SetActive(false);

        startButton.gameObject.SetActive(false);
        prevButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        switchButton.gameObject.SetActive(false);
        universalSlider.gameObject.SetActive(false);

        headerTextBackground.SetActive(false);
        textBackground.gameObject.SetActive(false);
        monochromaticDescription.gameObject.SetActive(false);
        complimentaryDescription.gameObject.SetActive(false);
        analogousDescription.gameObject.SetActive(false);

        CompleteUI.gameObject.SetActive(true);
    }

    void GetCurrentQuestion()
    {
        int rand = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[rand];

        quizObj1.GetComponent<MeshRenderer>().material.color = currentQuestion.col1;
        quizObj2.GetComponent<MeshRenderer>().material.color = currentQuestion.col2;
        quizObj3.GetComponent<MeshRenderer>().material.color = currentQuestion.col3;

        unansweredQuestions.RemoveAt(rand);
    }

    public void checkAnswer(string answer)
    {
        if (answer == currentQuestion.answer)
        {
            correctCount += 1;
            StartCoroutine(correct(1.0f));
            if (correctCount >= questionGoal)
            {

                CompleteStep();
                return;
            }
            GetCurrentQuestion();
        }
        else
        {
            StartCoroutine(tryAgain(1.0f));
            Debug.Log("wrong");
        }
    }

    IEnumerator tryAgain(float waitTime)
    {
        outcomeText.text = "Try Again";
        outcomeText.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        outcomeText.text = correctCount + "/" + questionGoal + " Correct";
        outcomeText.color = Color.white;
    }
    IEnumerator correct(float waitTime)
    {
        outcomeText.text = "Correct";
        outcomeText.color = Color.green;
        yield return new WaitForSeconds(waitTime);
        outcomeText.text = correctCount + "/" + questionGoal + " Correct";
        outcomeText.color = Color.white;
    }


    void MonochromaticChanged()
    {
        for (int i = 0; i < colourWheelRenderers.Count; i++)
        {
            float V = (i + 6)/ 12.0f;
            float S = 1 - ((i - 6)/ 12.0f);
            Debug.Log(S);
            colourWheelRenderers[i].material.color = Color.HSVToRGB(getUniversalValue(), S , V);
        }
    }
    void ComplimentaryChanged()
    {
        _materialAnimator.FlashingAlpha(colourWheelRenderers[colourWheelIndex], flashAmplitude, flashSpeed, flashOffset);
        int opposite = colourWheelIndex + 6;
        if (opposite >= colourWheelRenderers.Count)
            opposite -= colourWheelRenderers.Count;
        _materialAnimator.FlashingAlpha(colourWheelRenderers[opposite], flashAmplitude, flashSpeed, flashOffset);
    }
    void AnalogousChanged()
    {
        int before = colourWheelIndex - 1;
        if (before < 0)
            before += colourWheelRenderers.Count;
        _materialAnimator.FlashingAlpha(colourWheelRenderers[before], flashAmplitude, flashSpeed, flashOffset);
        _materialAnimator.FlashingAlpha(colourWheelRenderers[colourWheelIndex], flashAmplitude, flashSpeed, flashOffset);
        int after = colourWheelIndex + 1;
        if (after >= colourWheelRenderers.Count)
            after -= colourWheelRenderers.Count;
        _materialAnimator.FlashingAlpha(colourWheelRenderers[after], flashAmplitude, flashSpeed, flashOffset);
    }

    public void switchScheme() {
        colourWheelIndex += 1;
        if (colourWheelIndex >= colourWheelRenderers.Count)
            colourWheelIndex = 0;
        _colourWheel.ResetDefaultColours(colourWheelRenderers);
    }

    public void OnSliderChange()
    {
        switch (currentStep)
        {
            case 1: //Monochromatic Step
                MonochromaticChanged();
                break;
            default: //Otherwise
                break;
        }
    }

    void Update()
    {
        switch (currentStep)
        {
            case 2: //Complimentary Step
                ComplimentaryChanged();
                break;
            case 3: //Analogous Step
                AnalogousChanged();
                break;
            default: //Otherwise
                break;
        }
    }
}
