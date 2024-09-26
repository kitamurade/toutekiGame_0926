using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{
    //クラスの唯一のインスタンスを保持するための静的な変数
    public static scoreScript instance;
    //スコアを表示するためのtextコンポーネントとトータルスコア
    private TextMeshProUGUI scoreText;//
    private int totalScore = 0;
    //プライベートコンストラクタ
    void Awake()
    {
        //インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//シーンをまたいでもインスタンスを保持
            SceneManager.sceneLoaded += OnSceneLoaded;//シーンがロードされた時に呼び出されるイベントを登録
        }
        //既に存在する場合は新しいインスタンスを破棄
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Initialize();
    }
    //反映されるためのメソッドを定義
    //スコアを更新して、textコンポーネントに反映する
    public void ScoreManeger(int score)
    {
        totalScore += score;
        //コンポーネントを表示する
        UpdataScoreText();
    }
    //スコアをtextコンポーネントに表示するメソッド
    private void UpdataScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + totalScore.ToString();
        }
    }
    //トータルのスコア
    public int GetCurrentScore()
    {
        return totalScore;
    }
    //初期化
    public void Initialize()
    {
        //スコアのタグを取得し、スコアを初期化させる
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");

        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdataScoreText();
        }
    }
    //シーンが呼び出されたときにイベントを登録
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //シーンがロードされたあと再初期化
        StartCoroutine(InitializeAfterFrame());
    }
    private IEnumerator InitializeAfterFrame()
    {
        //フレームが終わるまで待つ
        yield return null;
        Initialize();
    }
    //イベントの解除
    private void OnDestroy()
    {
        //解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
