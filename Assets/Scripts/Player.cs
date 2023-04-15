using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    public float drunkenness; // Between 0.0 and 1.0

    [SerializeField] SimpleSampleCharacterControl characterController;
    [SerializeField] private AudioClip pickupAudioClip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ModifyMoveSpeed();
    }

    private void ModifyMoveSpeed()
    {
        if (drunkenness < 0.3f)
        {
            // walk slower
            characterController.moveSpeedModifier = 0.5f;
        }
        else
        {
            characterController.moveSpeedModifier = 1f;
        }
    }

    void PlayerUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        var ingredient = other.gameObject.GetComponent<Ingridient>();
        if (ingredient == null) { return; }

        inventory.inventory.Add(ingredient.ingridientName);
        AudioSource.PlayClipAtPoint(pickupAudioClip, new Vector3(0, 0, 0));
        Destroy(other.gameObject);
        inventory.LogContents();

    }
}
