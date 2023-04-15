using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishIcon : MonoBehaviour
{
    Image Image;
    TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Image = transform.Find("Icon").GetComponent<Image>();
        Text = transform.Find("Name").GetComponent<TextMeshProUGUI>();
    }

    public void ChangeData(Sprite sprite, string text)
    {
       Image.sprite = sprite;
       Text.text = text;
    }




}
