using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelObject[] levelObjects;

    private LevelObject currentLevel;
    private Dish currentDish;
    private OvenController oven;
    private Player player;
    private Beerometer beerometer;

    private IngridientsSpawner ingridientsSpawner;

    private int frameCount = 0;

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
        currentLevel = levelObjects[0];
        currentDish = currentLevel.dishes[0];
        // Spawn Ingridients
        ingridientsSpawner = FindObjectOfType<IngridientsSpawner>();
        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());

        // Udate Oven with Current Dish
        oven = FindObjectOfType<OvenController>();
        oven.SetDish(currentDish);

        // get player

        player = FindObjectOfType<Player>();

        //find beerometer
        beerometer = FindObjectOfType<Beerometer>();


        Debug.Log("Game Manager Comlete Setting up level on start");
    }


    private void Update()
    {
        frameCount++;
        player.drunkenness -= .01f * Time.deltaTime * currentLevel.levelSpeed;
        Debug.Log(player.drunkenness);
        beerometer.UpdateBeerometer(player.drunkenness);
        if(player.drunkenness <= 0)
        {

        }
    }
}
