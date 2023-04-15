using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingridient : MonoBehaviour
{

    public Data.Ingridients ingridientName;


    // Start is called before the first frame update
    void Start()
    {
        if (ingridientName == Data.Ingridients.UNSET) Debug.LogErrorFormat("Ingridient Name is Not set for object {0}", transform.name);
    }

}
