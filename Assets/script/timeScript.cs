using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class timeScript : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float timer;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timer = 10;
    }
    void Update()
    {
        timer-= Time.deltaTime;
        timerText.text = timer.ToString("f2");

        if(timer <= 0)
        {
            SceneManager.LoadScene("resultScene");
            GameManeger.instance.EndGame();

        }
    }
}
