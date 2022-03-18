using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public Slider slider;

    public void SetMaxItems(int value)
    {
        slider.maxValue = value;
        slider.value = 0;
    }

     public void ShowProgress(int value)
    {
        slider.value = value;
    }
}
