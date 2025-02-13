using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicTemplate : MonoBehaviour
{
    bool playing = true;
    [SerializeField] Sprite Play, Pause;
    AudioSource audioSource;
    Slider slider;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = transform.GetChild(0).GetChild(1).transform.GetComponent<Slider>();
        
    }
    void Update()
    {
        slider.value = audioSource.time / audioSource.clip.length;
        if (!audioSource.isPlaying)
        {
            playing = false;
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Pause;
        }
    }

    public void PlayStopButton()
    {
        if (playing && audioSource.isPlaying) 
        {
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Pause;
            audioSource.Pause();
        }
        else if(!playing || !audioSource.isPlaying) 
        {
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Play;
            audioSource.Play();
        }
        playing = !playing;
    }
}
