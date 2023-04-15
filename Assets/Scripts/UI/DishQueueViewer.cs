using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DishQueueViewer : MonoBehaviour
{
    //tween to move ui to the left
    //tween to drop dish mqde or failed
    public List<DishIcon> DishIconList;
    public List<Transform> QueuePositions;

    public TextMeshProUGUI dishCounter;
    public Sprite defaultSprite;
    public string defaultText;
    

    // Start is called before the first frame update
    void Start()
    {
        dishCounter.text = "0";
        InitDishIconsDefaultValues();
        DropDishTile();
    }
    private void InitDishIconsDefaultValues()
    {
        foreach (var dishIcon in DishIconList)
        {
            dishIcon.ChangeData(defaultSprite, defaultText);
        }
    }

    public void SetDishIconsWith(List<Dish> dishes)
    {
        DishIcon dishIcon;
        Dish dish;
        string dishName;
        Sprite sprite;

        for (int i = 0; i < dishes.Count; i++)
        {
            dish = dishes[i];
            dishIcon = DishIconList[i].GetComponent<DishIcon>();

            sprite = dish.sprite ?? defaultSprite;
            dishName = dish.DishName ?? defaultText;
            
            dishIcon.ChangeData(sprite, dishName);
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
        DishIconList[0].transform.DOMove(QueuePositions[0].position, 1);

    }

    private void SlideDishTileToLeft()
    {

    }


}
