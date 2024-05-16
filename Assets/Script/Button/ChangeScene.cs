using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    

    //�{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void LoadScene(string str)
    {
        Time.timeScale = 1; // �Q�[���̎��Ԃ�ʏ�ɖ߂�
        SceneManager.LoadScene(str);
    }

    public void RetryStage()
    {
        gameOverPanel.SetActive(false);
    }
}
