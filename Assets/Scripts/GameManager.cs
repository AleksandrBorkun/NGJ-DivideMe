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
    private Dish currentDish;
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

        dishQueueViewer = FindObjectOfType<DishQueueViewer>();


        dishQueueViewer.SetDishIconsAtLevelStart(currentLevel.dishes.ToList());
        dishQueueViewer.UpdateCounter(currentLevel.dishes.Length);

        timer = FindObjectOfType<Timer>();
        timerText = timer.GetComponentInChildren<TextMeshProUGUI>();

        Debug.Log("Game Manager Comlete Setting up level on start");
    }


    private void Update()
    {
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
        }
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
        oven.SetDish(currentDish);
    }
}
