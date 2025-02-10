using System.Collections;
using System.Collections.Generic;
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

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            //parent.transform.GetChild(i).GetComponent<SpriteRenderer>().rendererPriority += 1000;
        }


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
