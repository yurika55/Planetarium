//画像を一枚一枚表示
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgIndicate : MonoBehaviour
{
    private Talk006 talkScript; // Talk006スクリプトへの参照を保持する変数
    public GameObject[] Img = new GameObject[6];
    public float displayInterval = 1.0f;
    //public int hiddenInterval = 0; // 画像を表示する間隔（秒）

    // Start is called before the first frame update
    void Start()
    {
        //Talksystemゲームオブジェクトを検索し、Talk006スクリプトの参照を取得
        GameObject talkSystemObject = GameObject.Find("Talksystem");
        if(talkSystemObject != null)
        {
            talkScript = talkSystemObject.GetComponent<Talk006>();
            //Debug.log("コンポーネント取得");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (talkScript != null && talkScript.IsImgFind)
        {
            StartCoroutine(ImgsAppear());
        }
        
      
    }

    //Imgを表示させるコール珍
    private IEnumerator ImgsAppear()
    {
        // 一度実行したら、再実行しないようにするためにフラグをリセット
        talkScript.SetImgFind(false);

        foreach (GameObject img in Img)
        {
            Debug.Log("jikkou");
            img.SetActive(true); // 画像を表示
            yield return new WaitForSeconds(displayInterval); // 指定された間隔で待機
            img.SetActive(false);
            Debug.Log("jikkouend");
        }

        
    }
}
