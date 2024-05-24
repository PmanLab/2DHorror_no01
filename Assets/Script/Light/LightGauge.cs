using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;  // Light2D�p

public class LightGauge : MonoBehaviour
{

    //=== SerializeField ===
    [SerializeField] public Light2D light2d;   // ���C�g���i�[�p
    public Image lightGaugeUI;                 // �Q�[�WUI��RectTransform

    //=== �ϐ� ===
    private float intensityRatio;      // intensity�̕ω��ʊi�[�p
    private float initialIntensity;    // intensity�̏����l
    private Vector2 gaugeUI;           // �Q�[�WUI�̏����l

    //=== �֐� ===
    void Start()
    {
        //--- �����l��ۑ� ---
        initialIntensity = light2d.intensity;               // intensity
        gaugeUI = lightGaugeUI.rectTransform.sizeDelta;     // UI�����l
    }

    void Update()
    {
        if(light2d.intensity != initialIntensity)
        {// Light2D��intensity���ω�������X�V����
            intensityRatio = light2d.intensity / initialIntensity;
            //lightGaugeUI.rectTransform.sizeDelta = new Vector2(gaugeUI.y * intensityRatio, gaugeUI.x);
            lightGaugeUI.rectTransform.sizeDelta = new Vector2(lightGaugeUI.rectTransform.sizeDelta.x, gaugeUI.y * intensityRatio);
            lightGaugeUI.rectTransform.sizeDelta = new Vector2(lightGaugeUI.rectTransform.sizeDelta.y, gaugeUI.x * intensityRatio);
        }
    }

}
