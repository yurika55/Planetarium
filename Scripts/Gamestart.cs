//ゲームスタート画面のボタンのシーンの切り替えコード
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Gamestart : MonoBehaviour
{
    
    public void StartGame()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

}
