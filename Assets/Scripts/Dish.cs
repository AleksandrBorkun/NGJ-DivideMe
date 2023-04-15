
using UnityEngine;

[CreateAssetMenu(fileName = "Dish", menuName = "ScriptableObjects/DishObject", order = 2)]
public class Dish : ScriptableObject
{

    [SerializeField]
    private Data.Ingridients[] ingridients;
    public string DishName;
    public Sprite sprite;


    public Data.Ingridients[] GetRecipe()
    {
        return ingridients;
    }
}
