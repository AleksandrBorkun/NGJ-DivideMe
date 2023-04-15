using System.Collections.Generic;
using UnityEngine;

public class IngridientsSpawner : MonoBehaviour
{
    
    public GameObject[] ingridientsList;

    public Data.Ingridients[] initialIngridientsToSpawn;

    private void Start()
    {
        SpawnNext(initialIngridientsToSpawn);
    }

    public void SpawnNext(Data.Ingridients[] ingridients)
    {

        Dictionary<int, Data.Ingridients> spawnPoints = new Dictionary<int, Data.Ingridients>();

        // find random position for each ingridient
        // makking sure that this position is not taken
        Debug.Log("find random position for each ingridient");
        for(int i = 0; i< ingridients.Length; i++)
        {
            int spawnPoint = Random.Range(0, transform.childCount);
            Data.Ingridients ingridient;
            //while (!spawnPoints.TryGetValue(spawnPoint, out ingridient))
            //{
            //    spawnPoint = Random.Range(0, transform.childCount);
            //}

            ingridient = ingridients[i];
            spawnPoints.Add(spawnPoint, ingridient);

        }

        Debug.Log("spawn ingridients");
        // spawn ingridients
        foreach (KeyValuePair<int, Data.Ingridients> ingridient in spawnPoints)
        {
            //GameObject ingridientObj;
            //ingridientsMap.TryGetValue(ingridient.Value, out ingridientObj);

            if (ingridientsList[((int)ingridient.Value)])
            {
                Instantiate(ingridientsList[((int)ingridient.Value)], transform.GetChild(ingridient.Key));
            }
            else
            {
                Debug.LogErrorFormat("Object is not specified for a ingridient type {0} on the {1}", ingridient.Value, transform.name);
            }
        }


    }
}
