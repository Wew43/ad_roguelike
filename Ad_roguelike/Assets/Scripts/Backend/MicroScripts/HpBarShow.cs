using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpBarShop : MonoBehaviour
{
    [SerializeField] Slider HpSlider;
    [SerializeField] TMP_Text HpText, MinHpText, MaxHpText;    
    void Start()
    {
        
    }
    void Update()
    {
        HpText.text = HpSlider.value.ToString();
    }
}
