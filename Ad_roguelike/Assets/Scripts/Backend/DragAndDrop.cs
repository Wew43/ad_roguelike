using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DragAndDrop : MonoBehaviour //Весь этот скрипт нужен только чтобы передавать данные в Window
{
    Window parent;
    private void Start()
    {
        parent = transform.parent.GetComponent<Window>();
    }
    private void OnMouseDown()
    {
        parent.SetOffset(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.transform.position);
        parent.isHolded = true;
        WindowManager.Up(parent);
    }
    private void OnMouseUp()
    {
        parent.isHolded = false;
    }
}
