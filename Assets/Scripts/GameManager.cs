using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelObject[] levelObjects;

    private LevelObject currentLevel;
    private int currentLevelIndex = 0;
    private Dish currentDish;
    private int currentDishIndex = 0;
    private OvenController oven;
    private Player player;
    private Beerometer beerometer;

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
        currentLevel = levelObjects[currentLevelIndex];
        currentDish = currentLevel.dishes[currentDishIndex];
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
        player.drunkenness -= .005f * Time.deltaTime * currentLevel.levelSpeed;
        beerometer.UpdateBeerometer(player.drunkenness);

    }

    public void SetupNextDish()
    {
        currentDishIndex++;

        // check if next level should be triggered
        if(currentDishIndex >= currentLevel.dishes.Length)
        {
            currentLevelIndex++;
            currentDishIndex = 0;
        }

        currentLevel = levelObjects[currentLevelIndex];
        currentDish = currentLevel.dishes[currentDishIndex];

        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());
        oven.SetDish(currentDish);
    }
}
