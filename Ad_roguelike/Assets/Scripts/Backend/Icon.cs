using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    bool ActiveWindow = false;
    [SerializeField] IconProperties iconProperties;
    [SerializeField] GameObject WindowPrefab;
    Window myWindow;
    bool closedWindow;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = iconProperties.iconSprite;
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartApp();
    }

    void StartApp()
    {
        if (!ActiveWindow)
        {
            ActiveWindow = true;
            GameObject a = Instantiate(WindowPrefab, Vector2.zero, Quaternion.identity);
            myWindow = a.GetComponent<Window>();
            myWindow.windowProperties = iconProperties.windowProperties;
            WindowManager.Up(a.GetComponent<Window>());
            
        }
        else
        {
            //WindowManager.Up(myWindow.GetComponent<Window>());
            if (closedWindow)
            {
                WindowManager.OpenWindow(myWindow);
                closedWindow = !closedWindow;
            }
            else if (!closedWindow)
            {
                WindowManager.CloseWindow(myWindow);
                closedWindow = !closedWindow;
            }
        }

    }
}
