using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resultSceneController : MonoBehaviour
{
    //�e��I�u�W�F�N�g�̐���
    public GameObject ScoreTextObject;
    public GameObject gameResultObject;
    // Start is called before the first frame update
    void Start()
    {
        //�e�팋�ʂ��I�u�W�F�N�g�ɓn��
        this.ScoreTextObject.GetComponent<TextMeshProUGUI>().text = "SCORE " + sceneData.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
