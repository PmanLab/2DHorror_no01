using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [SerializeField] GameObject activePanel;
    [SerializeField] Image panel;
    [SerializeField] Text text;
    [Header("�t�F�[�h����value")][SerializeField] float duration = 1000.0f;

    Color panelColor;
    Color textColor;

    const float FadeInAlpha = 1.0f;
    const float FadeOutAlpha = 0.0f;


    void Start()
    {
        panelColor = panel.color;               // ���݂�Color���擾
        textColor = text.color;                 // ���݂�Color���擾

    }

    void Update()
    {
        if(PlayerLightControll.isGameOver == true)
        {
            activePanel.SetActive(true);          // Panel���A�N�e�B�u�ɂ���
            StartCoroutine(FadeIn());             // FadeIn�̃R���[�`���𔭓�
        }
    }

    public IEnumerator PanelFade(float targetAlpha)
    {
        while(!Mathf.Approximately(panelColor.a,targetAlpha))
        {// �ω���������Alpha�l���擾
            float changePerFrame = Time.deltaTime / duration;                               // ���݂̒l�ƖڕW�̒l���߂��Ȃ�܂ł̃��[�v
            panelColor.a = Mathf.MoveTowards(panelColor.a, targetAlpha, changePerFrame);    // 1�t���[���ŕω�����Alpha�l���v�Z
            panel.color = panelColor;                                                       // �v�Z����Alpha�l���擾
            yield return null;                                                              // ���݂�Color��Alpha�l��ݒ�
        }
    }

    public IEnumerator TextFade(float targetAlpha)
    {
        while (!Mathf.Approximately(textColor.a, targetAlpha))
        {// �ω���������Alpha�l���擾
            float changePerFrame = Time.deltaTime / duration;                               // ���݂̒l�ƖڕW�̒l���߂��Ȃ�܂ł̃��[�v
            textColor.a = Mathf.MoveTowards(textColor.a, targetAlpha, changePerFrame);      // 1�t���[���ŕω�����Alpha�l���v�Z
            text.color = textColor;                                                         // �v�Z����Alpha�l���擾
            yield return null;                                                              // ���݂�Color��Alpha�l��ݒ�
        }
    }

    IEnumerator FadeIn()
    {
        yield return StartCoroutine(PanelFade(FadeInAlpha));    // FadeIn�̃R���[�`���𔭓�(�ڕW���l)
        yield return StartCoroutine(TextFade(FadeInAlpha));     // FadeIn�̃R���[�`���𔭓�(�ڕW���l)
    }

    IEnumerator FadeOut()
    {
        yield return StartCoroutine(PanelFade(FadeOutAlpha));   // FadeOut�̃R���[�`���𔭓�(�ڕW���l)
        yield return StartCoroutine(TextFade(FadeOutAlpha));    // FadeOut�̃R���[�`���𔭓�(�ڕW���l)
    }

}
