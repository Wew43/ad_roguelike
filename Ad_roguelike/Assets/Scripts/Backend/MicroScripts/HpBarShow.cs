using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpBarShop : MonoBehaviour
{
    [SerializeField] Slider HpSlider;
    [SerializeField] TMP_Text Text, MinHpText, MaxHpText;    
    void Start()
    {
        
    }
    void Update()
    {
        Text.text = HpSlider.value.ToString();
    }
}
