using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DishQueueViewer : MonoBehaviour
{
    //tween to move ui to the left
    //tween to drop dish mqde or failed
    private List<int> dishesToDisplay;

    public TextMeshProUGUI dishCounter;


    // Start is called before the first frame update
    void Start()
    {
        dishCounter.text = "0";
    }

    public void UpdateCounter(int remainingDishes)
    {
        dishCounter.text = remainingDishes.ToString();
    }

    public void CreateDishTile(Dish dish)
    {

    }

    public void DropDishTile()
    {

    }

    private void SlideDishTileToLeft()
    {

    }


}
