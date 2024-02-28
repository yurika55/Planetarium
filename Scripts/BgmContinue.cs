//BGMをシーンチェンジ後もながすコード
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManagerを使用するために必要

public class BgmContinue : MonoBehaviour
{
    private static BgmContinue instance = null;
    private AudioSource audioSource; // AudioSourceをキャッシュするための変数

    void Awake()
    {
        // 既にインスタンスが存在するかチェック
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            // シーンがロードされたときのイベントリスナーを追加
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // シーンがロードされたときに呼ばれるメソッド
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンのインデックスが0の場合は音楽を停止
        if (scene.buildIndex == 0)
        {
            StopMusic();
        }
        else if (scene.buildIndex == 2)
        {
            PlayMusic();
        }
    }

    private void StopMusic()
    {
        // AudioSourceコンポーネントを取得
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        // 必要に応じて、他のクリーンアップ処理をここに追加
    }

    private void PlayMusic()
    {
        // AudioSourceコンポーネントを取得
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


    void OnDestroy()
    {
        // インスタンスが破棄される時、イベントリスナーを削除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
