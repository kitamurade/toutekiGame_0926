using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{
    //�N���X�̗B��̃C���X�^���X��ێ����邽�߂̐ÓI�ȕϐ�
    public static scoreScript instance;
    //�X�R�A��\�����邽�߂�text�R���|�[�l���g�ƃg�[�^���X�R�A
    private TextMeshProUGUI scoreText;//
    private int totalScore = 0;
    //�v���C�x�[�g�R���X�g���N�^
    void Awake()
    {
        //�C���X�^���X�����݂��Ȃ��ꍇ�͂��̃C���X�^���X��ݒ�
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//�V�[�����܂����ł��C���X�^���X��ێ�
            SceneManager.sceneLoaded += OnSceneLoaded;//�V�[�������[�h���ꂽ���ɌĂяo�����C�x���g��o�^
        }
        //���ɑ��݂���ꍇ�͐V�����C���X�^���X��j��
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Initialize();
    }
    //���f����邽�߂̃��\�b�h���`
    //�X�R�A���X�V���āAtext�R���|�[�l���g�ɔ��f����
    public void ScoreManeger(int score)
    {
        totalScore += score;
        //�R���|�[�l���g��\������
        UpdataScoreText();
    }
    //�X�R�A��text�R���|�[�l���g�ɕ\�����郁�\�b�h
    private void UpdataScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + totalScore.ToString();
        }
    }
    //�g�[�^���̃X�R�A
    public int GetCurrentScore()
    {
        return totalScore;
    }
    //������
    public void Initialize()
    {
        //�X�R�A�̃^�O���擾���A�X�R�A��������������
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");

        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdataScoreText();
        }
    }
    //�V�[�����Ăяo���ꂽ�Ƃ��ɃC�x���g��o�^
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //�V�[�������[�h���ꂽ���ƍď�����
        StartCoroutine(InitializeAfterFrame());
    }
    private IEnumerator InitializeAfterFrame()
    {
        //�t���[�����I���܂ő҂�
        yield return null;
        Initialize();
    }
    //�C�x���g�̉���
    private void OnDestroy()
    {
        //����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
