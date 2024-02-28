using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public float fadeOutDuration = 2.0f;
    public float waittime = 10.0f;
    GameObject dog;
    Animator dogani;
    private bool isset = false; // フラグ


    void Start()
    {
        // BGMを再生する
        bgmAudioSource.Play();
         // ゲームオブジェクト「Dog」を見つける
        dog = GameObject.Find("Dog");

        // Animator コンポーネントを取得
        if (dog != null) // dogが見つかった場合
        {
            dogani = dog.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Dog object not found!");
        }
    }

    void Update()
    {
        //もしHideがONになったらdelay後にシーンを切り替える
        if (dogani != null && dogani.GetBool("Hide") && !isset)
        {
            isset = true;
            StartCoroutine(FadeOutBGM());
            Debug.Log("i");
        }
    }

    IEnumerator FadeOutBGM()
    {
        float startVolume = bgmAudioSource.volume;

        yield return new WaitForSeconds(waittime);

        while (bgmAudioSource.volume > 0)
        {
            bgmAudioSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        // フェードアウト完了後、再生を停止
        bgmAudioSource.Stop();
        bgmAudioSource.volume = startVolume; // 初期の音量に戻す
    }
}
