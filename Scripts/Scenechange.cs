using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    //何秒後にシーンを切り替えるか
    public float delay = 10.0f;
    public Animator dogani;
    public int SceneIndex;
    private bool isChangingScene = false; // シーン切り替えフラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしHideがONになったらdelay後にシーンを切り替える
         if (dogani.GetBool("Hide") && !isChangingScene)
        {
            isChangingScene = true; // フラグを設定
            Debug.Log("a");
            Invoke("change", delay);
        }
    }

    void change()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
