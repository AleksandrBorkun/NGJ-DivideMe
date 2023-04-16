using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelObject[] levelObjects;

    private LevelObject currentLevel;
    private int currentLevelIndex = 0;

    public Dish currentDish;
    public GameObject nextLevelEffect;


    private int currentDishIndex = 0;
    private OvenController oven;
    private Player player;
    private Beerometer beerometer;
    private DishQueueViewer dishQueueViewer;

    private IngridientsSpawner ingridientsSpawner;
    float timeLeft = 60.0f;
    Timer timer;
    TextMeshProUGUI timerText;
    GameOverCanvas gameOverCanvas;
    bool isGameOver = false;
    [SerializeField] private AudioClip gameOverAudioClip;

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
        gameOverCanvas = FindObjectOfType<GameOverCanvas>();
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

        if (isGameOver && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CountDownTimer()
    {
        if (isGameOver) { return; }
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
        isGameOver = true;
        gameOverCanvas.transform.GetChild(0).gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(gameOverAudioClip, new Vector3(0, 0, 0));

        player.GetComponent<SimpleSampleCharacterControl>().gameObject.SetActive(false);

    }

    public async void SetupNextDish()
    {
        currentDishIndex++;
        UIApi.IncrementPointsCounterOf(15);
        //dishQueueViewer.OnDishCompleted();

        // check if next level should be triggered
        if (currentDishIndex >= currentLevel.dishes.Length)
        {
            timeLeft += 15;
            currentLevelIndex++;
            currentDishIndex = 0;
            currentLevel = levelObjects[currentLevelIndex];
            await dishQueueViewer.DropAllDishIcon();
            dishQueueViewer.SetDishIconsAtLevelStart(currentLevel.dishes.ToList());
            Instantiate(nextLevelEffect, transform);
        }
        else
        {
            timeLeft += 5;
            if (currentDishIndex + 2 < currentLevel.dishes.Length)
            {
                await dishQueueViewer.DropDishIcon();
                dishQueueViewer.DisplayNewDish(currentLevel.dishes[currentDishIndex + 2]);
            }
            else
            {
                await dishQueueViewer.DropDishIcon();
                dishQueueViewer.DisplayNewDish(currentLevel.dishes[currentDishIndex]);
            }
        }

        currentDish = currentLevel.dishes[currentDishIndex];

        dishQueueViewer.UpdateCounter(currentLevel.dishes.Length - currentDishIndex);

        ingridientsSpawner.SpawnNext(currentDish.GetRecipe());
    }
}
