using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DishQueueViewer : MonoBehaviour
{
    //tween to move ui to the left
    //tween to drop dish mqde or failed
    public List<DishIcon> DishIconList;

    public TextMeshProUGUI dishCounter;
    public Sprite defaultSprite;
    public string defaultText;
    

    // Start is called before the first frame update
    void Start()
    {
        dishCounter.text = "0";
        InitDishIconsDefaultValues();
    }

    public void InitDishIconsDefaultValues()
    {
        foreach (var dishIcon in DishIconList)
        {
            dishIcon.ChangeData(defaultSprite, defaultText);
        }
    }

    public void SetDishIconsWith(List<Dish> dishes)
    {
        DishIcon dishIcon;
        for (int i = 0; i < dishes.Count; i++)
        {
            dishIcon = DishIconList[i].GetComponent<DishIcon>();
        }
    }

    public void UpdateCounter(int remainingDishes)
    {
        dishCounter.text = remainingDishes.ToString();
    }

    public void UpdateDishIcon(int index, Sprite sprite, string text)
    {
        var dishIcon = DishIconList[index].GetComponent<DishIcon>();
        dishIcon.ChangeData(sprite, text);
    }

    public void DropDishTile()
    {

    }

    private void SlideDishTileToLeft()
    {

    }


}
