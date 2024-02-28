using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MonoBehaviour
{
    private Talk002 talkScript; // Talk002スクリプトへの参照を保持する変数
    GameObject arrowObject1;
    GameObject arrowObject2;

    void Start()
    {
        
        // Talksystemゲームオブジェクトを検索し、Talk002スクリプトの参照を取得
        GameObject talkSystemObject = GameObject.Find("Talksystem");
        if (talkSystemObject != null) // ゲームオブジェクトが見つかったか確認
        {
            talkScript = talkSystemObject.GetComponent<Talk002>(); // Talk002コンポーネントを取得
            Debug.Log("コンポーネント取得");
        }

        // arrowオブジェクトを検索
        arrowObject1 = GameObject.Find("arrow1");
        arrowObject2 = GameObject.Find("arrow2");
        if (arrowObject1 == null && arrowObject2 == null)
        {
            Debug.LogError("arrowオブジェクトが見つかりませんでした。");
        }
    }

    void Update()
    {
        // Talk002スクリプトのIsCafeFindプロパティがtrueになったか確認
        if (talkScript != null && talkScript.IsCafeFind)
        {
           arrowObject1.SetActive(true);
           //Debug.Log("arrow1コンポーネント実行");
        }
        else if(talkScript != null && talkScript.IsCampFind)
        {
            arrowObject2.SetActive(true);
            //Debug.Log("arrow2コンポーネント実行");
        }
        else
        {
            arrowObject1.SetActive(false);
            arrowObject2.SetActive(false);
        }
    }

   
}