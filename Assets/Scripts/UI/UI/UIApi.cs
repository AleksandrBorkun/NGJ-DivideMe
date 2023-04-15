using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIApi : MonoBehaviour
{
    public static UIApi instance;
    public Beerometer beerometer;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;   
    }

    public static Beerometer GetBeerometer()
    {
        return instance.beerometer;
    }
}
