using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleColour : MonoBehaviour
{

    //RYB-> RGB Colour Constants
    float[] whiteRYB = { 1.0f, 1.0f, 1.0f }; // 0   0   0 RYB
    float[] redRYB = { 1.0f, 0.0f, 0.0f }; // 100 RYB
    float[] yellowRYB = { 1.0f, 1.0f, 0.0f }; // 010 RYB
    float[] blueRYB = { 0.163f, 0.373f, 0.6f }; // 001 RYB
    float[] orangeRYB = { 1.0f, 0.5f, 0.0f }; // 110 RYB
    float[] violetRYB = { 0.5f, 0.0f, 0.5f }; // 101 RYB
    float[] greenRYB = { 0.0f, 0.66f, 0.2f }; // 011 RYB
    float[] blackRYB = { 0.2f, 0.094f, 0.0f }; // 111 RYB

    // //RGB-> RYB Colour Constants
    // float[] blackRGB = { 1.0f, 1.0f, 1.0f }; // 000 RYB
    // float[] redRGB = { 1.0f, 0.0f, 0.0f }; // 100 RYB
    // float[] greenRGB = { 0.0f, 1.0f, 0.483f }; // 010 RYB
    // float[] yellowRGB = { 0.0f, 1.0f, 0.0f }; // 110 RYB
    // float[] blueRGB = { 0.0f, 0.0f, 1.0f }; // 001 RYB
    // float[] magentaRGB = { 0.309f, 0.0f, 0.469f }; // 101 RYB
    // float[] turquiosRGB = { 0.0f, 0.053f, 0.21f }; // 011 RYB
    // float[] whiteRGB = { 0.0f, 0.0f, 0.0f }; // 111 RYB

    public Color ConvertToRGB(float _r, float _y, float _b)
    {
        Color outputColour = new Color(0,0,0);

        float r = _r;
        float y = _y;
        float b = _b;

        //Debug.Log("R:"+ outputColour.r + " G:" + outputColour.g + " B:"+ outputColour.b);
        for (int i = 0; i < 3; i++)
        {   
            //Algorithm created from information here: http://vis.computer.org/vis2004/DVD/infovis/papers/gossett.pdf
            float tempColour = whiteRYB[i] * (1 - r) * (1 - b) * (1 - y)
                                + redRYB[i] * r * (1 - b) * (1 - y)
                                + blueRYB[i] * (1 - r) * b * (1 - y)
                                + violetRYB[i] * r * b * (1 - y)
                                + yellowRYB[i] * (1 - r) * (1 - b) * y
                                + orangeRYB[i] * r * (1 - b) * y
                                + greenRYB[i] * (1 - r) * b * y
                                + blackRYB[i] * r * b * y;

            if (i == 0)
                outputColour.r = tempColour;
            else if (i == 1)
                outputColour.g = tempColour;
            else if (i == 2)
                outputColour.b = tempColour;
        }

        return outputColour;
    }

    public Color Randomize()
    {
        float r_rand = Random.Range(0.0f,1.0f);
        float y_rand = Random.Range(0.0f,1.0f);
        float b_rand = Random.Range(0.0f,1.0f);
        //GetComponent<Renderer>().material.color = ConvertToRGB(r_rand, y_rand, b_rand);
        return new Color(r_rand,y_rand,b_rand);
    }
}
