using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{    //�{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void LoadScene(string str)
    {
        Init();             // ����������
        SceneManager.LoadScene(str);
    }

    public void Init()
    {
        //--- �Q�[���̎��Ԃ�ʏ�ɖ߂� ---
        Time.timeScale = 1;

        //--- �V�[����� ---
        GameSceneManager.currentScene = GameSceneManager.gameScene.GAME;

        //--- �v���C�� ---
        PlayerStateManager.isGetKey = false;
        PlayerStateManager.ePlayerState = PlayerStateManager.PLAYERSTATE.NOMAL;

        //--- �v���C��HP ---
        HpManager.fPlayerHp = 100.0f;       // �s�g�p

        //--- ���C�g ---
        PlayerLightControll.isGameOver = false;

        //--- �|�[�Y��� ---
        GamePause.isPaused = false;
    }
}

