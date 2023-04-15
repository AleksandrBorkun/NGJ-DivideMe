using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beerometer : MonoBehaviour
{
    public float Decrement = 0.01f;
    public Gradient gradient;

    private Slider slider;
    private Image fill;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        fill = transform.Find("Fill").GetComponent<Image>();
    }

    public void UpdateBeerometer(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
