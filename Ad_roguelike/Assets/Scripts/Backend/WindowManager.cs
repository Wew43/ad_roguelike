using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static List<Window> windows = new List<Window>();
    void Start()
    {
        
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
    }
    
}
