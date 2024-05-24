using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{    //ボタンが押されたときに呼び出される関数
    public void LoadScene(string str)
    {
        Init();             // 初期化処理
        SceneManager.LoadScene(str);
    }

    public void Init()
    {
        //--- ゲームの時間を通常に戻す ---
        Time.timeScale = 1;

        //--- シーン状態 ---
        GameSceneManager.currentScene = GameSceneManager.gameScene.GAME;

        //--- プレイヤ ---
        PlayerStateManager.isGetKey = false;
        PlayerStateManager.ePlayerState = PlayerStateManager.PLAYERSTATE.NOMAL;

        //--- プレイヤHP ---
        HpManager.fPlayerHp = 100.0f;       // 不使用

        //--- ライト ---
        if (PlayerLightControll.LightOn)
        {
            PlayerLightControll.light2d.intensity = 2.5f;
            PlayerLightControll.light2d.pointLightOuterRadius = 10.0f;
            PlayerLightControll.isGameOver = false;
        }

        //--- ポーズ画面 ---
        GamePause.isPaused = false;
    }
}

