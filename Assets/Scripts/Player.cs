using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    public float drunkenness; // Between 0.0 and 1.0

    [SerializeField] SimpleSampleCharacterControl characterController;
    [SerializeField] private AudioClip pickupAudioClip;
    [SerializeField] private AudioClip yawnAudioClip;
    [SerializeField] private AudioClip drunkAudioClip;


    public GameObject tooDrunkEffect;
    public GameObject tooDryEffect;

    private bool isDrunkTriggered = false;
    private bool isDryTriggered = false;

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

            // TODO On screen sound: Too sober. Boring!
            if (!isDryTriggered)
            {
                isDryTriggered = true;
                Instantiate(tooDryEffect, GameManager.Instance.gameObject.transform);
                AudioSource.PlayClipAtPoint(yawnAudioClip, new Vector3(0, 0, 0));
            }
            characterController.moveSpeedModifier = 0.5f;
        }
        else if (drunkenness > 0.8f)
        {
            // TODO: On screen sound: Too drunk! Wtf!
            if (!isDrunkTriggered)
            {
                isDrunkTriggered = true;
                Instantiate(tooDrunkEffect, GameManager.Instance.gameObject.transform);
                AudioSource.PlayClipAtPoint(drunkAudioClip, new Vector3(0, 0, 0));
            }
            characterController.moveSpeedModifier = 4f;
        }
        else
        {
            characterController.moveSpeedModifier = 1f;
            isDryTriggered = false;
            isDrunkTriggered = false;
        }
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
