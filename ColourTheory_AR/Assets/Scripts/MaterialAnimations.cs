using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimations : MonoBehaviour
{
    //---- Control Flashing Transparency ----//
    public void FlashingAlpha(Renderer renderer, float amp, float speed, float offset)
    {
        Color tempCol = renderer.material.color;
        tempCol.a = amp * Mathf.Sin(Time.time * speed) + offset;
        renderer.material.color = tempCol;
    }
}
