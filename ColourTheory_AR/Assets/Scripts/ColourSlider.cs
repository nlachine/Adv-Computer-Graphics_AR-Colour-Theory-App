using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSlider : MonoBehaviour
{
    public Slider slider_red,slider_green,slider_blue;
    private Color outputColour;
    private Renderer _Renderer;
    private Material _Material;
    public bool isReset = false;
    
    public void sliderUpdate(){
        if (!isReset)
            return;

        outputColour.r = slider_red.value;
        outputColour.g = slider_green.value;
        outputColour.b = slider_blue.value;
        _Material.color = outputColour;

        Debug.Log("R:"+ outputColour.r + " G:" + outputColour.g + " B:"+ outputColour.b);

    }

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = GetComponent<MeshRenderer>();
        _Material = _Renderer.material;
        outputColour = _Material.color;
        slider_red.value = outputColour.r;
        slider_green.value = outputColour.g;
        slider_blue.value = outputColour.b;
        isReset = true;
        Debug.Log("MR:"+ _Material.color.r + " MG:" + _Material.color.g + " MB:"+ _Material.color.b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
