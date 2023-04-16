using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIApi : MonoBehaviour
{
    private static UIApi instance;
    public Beerometer beerometer;
    public DishQueueViewer dishQueueViewer;
    public PointCounter pointCounter;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;   
    }

    public static Beerometer GetBeerometer()
    {
        return instance.beerometer;
    }

    public static DishQueueViewer GetDishQueueViewer()
    {
        return instance.dishQueueViewer;
    }

    public static void IncrementPointsCounterOf(int points)
    {
        instance.pointCounter.UpdateCounter(points);
    }

    public static void ResetPointsCounter()
    {
        instance.pointCounter.ResetCounter();
    }
}
