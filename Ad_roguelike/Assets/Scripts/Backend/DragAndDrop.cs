using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Window parent;
    private void Start()
    {
        parent = transform.parent.GetComponent<Window>();
    }
    private void OnMouseDown()
    {
        parent.offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.transform.position;
        parent.offset = DeleteZ(parent.offset);
        parent.isHolded = true;

        WindowManager.Up(parent);


    }
    private void OnMouseUp()
    {
        parent.isHolded = false;
    }
    Vector3 DeleteZ(Vector3 z)
    {
        return new Vector3(z.x, z.y, 0);
    }


}
