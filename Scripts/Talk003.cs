using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk003 : MonoBehaviour
{
    [SerializeField] [Header("トーク")] private string[] msgContent1;
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

    
}
