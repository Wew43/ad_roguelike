using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Window : MonoBehaviour {

    public WindowProperties windowProperties;
    [SerializeField] public bool isHolded;
    [SerializeField] public Vector3 mouse, offset;


    private void Start()
    {
          
    }
    private void Update()
    {
        transform.GetChild(1).localScale = new Vector2(windowProperties.BgSize.x, windowProperties.BgSize.y);
        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = windowProperties.BgColor;
        transform.GetChild(0).localScale = new Vector2(windowProperties.DragTabSize.x, windowProperties.DragTabSize.y);
        transform.GetChild(0).position = new Vector2(transform.position.x, transform.position.y + windowProperties.BgSize.y / 2);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = windowProperties.DragTabColor;
        if (isHolded) 
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse = DeleteZ(mouse);
            transform.position = mouse - offset;   
        }
    }

    Vector3 DeleteZ(Vector3 z)
    {
        return new Vector3(z.x, z.y, 0);
    }
}
