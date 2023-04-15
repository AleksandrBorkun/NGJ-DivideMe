using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Data.Ingridients> inventory;

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
