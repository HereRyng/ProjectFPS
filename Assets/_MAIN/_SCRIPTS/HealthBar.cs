using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Observables;
using System;

public class HealthBar : MonoBehaviour
{
    private Image content;
    private float currentFill;
    private float currentValue;
    public float MyMaxValue { get; set; }

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
        }
    }
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
    private void Start()
    {
        content = GetComponent<Image>();
    }
    private void Update()
    {

        content.fillAmount = currentFill;
      
    }

  
}
