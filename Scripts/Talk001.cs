//会話シーンのコード(Place0というシーンで使用)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk001 : MonoBehaviour
{
    //寝ているシーン
    [SerializeField] [Header("眠ってる")] private string[] msgContent1;
    //会話シーン
    [SerializeField] [Header("メッセージ（内容）")] private string[] msgContent2;
    //寝ているシーンの要素の待ち時間
    public float delay = 1.0f;
    //1文字に対する時間
    public float waittimer = 0.5f;
    GameObject objCanvas = null;
    public Animator animator;
 
    void Start()
    {
        objCanvas = gameObject.transform.Find("Canvas").gameObject;
        objCanvas.SetActive(false);
        StartCoroutine(ShowLog());
    }
 
 
    IEnumerator ShowLog()
    {
        GameObject objContent = objCanvas.transform.Find("Content").gameObject;
 
        objCanvas.SetActive(true);

        //寝ているシーン
        for (int i = msgContent1.GetLowerBound(0); i <= msgContent1.GetUpperBound(0); i++)
        {
            
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent1[i];
 
            yield return new WaitForSeconds(delay);

            yield return null;
        }

        //寝ているシーンと会話シーンの待ち時間
        animator.SetTrigger("wakeup");
        yield return new WaitForSeconds(4.5f);

        //会話シーン
        for (int i = msgContent2.GetLowerBound(0); i <= msgContent2.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent2[i];
            string str = msgContent2[i];
            int characterCount = str.Length;
            Debug.Log($"Length of {str}: {characterCount}");
 
            //会話終わりにSEを再生
            GetComponent<AudioSource>().Play();
            //waittime関数による次の文章までの待ち時間
            yield return new WaitForSeconds(waittime(characterCount));
            yield return null;
        } 
        
        animator.SetTrigger("walk");
        yield return new WaitForSeconds(2.0f);
        animator.SetBool("Hide",true);
        

        objCanvas.SetActive(false);
    }

    public float waittime(int chrcount)
    {
        float mojitime = chrcount * waittimer;
        Debug.Log($"Length {chrcount}: mojitime{mojitime}");
        return mojitime;
    }


}
