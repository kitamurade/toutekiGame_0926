using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resultSceneController : MonoBehaviour
{
    //各種オブジェクトの生成
    public GameObject ScoreTextObject;
    public GameObject gameResultObject;
    // Start is called before the first frame update
    void Start()
    {
        //各種結果をオブジェクトに渡す
        this.ScoreTextObject.GetComponent<TextMeshProUGUI>().text = "SCORE " + sceneData.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
