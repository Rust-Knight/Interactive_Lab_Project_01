using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider _healtSlider;

    private void Start()
    {
        _healtSlider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _healtSlider.maxValue = maxHealth;
        _healtSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        _healtSlider.value = health;
        
    }
}
