using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaTemplate : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void ChangeWallpapers(int n)
    {
        Camera.main.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = transform.GetChild(0).GetChild(n).GetComponent<Image>().sprite;
    }
}
