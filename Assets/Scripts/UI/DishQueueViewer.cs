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
    public int DishIconNb;
    public List<DishIcon> DishIconList;
    public List<Transform> QueuePositions;
    private List<DishIcon> DishIconQueuePosition;

    public TextMeshProUGUI dishCounter;
    public Sprite defaultSprite;
    public string defaultText;
    public float TweenSpeed;
    public Color invisible = new Color(255,255,255,0);
    public Color visible = new Color(255,255,255,1);

    // Start is called before the first frame update
    void Start()
    {
        dishCounter.text = "0";
    }

    public void UpdateCounter(int remainingDishes)
    {
        dishCounter.text = remainingDishes.ToString();
    }

    public void SetDishIconsAtGameStart(List<Dish> dishes)
    {
        DishIcon dishIcon;
        Dish dish;
        string dishName;
        Sprite sprite;

        for (int i = 0; i < 3; i++)
        {
            dish = dishes[i];
            dishIcon = DishIconList[i].GetComponent<DishIcon>();

            sprite = dish.sprite ?? defaultSprite;
            dishName = dish.DishName ?? defaultText;
            
            dishIcon.ChangeData(sprite, dishName);
            SlideDishTileToLeft(dishIcon, i);
        }
    }

    public void OnDishCompleted()
    {
        var dish = DishIconList[0];
        dish.transform.DOMove(Vector3.down * 100, 1.5f).SetEase(Ease.OutQuad);
        DishIconList.RemoveAt(0);
        DishIconList.Add(dish);
    }

    public void DisplayNewDish(Dish newDish)
    {
        var lastIndex = DishIconList.Count - 1;
        var dishIcon = DishIconList[lastIndex].GetComponent<DishIcon>();
        dishIcon.ChangeData(newDish.sprite, newDish.DishName);
    }


    private void SlideDishTileToLeft(DishIcon dishIcon, int index)
    {
        dishIcon.transform.DOMove(QueuePositions[index].position, 1.5f).SetEase(Ease.OutQuad);
       // dishIcon.Image.material.DOColor(visible, TweenSpeed);
    }




}
