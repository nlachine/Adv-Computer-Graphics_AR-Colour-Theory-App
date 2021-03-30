using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://coffeebreakcodes.com/drag-object-with-mouse-unity3d/ code for getting the mouse to click and dragging object was made using this
public class MouseClickAndDrag : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 Offset;

    bool enableDragging = true;
    bool holdingObject = false;


    //Station 1 Specific
    public Vector3 originalPos;
    float zPos;

    // Start is called before the first frame update
    void Start()
    {
        zPos = transform.localPosition.z;
    }

    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Station 1 Specific
    public Vector3 getOriginalPos()
    {
        return originalPos;
    }

    public void setDragging(bool _enabled)
    {
        enableDragging = _enabled;
    }
    private void OnMouseDown()
    {
        if (enableDragging)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            holdingObject = true;
        }
    }

    private void OnMouseUp()
    {
        holdingObject = false;
    }

    private void OnMouseDrag()
    {
        if (enableDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + Offset;
            transform.position = cursorPosition;
            if (transform.localPosition.z != zPos)
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zPos);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == gameObject.tag && !holdingObject)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
            gameObject.SetActive(false);
        }
    }

}
