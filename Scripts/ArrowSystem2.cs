//place3の矢印を表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSystem2 : MonoBehaviour
{
    private Talk004 talkScript; // スクリプトへの参照を保持する変数
    GameObject arrowObject1;
    

    void Start()
    {
        
        // Talksystemゲームオブジェクトを検索し、Talk002スクリプトの参照を取得
        GameObject talkSystemObject = GameObject.Find("Talksystem");
        if (talkSystemObject != null) // ゲームオブジェクトが見つかったか確認
        {
            talkScript = talkSystemObject.GetComponent<Talk004>(); // Talk002コンポーネントを取得
            Debug.Log("コンポーネント取得");
        }

        // arrowオブジェクトを検索
        arrowObject1 = GameObject.Find("arrow1");
        if (arrowObject1 == null)
        {
            Debug.LogError("arrowオブジェクトが見つかりませんでした。");
        }
    }

    void Update()
    {
        // スクリプトのIsCafeFindプロパティがtrueになったか確認
        if (talkScript != null && talkScript.IsCafeFind)
        {
           arrowObject1.SetActive(true);
           //Debug.Log("arrow1コンポーネント実行");
        }
        else
        {
            arrowObject1.SetActive(false);
        }
    }

   
}