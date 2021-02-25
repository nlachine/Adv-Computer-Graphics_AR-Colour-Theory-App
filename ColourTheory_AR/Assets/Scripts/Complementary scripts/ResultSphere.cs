using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSphere : MonoBehaviour
{
    [SerializeField]
    GameObject AlterSphere;
    [SerializeField]
    GameObject ComplementarySphere;

    [SerializeField]
    Material AlterMat;
    [SerializeField]
    Material ComplementaryMat;
    [SerializeField]
    Material ResultMat;

    private Color AlterColor;
    private Color ComplementaryColor;
    private Color ResultColor;

    private HandleColour _handleColour;

    float tolerance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        AlterColor = AlterMat.color;
        ComplementaryColor = ComplementaryMat.color;
        ResultColor = ResultMat.color;
    }

    void checkResult()
    {
        //if( ResultColor.r >= )
    }

    // Update is called once per frame
    void Update()
    {
        ResultColor.r = (ComplementaryColor.r - 1.0f) + AlterColor.r;
        ResultColor.g = (ComplementaryColor.g - 1.0f) + AlterColor.g;
        ResultColor.b = (ComplementaryColor.b - 1.0f) + AlterColor.b;
        ResultMat.color = ResultColor;
    }
}
