using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniIcon : MonoBehaviour
{
    public Icon myIcon;


    private void OnMouseDown()
    {
        myIcon.StartApp();
    }
}
