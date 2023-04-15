using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishIcon : MonoBehaviour
{
    Image image;
    TextMeshProUGUI name;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        name = GetComponent<TextMeshProUGUI>();
    }

    void OnDisplay(Dish dish)
    {
        //image = dish.image;
        //name = dish.name;
    }




}
