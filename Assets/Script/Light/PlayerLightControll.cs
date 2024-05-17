using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      // DOTween �p
using UnityEngine.Rendering.Universal;  //Light2D�p

public class PlayerLightControll : MonoBehaviour
{
    [Header("intensity�̌�������")] [SerializeField] float intensityAnimTimeSpeed = 10.0f;
    [Header("OuterRadius�̌�������")] [SerializeField] float OuterRadiusAnimTimeSpeed = 10.0f;

    Light2D light2d;                    // ���C�g���i�[�p
    Tween intensityTween;               // ������ween
    Tween pointLightOuterRadius;        // Radius��Outer

    public static bool isGameOver;      // �Q�[���I�[�o�[���m�p (���C�g�̌������邩�ǂ���)

    void Start()
    {
        light2d = GetComponent<Light2D>();  // ���C�g�����擾
    }

    void Update()
    {

        // ���j���[��ʕ\������ ���m�֐�
        ToggleIntensityTween();

        if (light2d.intensity <= 0.0f)
        {// ���C�g�̌����c���Ă��Ȃ��ꍇ��true
            isGameOver = true;
        }
        else
        {// ���C�g�̌����c���Ă���ꍇ��false
            isGameOver = false;
        }

    }

    void ToggleIntensityTween()
    {
        //--- Tween�̏������s���Ă���ꍇ ---
        if (intensityTween != null && pointLightOuterRadius != null)
        {//--- Tween���X�V����Ă���ꍇ ---
            if (intensityTween.IsPlaying() && pointLightOuterRadius.IsPlaying())
            {
                //--- Tween���Đ����Ȃ�ꎞ��~ ---
                intensityTween.Pause();
                pointLightOuterRadius.Pause();
            }
            else
            {
                //--- Tween���ꎞ��~���Ȃ�Đ� ---
                intensityTween.Play();
                pointLightOuterRadius.Play();
            }
        }
        else
        {
            // intensityTween ���܂��쐬����Ă��Ȃ��ꍇ�́AIntensityChange() ���Ăяo���č쐬���܂�
            IntensityChange();
        }
    }

    public void IntensityChange()
    {// ���C�g�̋�����ύX����֐�
        //--- intensity ---
        intensityTween = DOTween.To(
            () => light2d.intensity,            // �Ώە�
            num => light2d.intensity = num,     // �l�̍X�V
            0.0f,                               // �ŏI�l
            intensityAnimTimeSpeed              // �A�j���[�V��������
            );
        //--- Radius ---
        pointLightOuterRadius = DOTween.To(
            () => light2d.pointLightOuterRadius,
            num => light2d.pointLightOuterRadius = num,
            1.0f,
            OuterRadiusAnimTimeSpeed
            );

    }

}
