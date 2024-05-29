using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneLoader : MonoBehaviour
{
    // �t�F�[�h�p��UI�p�l��
    public Image fadePanel;
    // �t�F�[�h�̊����ɂ����鎞��
    public float fadeDuration = 1.0f;
    // ���̃V�[���̕ϐ�
    public string nextSceneName;
    // �V�[���J�ڂ����邩�̃t���O
    public bool isFade = false;
    // SE
    public AudioSource audioSouce;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFade = true;
            audioSouce.Play();
        }
        if (isFade)
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    public void CallCoroutine()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        // �p�l����L����
        fadePanel.enabled = true;
        // ���Ԍo�߂�������
        float elapsedTime = 0.0f;
        // �t�F�[�h�p�l���̊J�n�F���擾
        Color startColor = fadePanel.color;
        // �t�F�[�h�p�l���̍ŏI�F��ݒ�
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            // �o�ߎ��Ԃ𑝂₷
            elapsedTime += Time.deltaTime;
            // �t�F�[�h�̐i�s�x���v�Z
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            fadePanel.color = Color.Lerp(startColor, endColor, t);
            // 1�t���[���ҋ@
            yield return null;
        }
        // �t�F�[�h������������ŏI�F�ɐݒ�
        fadePanel.color = endColor;
        // �V�[�������[�h���Ď��̃V�[���ɑJ�ڂ���
            SceneManager.LoadScene(nextSceneName);
    }
}
