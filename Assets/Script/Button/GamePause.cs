using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GamePause : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject PausePanel;             // �|�[�Y��ʂ̎w��
    [SerializeField] GameObject TitleInductionPanel;    // �^�C�g���U����ʂ̎w��
    [SerializeField] GameObject ConfigPanel;            // �R���t�B�O��ʂ̎w��

    public static bool isPaused = false;   // �|�[�Y�\�����m


    private void Start()
    {
    }

    private void Update()
    {
        //=== �|�[�Y�\�� ===
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePaused();                     // ���j���[��ʕ`��؂�ւ��֐�
        }
    }

    //--- ���j���[��ʕ`��؂�ւ��֐� ---
    public void TogglePaused()
    {
        isPaused = !isPaused; // �|�[�Y��Ԃ𔽓]������

        if (isPaused)
        {
            Time.timeScale = 0; // �Q�[���̎��Ԃ��~����
            ShowPausePanel(); // �|�[�Y��\��
        }
        else
        {
            Time.timeScale = 1; // �Q�[���̎��Ԃ�ʏ�ɖ߂�
            HidePausePanel(); // �|�[�Y���\��
        }
    }

    public void ShowPausePanel()
    {// �p�l�����J��
        PausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {// �p�l�������
        TitleInductionPanel.SetActive(false);
        ConfigPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

}
