using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourWheel : MonoBehaviour
{
    //---- Declare Colour Wheel Game Objects and Mesh Renderers ----//
    [Header("Colour Wheel")]
    GameObject colourWheel;
    public List<GameObject> colourWheelPieces = new List<GameObject>(12);
    public List<Renderer> colourWheelRenderers = new List<Renderer>(12);
    //---- Declare Colour Wheel Materials (Drag In 12) ----//
    public List<Material> colourWheelMats = new List<Material>(12);

    public GameObject getColourWheel()
    {
        return this.transform.Find("ColourWheel").gameObject;
    }

    public void setWheelPieces(List<GameObject> list_g)
    {
        list_g.Add(getColourWheel().gameObject.transform.Find("0_Red").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("1_Red-Orange").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("2_Orange").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("3_Yellow-Orange").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("4_Yellow").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("5_Yellow-Green").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("6_Green").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("7_Blue-Green").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("8_Blue").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("9_Blue-Purple").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("10_Purple").GetChild(0).gameObject);
        list_g.Add(getColourWheel().gameObject.transform.Find("11_Red-Purple").GetChild(0).gameObject);
    }

    public void setWheelRenderers(List<GameObject> list_g, List<Renderer> list_r)
    {
        list_r.Add(list_g[0].GetComponent<MeshRenderer>());
        list_r.Add(list_g[1].GetComponent<MeshRenderer>());
        list_r.Add(list_g[2].GetComponent<MeshRenderer>());
        list_r.Add(list_g[3].GetComponent<MeshRenderer>());
        list_r.Add(list_g[4].GetComponent<MeshRenderer>());
        list_r.Add(list_g[5].GetComponent<MeshRenderer>());
        list_r.Add(list_g[6].GetComponent<MeshRenderer>());
        list_r.Add(list_g[7].GetComponent<MeshRenderer>());
        list_r.Add(list_g[8].GetComponent<MeshRenderer>());
        list_r.Add(list_g[9].GetComponent<MeshRenderer>());
        list_r.Add(list_g[10].GetComponent<MeshRenderer>());
        list_r.Add(list_g[11].GetComponent<MeshRenderer>());
    }

    public void ResetDefaultColours(List<Renderer> list_r)
    {
        //---- Set Materials on Pieces ----//
        for (int i = 0; i < list_r.Count; i++)
        {
            list_r[i].material = colourWheelMats[i];
        }
    }
}
