using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ad : MonoBehaviour
{
    [SerializeField] TMP_Text TimerSecondsText;
    float time;
    void Start()
    {
        StartCoroutine(Timer());
    }
    void Update()
    {

    }

    IEnumerator Timer()
    {
        while (time < 30f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime * 15;
            TimerSecondsText.text = time.ToString("0");
        }
    }
}
