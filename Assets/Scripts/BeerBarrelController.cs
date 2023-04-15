using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBarrelController : MonoBehaviour
{

    public float normalDrinkSpeed = .02f;
    public float drunkDrinkSpeed = .05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {

        var player = collision.gameObject.GetComponent<Player>();

        if (player && player.drunkenness < 0.8)
        {
            player.drunkenness += normalDrinkSpeed * Time.deltaTime;
        }
        else if(player && player.drunkenness < .99)
        {
            player.drunkenness += drunkDrinkSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Player Drunk! Do Something");
        }
    }
}
