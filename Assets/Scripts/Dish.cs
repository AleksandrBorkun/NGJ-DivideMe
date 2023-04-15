
using UnityEngine;

public class Dish : MonoBehaviour
{

    [SerializeField]
    private Data.Ingridients[] ingridients;

    public Data.Ingridients[] GetRecipe()
    {
        return ingridients;
    }
}
