using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MultiplierBar : MonoBehaviour
{
    [SerializeField] Slider MSlider;
    [SerializeField] TMP_Text MText, M2Text;
    void Start()
    {

    }
    void Update()
    {
        MText.text = MSlider.value.ToString("0.00");
        M2Text.text = (MSlider.maxValue - MSlider.value).ToString("0.00");
    }
}
