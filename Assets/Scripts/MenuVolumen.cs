using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuVolumen : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float slidervalue;
    public AudioSource audiosource;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio",0.5f);
        audiosource.volume = slider.value;
        
    }

    public void ChangeVolume(float valor){
        slider.value = valor;
        slidervalue = slider.value;
        PlayerPrefs.SetFloat("volumenAudio",slidervalue);
        audiosource.volume = slider.value;
    }


}
