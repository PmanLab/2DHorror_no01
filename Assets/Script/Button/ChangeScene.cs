using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    //ボタンが押されたときに呼び出される関数
    public void LoadScene(string str)
    {
        Time.timeScale = 1; // ゲームの時間を通常に戻す
        SceneManager.LoadScene(str);
    }
}
