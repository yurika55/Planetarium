using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Talk001 : MonoBehaviour
{
    //[SerializeField] [Header("メッセージ（キャラ名）")] private string[] msgCaraName;
    [SerializeField] [Header("眠ってる")] private string[] msgContent1;
    [SerializeField] [Header("メッセージ（内容）")] private string[] msgContent2;
    public float delay = 1.0f;
    public float waittimer = 0.5f;
    GameObject objCanvas = null;
    public Animator animator;
 
    void Start()
    {
        objCanvas = gameObject.transform.Find("Canvas").gameObject;
        objCanvas.SetActive(false);
        StartCoroutine(ShowLog());
    }
 
    void Update()
    {
        
    }
 
    IEnumerator ShowLog()
    {
        //GameObject objCaraName = objCanvas.transform.Find("CaraName").gameObject;
        GameObject objContent = objCanvas.transform.Find("Content").gameObject;
 
        objCanvas.SetActive(true);
 
        for (int i = msgContent1.GetLowerBound(0); i <= msgContent1.GetUpperBound(0); i++)
        {
            //objCaraName.GetComponent<Text>().text = msgCaraName[i];
            //objContent.GetComponent<Text>().text = msgContent[i];
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent1[i];
 
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitForSeconds(delay);

            yield return null;
        }

        animator.SetTrigger("wakeup");
        yield return new WaitForSeconds(4.5f);

        
        for (int i = msgContent2.GetLowerBound(0); i <= msgContent2.GetUpperBound(0); i++)
        {
            TextMeshProUGUI textMeshComponent = objContent.GetComponent<TextMeshProUGUI>();
            textMeshComponent.text = msgContent2[i];
            string str = msgContent2[i];
            int characterCount = str.Length;
            Debug.Log($"Length of {str}: {characterCount}");
 
            GetComponent<AudioSource>().Play();
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
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
