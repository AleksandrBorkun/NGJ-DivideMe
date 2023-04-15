using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    List<Data.Ingridients> inventory;

    public void AddIngredient(Data.Ingridients ingridientToAdd)
    {
        inventory.Add(ingridientToAdd);
    }

    public void RemoveIngredient(Data.Ingridients ingridientToRemove)
    {
        inventory.Remove(ingridientToRemove);
    }

    public void LogContents()
    {
        Debug.Log("INVENTORY CONTENTS: ");
        foreach (Data.Ingridients ingridient in inventory)
        {
            Debug.Log(ingridient);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<Data.Ingridients>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
