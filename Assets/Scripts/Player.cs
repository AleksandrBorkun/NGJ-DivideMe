using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        var ingredient = other.gameObject.GetComponent<Ingridient>();
        if (ingredient == null) { return; }

        inventory.inventory.Add(ingredient.ingridientName);

        Destroy(other.gameObject);

        inventory.LogContents();

    }
}
