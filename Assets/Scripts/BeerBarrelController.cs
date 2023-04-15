using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBarrelController : MonoBehaviour
{

    public float normalDrinkSpeed = .1f;
    public float drunkDrinkSpeed = .15f;


    private void OnTriggerStay(Collider colider)
    {

        var player = colider.gameObject.GetComponent<Player>();

        if (player && player.drunkenness < 0.7)
        {
            Debug.Log("drinking...");
            player.drunkenness += normalDrinkSpeed * Time.deltaTime;
        }
        else if(player && player.drunkenness < .99)
        {
            Debug.Log("drinking...");
            player.drunkenness += drunkDrinkSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Player Drunk! Do Something");
        }
    }
}
