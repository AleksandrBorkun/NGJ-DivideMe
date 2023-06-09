using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class DishQueueViewer : MonoBehaviour
{
    //tween to move ui to the left
    //tween to drop dish mqde or failed
    public int DishIconNb;
    public List<DishIcon> DishIconList;
    public List<Transform> QueuePositions;
    public List<Transform> DropPositions;

    public TextMeshProUGUI dishCounter;
    public Sprite defaultSprite;
    public string defaultText;
    public float TweenSpeed;
    public Color invisible = new Color(255, 255, 255, 0);
    public Color visible = new Color(255, 255, 255, 1);

    // Start is called before the first frame update
    void Start()
    {
        dishCounter.text = "0";
    }

    public void UpdateCounter(int remainingDishes)
    {
        dishCounter.text = remainingDishes.ToString();
    }

    public async void SetDishIconsAtLevelStart(List<Dish> dishes)
    {
        DishIcon dishIcon = default;
        Dish dish;
        string dishName;
        Sprite sprite;

        var index = dishes.Count > DishIconNb ? DishIconNb : dishes.Count;

        for (int i = 0; i < index; i++)
        {
            dish = dishes[i];
            dishIcon = DishIconList[i].GetComponent<DishIcon>();

            sprite = dish.sprite ?? defaultSprite;
            dishName = dish.DishName ?? defaultText;

            dishIcon.ChangeData(sprite, dishName);
        }

        for (int i = 0; i < index; i++)
        {
            await SlideDishTileToLeftAsync(DishIconList[i], i, TweenSpeed);
        }
    }
    public async Task DropDishIcon()
    {
        var dishIcon = DishIconList[0];
        await dishIcon.transform.DOMove(DropPositions[0].position, 1f).SetEase(Ease.OutQuad).AsyncWaitForCompletion();
        DishIconList.RemoveAt(0);
        DishIconList.Add(dishIcon);
        dishIcon.transform.position = DropPositions[1].position;
        dishIcon.enabled = false;
    }

    public async void HandleDropAllDishIcon()
    {
        await DropAllDishIcon();
    }

    public async Task DropAllDishIcon()
    {  
        DishIconList[0].transform.DOMove(DishIconList[0].transform.position + Vector3.down * 1000, 1f).SetEase(Ease.OutQuad);
        DishIconList[1].transform.DOMove(DishIconList[0].transform.position + Vector3.down * 1000, 1f).SetEase(Ease.OutQuad);
        await DishIconList[2].transform.DOMove(DishIconList[0].transform.position + Vector3.down * 1000, 1f).SetEase(Ease.OutQuad).AsyncWaitForCompletion();

        DishIconList[0].transform.position = DropPositions[1].position;
        DishIconList[1].transform.position = DropPositions[1].position;
        DishIconList[2].transform.position = DropPositions[1].position;

        DishIconList[0].enabled = false;
        DishIconList[1].enabled = false;
        DishIconList[2].enabled = false;
    }

    public void DisplayNewDish(Dish newDish)
    {
        SlideDishTileToLeft(DishIconList[0], 0, TweenSpeed);
        SlideDishTileToLeft(DishIconList[1], 1, TweenSpeed);

        var lastIndex = DishIconList.Count - 1;
        var dishIcon = DishIconList[lastIndex].GetComponent<DishIcon>();
        dishIcon.enabled = true;
        dishIcon.ChangeData(newDish.sprite, newDish.DishName);

        SlideDishTileToLeft(DishIconList[2], 2, TweenSpeed);
    }

    private async Task SlideDishTileToLeftAsync(DishIcon dishIcon, int index, float speed)
    {
        await dishIcon.transform.DOMove(QueuePositions[index].position, speed).SetEase(Ease.OutQuad).AsyncWaitForCompletion();
        // dishIcon.Image.material.DOColor(visible, TweenSpeed);
    }

    private void SlideDishTileToLeft(DishIcon dishIcon, int index, float speed)
    {
        dishIcon.transform.DOMove(QueuePositions[index].position, speed).SetEase(Ease.OutQuad);
        // dishIcon.Image.material.DOColor(visible, TweenSpeed);
    }
}
