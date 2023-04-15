using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelObject[] levelObjects;

    private LevelObject curentLevent;
    private Dish currentDish;
    private OvenController oven;

    private IngridientsSpawner ingridientsSpawner;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {

        Debug.Log("Game Manager Setting up level on start");
        curentLevent = levelObjects[0];
        currentDish = curentLevent.dishes[0];
        // Spawn Ingridients
        ingridientsSpawner = FindObjectOfType<IngridientsSpawner>();
        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());

        // Udate Oven with Current Dish
        oven = FindObjectOfType<OvenController>();
        oven.SetDish(currentDish);


        Debug.Log("Game Manager Comlete Setting up level on start");
    }

}
