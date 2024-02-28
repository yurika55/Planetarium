//アニメーションのHideがONになるとオブジェクトが非表示になるコード
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideobjects : MonoBehaviour
{
    //animationを入れる箱
    public Animator dogani;

    void Update()
    {
        // "Dogani" ゲームオブジェクトが見つかっており、Animator コンポーネントがアタッチされている場合
        if (dogani != null)
        {
            // "Hide" パラメーターが true になったらオブジェクトを非アクティブにする
            if (dogani.GetBool("Hide"))
            {
                Hide();
            }
        }
        
    }

//オブジェクトを非表示にする関数
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
