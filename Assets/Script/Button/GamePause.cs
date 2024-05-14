using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GamePause : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject PausePanel;             // ポーズ画面の指定
    [SerializeField] GameObject TitleInductionPanel;    // タイトル誘導画面の指定
    [SerializeField] GameObject ConfigPanel;            // コンフィグ画面の指定

    public static bool isPaused = false;   // ポーズ表示検知


    private void Start()
    {
    }

    private void Update()
    {
        //=== ポーズ表示 ===
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();                     // メニュー画面描画切り替え関数
        }
    }

    //--- メニュー画面描画切り替え関数 ---
    public void TogglePaused()
    {
        isPaused = !isPaused; // ポーズ状態を反転させる

        if (isPaused)
        {
            Time.timeScale = 0; // ゲームの時間を停止する
            ShowPausePanel(); // ポーズを表示
        }
        else
        {
            Time.timeScale = 1; // ゲームの時間を通常に戻す
            HidePausePanel(); // ポーズを非表示
        }
    }

    public void ShowPausePanel()
    {// パネルを開く
        PausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {// パネルを閉じる
        TitleInductionPanel.SetActive(false);
        ConfigPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

}
