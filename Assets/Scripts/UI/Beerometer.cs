using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beerometer : MonoBehaviour
{

    public int Beerlevel;
    public Slider slider;
    public Gradient gradient;



    // Start is called before the first frame update
    void Start()
    {
        Beerlevel = 50;
        slider = GetComponent<Slider>();
        slider.value = Beerlevel;
    }

    public void UpdateBeerometer(float value)
    {
        slider.value += value;
    }


}
