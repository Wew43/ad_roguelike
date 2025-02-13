using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Window : MonoBehaviour {

    //переменные
    public WindowProperties windowProperties;
    public bool isHolded;
    public Vector3 mouse, offset;


    private void Start()
    {
        
    }
    private void Update()
    {
        //Настройка позиций и размеров гейм обжектов(сцен)
        transform.GetChild(0).localScale = new Vector2(windowProperties.DragTabSize.x, windowProperties.DragTabSize.y);
        transform.GetChild(0).position = new Vector2(transform.position.x, transform.position.y + windowProperties.BgSize.y / 2 + windowProperties.DragTabSize.y / 2);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = windowProperties.DragTabColor;
        transform.GetChild(1).localScale = new Vector2(windowProperties.BgSize.x, windowProperties.BgSize.y);
        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = windowProperties.BgColor;
        transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = windowProperties.Title;
        transform.GetChild(2).GetComponent<RectTransform>().sizeDelta = new Vector2(windowProperties.DragTabSize.x, windowProperties.DragTabSize.y);
        transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(windowProperties.DragTabSize.x, windowProperties.DragTabSize.y);
        transform.GetChild(2).GetComponent<RectTransform>().position = new Vector2(transform.position.x, transform.position.y + windowProperties.BgSize.y / 2 + windowProperties.DragTabSize.y / 2);
        transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().color = InvertColor(windowProperties.DragTabColor);
        //

        //Механика перемещения с отступом клика
        if (isHolded) 
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse = DeleteZ(mouse);
            transform.position = mouse - offset;   
        }
        //
    }
    public void SetOffset(Vector3 x)
    {
        offset = DeleteZ(x);
    }
    Color InvertColor(Color c)
    {
        //return new Color(1f - c.r, 1f - c.g, 1f - c.b, c.a);
        if((c.r + c.g + c.b)/3 >= 0.5f)
        {
            return Color.black;
        }
        else
        {
            return Color.white;
        }
    }
    Vector3 DeleteZ(Vector3 z) //метод
    {
        return new Vector3(z.x, z.y, 0);
    }
}
