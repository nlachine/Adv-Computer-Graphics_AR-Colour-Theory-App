using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://coffeebreakcodes.com/drag-object-with-mouse-unity3d/ code for getting the mouse to click and dragging object was made using this
// https://answers.unity.com/questions/373818/how-to-detect-mouse-click-on-a-gameobject.html this was for using a ray to check for mouse collisions
public class MouseClickAndDrag : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 Offset;

    //public GameObject dragObject;

    bool overObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if(Physics.Raycast(ray, out hit))
        //{
        //    if(hit.collider.tag == "WheelPeice")
        //    {
        //        overObject = true;
        //        dragObject = hit.collider.gameObject;
        //        Debug.Log("found object");
        //    }
        //}
        //else
        //{
        //    overObject = false;
        //    dragObject = null;
        //}
    }

    private void OnMouseDown()
    {
        //if (overObject && dragObject != null)
        //{
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //}
    }
    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + Offset;
        transform.position = cursorPosition;
    }

}
