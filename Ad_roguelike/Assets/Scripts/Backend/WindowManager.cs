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
    public static void Up(Window w) //Метод поднимает нужный элемент из списка на самый верх
    {
        if (!windows.Contains(w)) 
        { 
            windows.Add(w);
        }
        else
        {
            windows.Remove(w);
            windows.Add(w);
        }

        for (int j = 0; j < windows.Count; j++)
        {
            windows[j].gameObject.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sortingOrder = 1 + 100 * j; //панелька за которую тянуть
            windows[j].gameObject.transform.GetChild(1).transform.GetComponent<SpriteRenderer>().sortingOrder = 0 + 100 * j; //заполнитель
            windows[j].gameObject.transform.GetChild(2).transform.GetComponent<Canvas>().sortingOrder = 2 + 100 * j; //канвас тайтла
            windows[j].gameObject.transform.GetChild(3).GetChild(0).GetChild(0).transform.GetComponent<Canvas>().sortingOrder = 3 + 100 * j; //канвас в темплейте
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
