using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public LevelObject[] levelObjects;

    private LevelObject currentLevel;
    private int currentLevelIndex = 0;
    public Dish currentDish;
    private int currentDishIndex = 0;
    private OvenController oven;
    private Player player;
    private Beerometer beerometer;
    private DishQueueViewer dishQueueViewer;

    private IngridientsSpawner ingridientsSpawner;
    float timeLeft = 60.0f;
    Timer timer;
    TextMeshProUGUI timerText;


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

    // should find all the objects here
    private void OnStart()
    {
        ingridientsSpawner = FindObjectOfType<IngridientsSpawner>();
        //find beerometer
        beerometer = FindObjectOfType<Beerometer>();
        // get player
        player = FindObjectOfType<Player>();
        dishQueueViewer = FindObjectOfType<DishQueueViewer>();
        timer = FindObjectOfType<Timer>();

        timerText = timer.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Game Manager Comlete Setting up level on awake");
    }

    private void Start()
    {
        OnStart();
        currentLevel = levelObjects[currentLevelIndex];
        currentDish = currentLevel.dishes[currentDishIndex];
        // Spawn Ingridients
        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());
        // call UI API
        dishQueueViewer.SetDishIconsAtLevelStart(currentLevel.dishes.ToList());
        dishQueueViewer.UpdateCounter(currentLevel.dishes.Length);

    }


    private void Update()
    {
        if (!(player && timerText && beerometer)) return;
        player.drunkenness -= .005f * Time.deltaTime * currentLevel.levelSpeed;
        beerometer.UpdateBeerometer(player.drunkenness);

        CountDownTimer();
    }

    private void CountDownTimer()
    {
        timerText.text = ((int)timeLeft).ToString();
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("GAME OVER!");
            GameOver();
        }
    }

    private void GameOver()
    {
        //Time.timeScale = 0;
        // Get player controller and disable it

    }

    public void SetupNextDish()
    {
        currentDishIndex++;
        //dishQueueViewer.OnDishCompleted();

        // check if next level should be triggered
        if (currentDishIndex >= currentLevel.dishes.Length)
        {
            currentLevelIndex++;
            currentDishIndex = 0;
            currentLevel = levelObjects[currentLevelIndex];
            dishQueueViewer.SetDishIconsAtLevelStart(currentLevel.dishes.ToList());
        }
        else
        {
            if (currentDishIndex + 2 < currentLevel.dishes.Length)
            {
                dishQueueViewer.DisplayNewDish(currentLevel.dishes[currentDishIndex + 2]);
            }
        }

        currentDish = currentLevel.dishes[currentDishIndex];

        dishQueueViewer.UpdateCounter(currentLevel.dishes.Length - currentDishIndex);

        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());
    }
}
