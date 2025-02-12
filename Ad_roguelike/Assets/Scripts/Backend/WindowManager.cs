using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static List<Window> windows = new List<Window>();
    void Start()
    {
        windows.Clear();
        
    }
    void Update()
    {
        
    }
    public static void Up(Window w)
    {
        if (!windows.Contains(w)) 
        { 
            windows.Add(w);
            //windows.
        }
        else
        {
            windows.Remove(w);
            windows.Add(w);
        }

        for (int j = 0; j < windows.Count; j++)
        {
            windows[j].gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sortingOrder = 1 + 100 * j;
            windows[j].gameObject.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sortingOrder = 0 + 100 * j;
        }
    }


    public static void CloseWindow(Window w)
    {
        w.gameObject.SetActive(false);
    }
    public static void OpenWindow(Window w)
    {
        w.gameObject.SetActive(true);
    }

}
