using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [Header("フェードするパネル")] [SerializeField] GameObject activePanel;
    [Header("パネルのイメージ")][SerializeField] Image panel;
    [Header("パネルのテキスト")][SerializeField] Text text;
    [Header("ボタンのテキスト")] [SerializeField] Text buttonText;
    [Header("フェード時間value")][SerializeField] float duration = 1000.0f;

    Color panelColor;
    Color textColor;
    Color buttonTextColor;

    const float FadeInAlpha = 1.0f;
    const float FadeOutAlpha = 0.0f;

    void Start()
    {
        panelColor = panel.color;               // 現在のColorを取得
        textColor = text.color;                 // 現在のColorを取得
        buttonTextColor = buttonText.color;         // 現在のColorを取得

    }

    void Update()
    {
        if(PlayerLightControll.isGameOver == true)
        {
            activePanel.SetActive(true);          // Panelをアクティブにする
            StartCoroutine(FadeIn());             // FadeInのコルーチンを発動
        }
    }

    public IEnumerator PanelFade(float targetAlpha)
    {
        while(!Mathf.Approximately(panelColor.a,targetAlpha))
        {// 変化させたいAlpha値を取得
            float changePerFrame = Time.deltaTime / duration;                               // 現在の値と目標の値が近くなるまでのループ
            panelColor.a = Mathf.MoveTowards(panelColor.a, targetAlpha, changePerFrame);    // 1フレームで変化するAlpha値を計算
            panel.color = panelColor;                                                       // 計算したAlpha値を取得
            yield return null;                                                              // 現在のColorにAlpha値を設定
        }
    }

    public IEnumerator TextFade(float targetAlpha)
    {
        while (!Mathf.Approximately(textColor.a, targetAlpha))
        {// 変化させたいAlpha値を取得
            float changePerFrame = Time.deltaTime / duration;                               // 現在の値と目標の値が近くなるまでのループ
            textColor.a = Mathf.MoveTowards(textColor.a, targetAlpha, changePerFrame);      // 1フレームで変化するAlpha値を計算
            text.color = textColor;                                                         // 計算したAlpha値を取得
            yield return null;                                                              // 現在のColorにAlpha値を設定
        }
    }

    public IEnumerator ButtonTextFade(float targetAlpha)
    {
        while (!Mathf.Approximately(buttonTextColor.a, targetAlpha))
        {// 変化させたいAlpha値を取得
            float changePerFrame = Time.deltaTime / duration;                                           // 現在の値と目標の値が近くなるまでのループ
            buttonTextColor.a = Mathf.MoveTowards(buttonTextColor.a, targetAlpha, changePerFrame);      // 1フレームで変化するAlpha値を計算
            buttonText.color = buttonTextColor;                                                         // 計算したAlpha値を取得
            yield return null;                                                                          // 現在のColorにAlpha値を設定
        }
    }

    IEnumerator FadeIn()
    {
        yield return StartCoroutine(PanelFade(FadeInAlpha));          // FadeInのコルーチンを発動(目標α値)
        yield return StartCoroutine(TextFade(FadeInAlpha));           // FadeInのコルーチンを発動(目標α値)
        yield return StartCoroutine(ButtonTextFade(FadeInAlpha));     // FadeInのコルーチンを発動(目標α値)
    }

    IEnumerator FadeOut()
    {
        yield return StartCoroutine(PanelFade(FadeOutAlpha));         // FadeOutのコルーチンを発動(目標α値)
        yield return StartCoroutine(TextFade(FadeOutAlpha));          // FadeOutのコルーチンを発動(目標α値)
        yield return StartCoroutine(ButtonTextFade(FadeOutAlpha));    // FadeOutのコルーチンを発動(目標α値)
    }

}
