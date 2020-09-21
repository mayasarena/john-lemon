using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;
    public float maxTime;
    public Text timerText;
    public GameEnding gameEnding;

    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) // decrement time
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("0.00"); // update text
        }
        else if (timer <= 0) {
            gameEnding.TimesUp();
        }
    }
}
