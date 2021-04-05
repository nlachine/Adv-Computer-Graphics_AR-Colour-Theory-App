using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColourMatchHSV : MonoBehaviour
{

    HandleColour _handleColour;
    public UnityEvent CompleteFunction;

    public int gameOverTotal = 3;

    [Header("Sliders")]
    public Slider hueSlider;
    public Slider satSlider;
    public Slider valSlider;
    ColorBlock hueCB;
    ColorBlock satCB;

    [Range(0.0f, 0.2f)]
    public float tolerance = 0.1f;
    bool h_correct = false;
    bool s_correct = false;
    bool v_correct = false;
    int correctCount = 0;

    [Header("Objects")]
    public GameObject matchObj;
    public GameObject alterObj;
    Material matchObjMat;
    Material alterObjMat;


    //UI Properties
    public bool helperOn = false;
    public GameObject match_img;
    public GameObject tryAgain_img;

    // Start is called before the first frame update
    void Start()
    {
        _handleColour = this.GetComponent<HandleColour>();

        //reset sliders and booleans
        h_correct = false;
        s_correct = false;
        v_correct = false;
        matchObjMat = matchObj.GetComponent<MeshRenderer>().material;
        alterObjMat = alterObj.GetComponent<MeshRenderer>().material;

        hueCB = hueSlider.colors;
        satCB = satSlider.colors;

        newMatch();
    }

    public void OnSliderChange()
    {
        alterObjMat.color = Color.HSVToRGB(hueSlider.value, satSlider.value, 1 - valSlider.value);

        hueCB.normalColor = Color.HSVToRGB(hueSlider.value, 1.0f, 1.0f);
        hueCB.selectedColor = Color.HSVToRGB(hueSlider.value, 1.0f, 1.0f);
        hueCB.highlightedColor = Color.HSVToRGB(hueSlider.value, 1.0f, 1.0f);
        hueCB.pressedColor = Color.HSVToRGB(hueSlider.value, 1.0f, 0.8f);
        hueSlider.colors = hueCB;

        satCB.normalColor = Color.HSVToRGB(hueSlider.value, satSlider.value, 1.0f);
        satCB.selectedColor = Color.HSVToRGB(hueSlider.value, satSlider.value, 1.0f);
        satCB.highlightedColor = Color.HSVToRGB(hueSlider.value, satSlider.value, 1.0f);
        satCB.pressedColor = Color.HSVToRGB(hueSlider.value, satSlider.value, 0.8f);
        satSlider.colors = satCB;
    }

    public void toggleHelper()
    {
        helperOn = !helperOn;
    }

    void newMatch()
    {
        matchObjMat.color = _handleColour.RandomizeHSV();
        alterObjMat.color = _handleColour.RandomizeHSV();

        float H, S, V;
        Color.RGBToHSV(alterObjMat.color, out H, out S, out V);
        hueSlider.value = H;
        satSlider.value = S;
        valSlider.value = V;
    }

    //check if all the values are true and display a graphic to indicate right or wrong.
    public void resetCheck()
    {
        //reset sliders and booleans
        h_correct = false;
        s_correct = false;
        v_correct = false;
        hueSlider.transform.parent.Find("Good").gameObject.SetActive(false);
        hueSlider.transform.parent.Find("Close").gameObject.SetActive(false);
        hueSlider.transform.parent.Find("Wrong").gameObject.SetActive(false);
        satSlider.transform.parent.Find("Good").gameObject.SetActive(false);
        satSlider.transform.parent.Find("Close").gameObject.SetActive(false);
        satSlider.transform.parent.Find("Wrong").gameObject.SetActive(false);
        valSlider.transform.parent.Find("Good").gameObject.SetActive(false);
        valSlider.transform.parent.Find("Close").gameObject.SetActive(false);
        valSlider.transform.parent.Find("Wrong").gameObject.SetActive(false);
    }

    public void checkMatch()
    {
        StartCoroutine(handleOutcome(1.0f));
    }


    IEnumerator handleOutcome(float waitTime)
    {
        resetCheck();

        //Log RGB values of each sphere
        Debug.Log("AS: " + alterObjMat);
        Debug.Log("MS: " + matchObjMat);

        //calculate the difference between each value of match sphere and alter sphere
        float mH, mS, mV;
        float aH, aS, aV;

        Color.RGBToHSV(matchObjMat.color, out mH, out mS, out mV);
        Color.RGBToHSV(alterObjMat.color, out aH, out aS, out aV);

        //calculate the difference between each value of match sphere and alter sphere
        float h_diff = mH - aH;
        float s_diff = mS - aS;
        float v_diff = mV - aV;
        //Debug.Log("mh:" + mH + " ms:" + mS + " mV:" + mV);
        //Debug.Log("ah:" + aH + " as:" + aS + " aV:" + aV);

        if (helperOn)
        {
            //Show Red Indicator
            if (h_diff <= tolerance && h_diff >= -tolerance)
                hueSlider.transform.parent.Find("Good").gameObject.SetActive(true);
            else if (h_diff <= tolerance * 2 && h_diff >= -tolerance * 2)
                hueSlider.transform.parent.Find("Close").gameObject.SetActive(true);
            else
                hueSlider.transform.parent.Find("Wrong").gameObject.SetActive(true);


            //Show Yellow Indicator
            if (s_diff <= tolerance && s_diff >= -tolerance)
                satSlider.transform.parent.Find("Good").gameObject.SetActive(true);
            else if (s_diff <= tolerance * 2 && s_diff >= -tolerance * 2)
                satSlider.transform.parent.Find("Close").gameObject.SetActive(true);
            else
                satSlider.transform.parent.Find("Wrong").gameObject.SetActive(true);

            //Show Blue Indicator
            if (v_diff <= tolerance && v_diff >= -tolerance)
                valSlider.transform.parent.Find("Good").gameObject.SetActive(true);
            else if (v_diff <= tolerance * 2 && v_diff >= -tolerance * 2)
                valSlider.transform.parent.Find("Close").gameObject.SetActive(true);
            else
                valSlider.transform.parent.Find("Wrong").gameObject.SetActive(true);
        }

        if (h_diff >= -tolerance && h_diff <= tolerance)
            h_correct = true;
        if (s_diff >= -tolerance && s_diff <= tolerance)
            s_correct = true;
        if (v_diff >= -tolerance && v_diff <= tolerance)
            v_correct = true;

        if (h_correct && s_correct && v_correct)
        {
            correctCount += 1;
            match_img.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            match_img.SetActive(false);
            if (correctCount == gameOverTotal)
            {
                CompleteFunction.Invoke();
            }
            resetCheck();
            newMatch();
        }
        else
        {
            tryAgain_img.SetActive(true);

            yield return new WaitForSeconds(waitTime);

            tryAgain_img.SetActive(false);
        }
    }
}