using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int points;
    public int DelayInMilisec;

    bool nextLoop;
    int target = 0;

    private void Start()
    {
        counter.text = points.ToString();
    }

    public void ResetCounter()
    {
        points = 0;
    }

    public void UpdateCounter(int newPoints)
    {
        target = points + newPoints;
        nextLoop = true;
        print("target is: " + target);
    }

    private async void UpdatePoints()
    {
        if (points < target && nextLoop)
        {
            nextLoop = false;
            await Task.Delay((int)(DelayInMilisec));
            points++;
            counter.text = points.ToString();
            nextLoop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }
}
