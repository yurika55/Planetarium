using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideobjects : MonoBehaviour
{
    public Animator dogani;


    void Start()
    {
        
    }

    void Update()
    {
        // "Dog" ゲームオブジェクトが見つかっており、Animator コンポーネントがアタッチされている場合
        if (dogani != null)
        {
            // "Hide" パラメーターが true になったらオブジェクトを非アクティブにする
            if (dogani.GetBool("Hide"))
            {
                Hide();
            }
        }
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
