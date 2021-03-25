using UnityEngine;

public class Controller_Station2 : MonoBehaviour
{

    //Colour Flashing Controls
    [Header("Flashing Controls")]
    [Range(0.0f, 1.0f)]
    public float flashAmplitude = 0.5f;
    [Range(0.0f, 1.0f)]
    public float flashOffset = 1f;
    [Range(0, 10)]
    public int flashSpeed = 5;



    //Declare Colour Wheel Game Objects and Mesh Renderers
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

    //Declare Colour Wheel Materials (Drag In)
    [Header("CW Materials")]
    public Material redMat;
    public Material redOrangeMat;
    public Material orangeMat;
    public Material yellowOrangeMat;
    public Material yellowMat;
    public Material yellowGreenMat;
    public Material greenMat;
    public Material blueGreenMat;
    public Material blueMat;
    public Material bluePurpleMat;
    public Material purpleMat;
    public Material redPurpleMat;           



    // Start is called before the first frame update
    void Start()
    {
        //Set Default Flashing Parameters
         flashAmplitude = 0.5f;
         flashOffset = 1f;
         flashSpeed = 5;

        //Set Colour Wheel Game Objects and Mesh Renderers
        redPiece = colourWheel.gameObject.transform.Find("1_Red").GetChild(0).gameObject;
        redOrangePiece= colourWheel.gameObject.transform.Find("2_Red-Orange").GetChild(0).gameObject;
        orangePiece= colourWheel.gameObject.transform.Find("3_Orange").GetChild(0).gameObject;
        yellowOrangePiece= colourWheel.gameObject.transform.Find("4_Yellow-Orange").GetChild(0).gameObject;
        yellowPiece= colourWheel.gameObject.transform.Find("5_Yellow").GetChild(0).gameObject;
        yellowGreenPiece= colourWheel.gameObject.transform.Find("6_Yellow-Green").GetChild(0).gameObject;
        greenPiece= colourWheel.gameObject.transform.Find("7_Green").GetChild(0).gameObject;
        blueGreenPiece= colourWheel.gameObject.transform.Find("8_Blue-Green").GetChild(0).gameObject;
        bluePiece= colourWheel.gameObject.transform.Find("9_Blue").GetChild(0).gameObject;
        bluePurplePiece= colourWheel.gameObject.transform.Find("10_Blue-Purple").GetChild(0).gameObject;
        purplePiece= colourWheel.gameObject.transform.Find("11_Purple").GetChild(0).gameObject;
        redPurplePiece= colourWheel.gameObject.transform.Find("12_Red-Purple").GetChild(0).gameObject;

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

        //Set Materials on Pieces
        redRenderer.material = redMat;
        //redOrangeRenderer.material = redOrangeMat;
        //orangeRenderer.material = orangeMat;
        //yellowOrangeRenderer.material = yellowOrangeMat;
        yellowRenderer.material = yellowMat;
        //yellowGreenRenderer.material = yellowGreenMat;
        //greenRenderer.material = greenMat;
        //blueGreenRenderer.material = blueGreenMat;
        blueRenderer.material = blueMat;
        //bluePurpleRenderer.material = bluePurpleMat;
        //purpleRenderer.material = purpleMat;
        //redPurpleRenderer.material = redPurpleMat;
    }

    void FlashingAlpha(Renderer renderer)
    {
        Color tempCol = renderer.material.color;
        tempCol.a = flashAmplitude * Mathf.Sin(Time.time * flashSpeed) + flashOffset;
        renderer.material.color = tempCol;
    }

    // Update is called once per frame
    void Update()
    {
        FlashingAlpha(redRenderer);
        FlashingAlpha(yellowRenderer);
        FlashingAlpha(blueRenderer);
        Debug.Log(redPiece.GetComponent<MeshRenderer>().material.color);
    }
}
