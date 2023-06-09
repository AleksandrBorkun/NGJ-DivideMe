using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenController : MonoBehaviour
{

    public GameObject smokeEffect;
    public GameObject arrowDown;

    Inventory inventoryObj;

    private void Start()
    {
        inventoryObj = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (!inventoryObj) return;

        bool isAllIngridientsCollected = true;
        Dish currentDish = GameManager.Instance.currentDish;
        foreach (Data.Ingridients ingridient in currentDish.GetRecipe())
        {
            if (!inventoryObj.inventory.Contains(ingridient))
            {
                arrowDown.SetActive(false);
                isAllIngridientsCollected = false;
                Debug.LogFormat("Player dont have {0}", ingridient);
                return;
            }
        }
        if (isAllIngridientsCollected)
        {
            arrowDown.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dish currentDish = GameManager.Instance.currentDish;
        //Inventory inventoryObj = collision.gameObject.GetComponent<Inventory>();
        if (!inventoryObj) return;
        bool isAllIngridientsCollected = true;
        // check that all ingridients collected
        foreach (Data.Ingridients ingridient in currentDish.GetRecipe())
        {
            if (!inventoryObj.inventory.Contains(ingridient))
            {
                isAllIngridientsCollected = false;
                Debug.LogFormat("Player dont have {0}", ingridient);
                return;
            }
        }

        // remove ingridieents from inventory and spawn next dish
        if (isAllIngridientsCollected)
        {
            Debug.LogFormat("All ingridients for {0} collected, preparing food now", currentDish);
            foreach (Data.Ingridients ingridient in currentDish.GetRecipe())
            {
                inventoryObj.inventory.Remove(ingridient);
            }


            GameManager.Instance.SetupNextDish();
            Instantiate(smokeEffect, transform);
            collision.gameObject.GetComponent<Player>().PlayCookingSound();
        }
    }
}
