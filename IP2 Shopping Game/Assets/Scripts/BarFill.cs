using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public Slider slider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    void Update()
    {
        anim.Play("TEST", -1, slider.normalizedValue);
    }

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
