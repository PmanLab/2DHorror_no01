using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    //�{�^���������ꂽ�Ƃ��ɌĂяo�����֐�
    public void LoadScene(string str)
    {
        Time.timeScale = 1; // �Q�[���̎��Ԃ�ʏ�ɖ߂�
        SceneManager.LoadScene(str);
    }
}
