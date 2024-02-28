//会話シーンのコード(Place5というシーンで使用)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk006 : MonoBehaviour
{
    [SerializeField] [Header("トーク1")] private string[] msgContent1;//会話シーン１
    [SerializeField] [Header("トーク2")] private string[] msgContent2;//会話シーン２
    public float waittimer = 0.5f;//1文字に対する時間
    GameObject objCanvas = null;
    public Animator animator;
    public float ImgIndicateTime = 6.0f;

    //スイッチの状態を保持する変数
    private bool imgfind = false;
    public int imgfindnum = 0;
 
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

        //会話シーン１
        for (int i = msgContent1.GetLowerBound(0); i <= msgContent1.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent1[i];
            string str = msgContent1[i];
            int characterCount = str.Length;
            //Debug.Log($"Length of {str}: {characterCount}");
 
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waittime(characterCount));

            //画像を表示させる
            if(i == imgfindnum)
            {
                SetImgFind(true);
            }
            else
            {
                SetImgFind(false);
            } 
  
            yield return null;
        }

        yield return new WaitForSeconds(ImgIndicateTime);

        //会話シーン２
        for (int i = msgContent2.GetLowerBound(0); i <= msgContent2.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent2[i];
            string str = msgContent2[i];
            int characterCount = str.Length;
            //Debug.Log($"Length of {str}: {characterCount}");
 
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waittime(characterCount));
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
            Debug.LogWarning("Animator not assigned in Talk006 script.");
        }
        
    }

    //文字の表示時間の計算
    public float waittime(int chrcount)
    {
        float mojitime = chrcount * waittimer;
        //Debug.Log($"Length {chrcount}: mojitime{mojitime}");
        return mojitime;
    }

    //画像のON/OFF
    public void SetImgFind(bool status)
    {
        imgfind = status;
    }
    public bool IsImgFind
    {
        get {return imgfind; }
    }

    
}
