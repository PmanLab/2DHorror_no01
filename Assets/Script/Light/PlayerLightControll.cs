using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      // DOTween �p
using UnityEngine.Rendering.Universal;  //Light2D�p

public class PlayerLightControll : MonoBehaviour
{
    [Header("intensity�̏����l")] [SerializeField] float intensityValue = 2.5f;
    [Header("OuterRadadius�̏����l")] [SerializeField] float outerradiusVlue = 5.0f;
    [Header("intensity�̌�������")] [SerializeField] float intensityAnimTimeSpeed = 10.0f;
    [Header("OuterRadius�̌�������")] [SerializeField] float OuterRadiusAnimTimeSpeed = 10.0f;
    [Header("�������郉�C�g��")] [SerializeField] float decreaseIntensity = 0.25f;

    public static Light2D light2d;                    // ���C�g���i�[�p
    Tween intensityTween;               // ������ween
    Tween pointLightOuterRadius;        // Radius��Outer

    public static bool isGameOver;      // �Q�[���I�[�o�[���m�p (���C�g�̌������邩�ǂ���)
    bool isDamage = false;

    void Start()
    {
        // ������
        light2d = GetComponent<Light2D>();  // ���C�g�����擾
        light2d.intensity = intensityValue;
        light2d.pointLightOuterRadius = outerradiusVlue;
    }

    void Update()
    {
        //--- �U�����󂯂��狭���I�ɏ��� ---
        if (PlayerStateManager.ePlayerState == PlayerStateManager.PLAYERSTATE.DAMAGED)
        {
            if (!isDamage)
            {
                ForceIntensityDecrease();
                isDamage = true; // �t���O��ݒ肵�āA������������x�����s���悤�ɂ���
            }
        }
        else
        {
            // �v���C���[�̏�Ԃ��_���[�W���󂯂Ă��Ȃ��ꍇ�A�t���O�����Z�b�g
            isDamage = false;
        }

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

    void ForceIntensityDecrease()
    {
        // ���݂�Tween�������I��
        intensityTween?.Kill();
        pointLightOuterRadius?.Kill();

        // ���C�g�̈�x��������������
        light2d.intensity -= decreaseIntensity;


        // �ēxTween��ݒ肵�ĊJ�n
        IntensityChange();
    }
}
