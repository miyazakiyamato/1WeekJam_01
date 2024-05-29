using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneLoader : MonoBehaviour
{
    // フェード用のUIパネル
    public Image fadePanel;
    // フェードの完了にかかる時間
    public float fadeDuration = 1.0f;
    // 次のシーンの変数
    public string nextSceneName;
    // シーン遷移をするかのフラグ
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
        // パネルを有効化
        fadePanel.enabled = true;
        // 時間経過を初期化
        float elapsedTime = 0.0f;
        // フェードパネルの開始色を取得
        Color startColor = fadePanel.color;
        // フェードパネルの最終色を設定
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            // 経過時間を増やす
            elapsedTime += Time.deltaTime;
            // フェードの進行度を計算
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            // パネルの色を変更してフェードアウト
            fadePanel.color = Color.Lerp(startColor, endColor, t);
            // 1フレーム待機
            yield return null;
        }
        // フェードが完了したら最終色に設定
        fadePanel.color = endColor;
        // シーンをロードして次のシーンに遷移する
            SceneManager.LoadScene(nextSceneName);
    }
}
