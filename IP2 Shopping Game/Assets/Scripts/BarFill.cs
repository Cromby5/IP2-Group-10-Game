using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private Animator animBar;


    [SerializeField] private GameObject CartStage1;
    [SerializeField] private GameObject CartStage2;

    private bool playedFirst;

    private Animator animCart;

    private void Start()
    {
        animCart = CartStage1.GetComponent<Animator>();
        playedFirst = false;
        animBar.speed = 1;
    }

    void Update()
    {
        animBar.Play("Progress Bar", -1, slider.normalizedValue);
        if (slider.value == slider.maxValue / 2 && !playedFirst)
        {
            playedFirst = true;
            StartCoroutine("Stage1");
        }
        if (slider.value == slider.maxValue && playedFirst)
        {
            animCart.Play("CartAnim");
        }
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

    IEnumerator Stage1()
    {
        animCart.Play("CartAnim");
        yield return new WaitForSeconds(2f);
        CartStage1.SetActive(false);
        CartStage2.SetActive(true);
        animCart = CartStage2.GetComponent<Animator>();
    }
}
