using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    //�B��̃C���X�^���X�Ƃ��ĐÓI�ϐ��𐶐�
    public static GameManeger instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    //�X�^�[�g���\�b�h
    public void StartGame()
    {
        sceneData.score = 0;
        SceneManager.LoadScene("gameScene");
    }
    //�G���h���\�b�h
    public void EndGame(int igaguris)
    {
        //�l�������X�R�A�ƃ��U���g��ʂ֑J��
        sceneData.score = scoreScript.instance.GetCurrentScore();
        sceneData.totalIgaguris = igaguris;
        SceneManager.LoadScene("resultScene");
    }
    //���X�^�[�g���\�b�h
    public void ResetGame()
    {
        sceneData.score = 0;
        sceneData.totalIgaguris = 0;

        //���ׂẴu���b�N���폜
        GameObject[] Igaguris = GameObject.FindGameObjectsWithTag("Igaguris");

        foreach (GameObject gameObject in Igaguris)
        {
            Destroy(gameObject);
        }

        //�X�R�A�̏�����
        if (scoreScript.instance != null)
        {
            scoreScript.instance.ScoreManeger(-scoreScript.instance.GetCurrentScore());
        }
    }
}
