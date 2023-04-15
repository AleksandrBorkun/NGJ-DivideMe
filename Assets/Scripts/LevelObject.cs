using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelObject", order = 1)]
public class LevelObject : ScriptableObject
{
    public int numberOfDishes;
    public Dish[] dishes;
    public int levelSpeed = 3;
    public int time;
}
