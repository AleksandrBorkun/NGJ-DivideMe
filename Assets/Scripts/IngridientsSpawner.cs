using System.Collections.Generic;
using UnityEngine;

public class IngridientsSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnNext(Ingridient[] ingridients)
    {

        KeyValuePair<int, Ingridient> spawnPoints = new KeyValuePair<int, Ingridient>();
        for(int i = 0; i< ingridients.Length; i++)
        {
            int spawnPoint = Random.RandomRange(0, transform.childCount);
            //while (spawnPoints[]) {
            //} 
        }
        
    }
}
