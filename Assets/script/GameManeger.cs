using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    //唯一のインスタンスとして静的変数を生成
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
    //スタートメソッド
    public void StartGame()
    {
        sceneData.score = 0;
        SceneManager.LoadScene("gameScene");
    }
    //エンドメソッド
    public void EndGame(int igaguris)
    {
        //獲得したスコアとリザルト画面へ遷移
        sceneData.score = scoreScript.instance.GetCurrentScore();
        sceneData.totalIgaguris = igaguris;
        SceneManager.LoadScene("resultScene");
    }
    //リスタートメソッド
    public void ResetGame()
    {
        sceneData.score = 0;
        sceneData.totalIgaguris = 0;

        //すべてのブロックを削除
        GameObject[] Igaguris = GameObject.FindGameObjectsWithTag("Igaguris");

        foreach (GameObject gameObject in Igaguris)
        {
            Destroy(gameObject);
        }

        //スコアの初期化
        if (scoreScript.instance != null)
        {
            scoreScript.instance.ScoreManeger(-scoreScript.instance.GetCurrentScore());
        }
    }
}
