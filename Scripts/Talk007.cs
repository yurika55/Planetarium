//会話シーンのコード(Place6というシーンで使用)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk007 : MonoBehaviour
{
    [SerializeField] [Header("トーク")] private string[] msgContent1;// 会話シーン１
    public float waittimer = 0.5f;//1文字に対する時間
    GameObject objCanvas = null;
    public Animator animator;
 
    //スイッチの状態を保持する変数
    private bool cafefind = false;
    public int cafefindnum = 0;
    
    void Start()
    {
        objCanvas = gameObject.transform.Find("Canvas").gameObject;
        objCanvas.SetActive(false);
        StartCoroutine(ShowLog());
    }
 
 
    IEnumerator ShowLog()
    {
        //文字を表示するブロックを探す
        GameObject objContent = objCanvas.transform.Find("Content").gameObject;
        objCanvas.SetActive(true);

        //数秒待つ
        yield return new WaitForSeconds(3.0f);

        //会話
        for (int i = msgContent1.GetLowerBound(0); i <= msgContent1.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent1[i];
            string str = msgContent1[i];
            int characterCount = str.Length;
            //Debug.Log($"Length of {str}: {characterCount}");
 
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waittime(characterCount));

            //arrowを表示させる
            if(i == cafefindnum)
            {
                SetCafeFind(true);
            }
            else
            {
                SetCafeFind(false);
                
            }

            yield return null;
        } 

        objCanvas.SetActive(false);
        //yield return new WaitForSeconds(30.0f);
        if (animator != null)
        {
            animator.SetBool("Hide", true);
        }
        else
        {
            Debug.LogWarning("Animator not assigned in Talk007 script.");
        }
        
    }

    //文字の表示時間の計算
    public float waittime(int chrcount)
    {
        float mojitime = chrcount * waittimer;
        //Debug.Log($"Length {chrcount}: mojitime{mojitime}");
        return mojitime;
    }

    //Cafeの矢印のON/OFF
    public void SetCafeFind(bool status)
    {
        cafefind = status;
    }

    public bool IsCafeFind
    {
        get {return cafefind; }
    }

    

}
