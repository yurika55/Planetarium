//会話シーンのコード(Place1というシーンで使用)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk002 : MonoBehaviour
{
    [SerializeField] [Header("トーク")] private string[] msgContent1;//会話シーン
    public float waittimer = 0.5f;//1文字に対する時間
    GameObject objCanvas = null;
    public Animator animator;
 
    //スイッチの状態を保持する変数
    private bool cafefind = false;//矢印１の表示のON/OFF
    public int cafefindnum = 0;
    private bool campfind = false;//矢印２の表示のON/OFF
    public int campfindnum = 0;

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

        //会話シーン
        for (int i = msgContent1.GetLowerBound(0); i <= msgContent1.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent1[i];
            string str = msgContent1[i];
            int characterCount = str.Length;
            //Debug.Log($"Length of {str}: {characterCount}");
 
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waittime(characterCount));

            //矢印１・２を表示させる
            if(i == cafefindnum)
            {
                SetCafeFind(true);
            }
            else if(i == campfindnum)
            {
                SetCampFind(true);
            }
            else
            {
                SetCafeFind(false);
                SetCampFind(false);
            }

            yield return null;
        } 

        objCanvas.SetActive(false);
        
        if (animator != null)
        {
            animator.SetBool("Hide", true);
        }
        else
        {
            Debug.LogWarning("Animator not assigned in Talk002 script.");
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

    //Campの矢印のON/OFF
    public void SetCampFind(bool status)
    {
        campfind = status;
    }

    public bool IsCampFind
    {
        get {return campfind; }
    }

}
