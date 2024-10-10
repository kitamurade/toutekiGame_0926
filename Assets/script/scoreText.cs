using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class scoreText : MonoBehaviour
{
    private TextMeshProUGUI scoretext;
    private int scorepoint;
    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
