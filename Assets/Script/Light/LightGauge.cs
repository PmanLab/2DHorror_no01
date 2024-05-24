using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;  // Light2D用

public class LightGauge : MonoBehaviour
{

    //=== SerializeField ===
    [SerializeField] public Light2D light2d;   // ライト情報格納用
    public Image lightGaugeUI;                 // ゲージUIのRectTransform

    //=== 変数 ===
    private float intensityRatio;      // intensityの変化量格納用
    private float initialIntensity;    // intensityの初期値
    private Vector2 gaugeUI;           // ゲージUIの初期値

    //=== 関数 ===
    void Start()
    {
        //--- 初期値を保存 ---
        initialIntensity = light2d.intensity;               // intensity
        gaugeUI = lightGaugeUI.rectTransform.sizeDelta;     // UI初期値
    }

    void Update()
    {
        if(light2d.intensity != initialIntensity)
        {// Light2Dのintensityが変化したら更新する
            intensityRatio = light2d.intensity / initialIntensity;
            //lightGaugeUI.rectTransform.sizeDelta = new Vector2(gaugeUI.y * intensityRatio, gaugeUI.x);
            lightGaugeUI.rectTransform.sizeDelta = new Vector2(lightGaugeUI.rectTransform.sizeDelta.x, gaugeUI.y * intensityRatio);
            lightGaugeUI.rectTransform.sizeDelta = new Vector2(lightGaugeUI.rectTransform.sizeDelta.y, gaugeUI.x * intensityRatio);
        }
    }

}
