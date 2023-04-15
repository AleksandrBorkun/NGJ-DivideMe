
using UnityEngine;

public class Dish : MonoBehaviour
{

    [SerializeField]
    private Ingridient[] ingridients;

    public Ingridient[] GetRecipe()
    {
        return ingridients;
    }
}
