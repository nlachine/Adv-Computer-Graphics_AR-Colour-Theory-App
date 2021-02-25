using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSlider : MonoBehaviour
{
    //Alter Sphere Properties
    public Slider slider_red, slider_yellow, slider_blue;
    private Renderer _Renderer;
    private Material as_Material;
    private Color alterSphere_RGB;
    private Color alterSphere_RYB;

    private bool isReset = false;

    //Match Sphere Properties
    public GameObject matchSphere;
    private HandleColour s_handleColour;
    private Material ms_Material;
    private Color matchSphere_RGB;
    private Color matchSphere_RYB;

    //How close do you have to be for each colour + or - tolerance
    float tolerance = 0.10f;

    public void sliderUpdate()
    {
        //Has start function complete
        if (!isReset)
            return;

        //Save RYB values from slider
        alterSphere_RYB.r = slider_red.value;
        alterSphere_RYB.g = slider_yellow.value; //yellow
        alterSphere_RYB.b = slider_blue.value;

        //Convert slider to RGB for display
        alterSphere_RGB = s_handleColour.ConvertToRGB(alterSphere_RYB.r, alterSphere_RYB.g, alterSphere_RYB.b);
        as_Material.color = alterSphere_RGB;

        //checkMatch();
    }

    public void checkMatch(){
         //Log RGB values of each sphere
        Debug.Log("AS: " + alterSphere_RYB);
        Debug.Log("MS: " + matchSphere_RYB);

        //calculate the difference between each value of match sphere and alter sphere
        float r_difference = matchSphere_RYB.r - alterSphere_RYB.r;
        float y_difference = matchSphere_RYB.g - alterSphere_RYB.g; //yellow
        float b_difference = matchSphere_RYB.b - alterSphere_RYB.b;
        
        //check if all are within tolerance. If true, rerandomize;
        if (r_difference <= tolerance && r_difference >= -tolerance && y_difference <= tolerance && y_difference >= -tolerance && b_difference <= tolerance && b_difference >= -tolerance)
        {
            Debug.Log("Matched");
            //New colour.
            matchSphere_RYB = s_handleColour.Randomize();
            matchSphere_RGB = s_handleColour.ConvertToRGB(matchSphere_RYB.r, matchSphere_RYB.g, matchSphere_RYB.b);
            ms_Material.color = matchSphere_RGB;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //Get Components for the colour handler script
        s_handleColour = matchSphere.GetComponent<HandleColour>();

        //Get Components for the matching sphere
        ms_Material = matchSphere.GetComponent<MeshRenderer>().material;
        matchSphere_RGB = ms_Material.color;

        //Get alter sphere components
        _Renderer = GetComponent<MeshRenderer>();

        //Set this material to be the default material
        as_Material = _Renderer.material;

        //Randomize the match material (RYB) & convert to display (RGB)
        matchSphere_RYB = s_handleColour.Randomize();
        matchSphere_RGB = s_handleColour.ConvertToRGB(matchSphere_RYB.r, matchSphere_RYB.g, matchSphere_RYB.b);
        ms_Material.color = matchSphere_RGB;

        //Randomize the alter spheres colour (RYB) & conver to display (RGB)
        alterSphere_RYB = s_handleColour.Randomize();
        alterSphere_RGB = s_handleColour.ConvertToRGB(alterSphere_RYB.r, alterSphere_RYB.g, alterSphere_RYB.b);
        as_Material.color = alterSphere_RGB;
        
        //Match sliders to be correct to the alter sphere
        slider_red.value = alterSphere_RYB.r;
        slider_yellow.value = alterSphere_RYB.g; //yellow
        slider_blue.value = alterSphere_RYB.b;

        isReset = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
