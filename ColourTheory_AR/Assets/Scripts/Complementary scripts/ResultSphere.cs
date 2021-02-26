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



    // Start is called before the first frame update
    void Start()
    {
        //AlterColor = AlterMat.color;
        //ComplementaryColor = ComplementaryMat.color;
        //ResultColor = ResultMat.color;
    }

    void checkResult()
    {
        //if( ResultColor.r >= )
    }

    // Update is called once per frame
    void Update()
    {
       // ResultColor.r = (1.0f - AlterColor.r) + ComplementaryColor.r;
       // ResultColor.g = (1.0f - AlterColor.g) + ComplementaryColor.g;
       // ResultColor.b = (1.0f - AlterColor.b) + ComplementaryColor.b;
       // ResultMat.color = ResultColor;
        //Debug.Log("its goin");
    }
}
