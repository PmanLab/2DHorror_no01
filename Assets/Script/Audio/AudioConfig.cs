using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfig : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] Slider masterAudioSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;
    //[SerializeField] float pauseVolumeReduction;  // �|�[�Y���̃}�X�^�[�{�����[���̌�����

    public const string MasterVolumeKey = "MasterVolume";
    public const string BGMVolumeKey = "BGMVolume";
    public const string SEVolumeKey = "SEVolume";
    //private float originalMasterVolume;             // �|�[�Y���Ɉꎞ�I�ɕۑ����鉹��
          
    private void Start()
    {
        // �X���C�_�[�̏����l��ݒ�
        masterAudioSlider.value = PlayerPrefs.GetFloat(MasterVolumeKey, 1.0f);
        bgmSlider.value = PlayerPrefs.GetFloat(BGMVolumeKey, 1.0f);
        seSlider.value = PlayerPrefs.GetFloat(SEVolumeKey, 1.0f);

        // �X���C�_�[�ύX���̃��X�i�[��ݒ�
        masterAudioSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSEVolumeChanged);

        // �X���C�_�[�̒l�Ɋ�Â��ĉ��ʂ�ݒ�
        OnMasterVolumeChanged(masterAudioSlider.value);
        OnBGMVolumeChanged(bgmSlider.value);
        OnSEVolumeChanged(seSlider.value);
    }

    private void OnMasterVolumeChanged(float value)
    {
        //=== �剹�� ===
        value = Mathf.Clamp01(value);
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        // �I�[�f�B�I�~�L�T�[�� "Master" �p�����[�^���X�V
        audioMixer.SetFloat("Master", decibel);

        PlayerPrefs.SetFloat(MasterVolumeKey, value);   // ���ۑ�
    }

    private void OnBGMVolumeChanged(float value)
    {
        //=== BGM ===
        value = Mathf.Clamp01(value);
        // �ω�����̂�-80�`0�̊�
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        audioMixer.SetFloat("BGM", decibel);

        PlayerPrefs.SetFloat(BGMVolumeKey, value);  // ���ۑ�
    }
        
    private void OnSEVolumeChanged(float value)
    {
        value = Mathf.Clamp01(value);
        // �ω�����̂�-80�`0�̊�
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        audioMixer.SetFloat("SE", decibel);

        PlayerPrefs.SetFloat(SEVolumeKey, value);   // ���ۑ�
    }

    //--- BGM�Đ� ���� ---
    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    //--- BGM��~ ���� ---
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    //--- BGM�ꎞ��~ ���� ---
    public void PauseBGM()
    {
        bgmAudioSource.Pause();
    }

    //--- BGM�Đ����� ---
    public void UnPauseBGM()
    {
        bgmAudioSource.UnPause();
    }

    //--- SE�Đ� ���� ---
    public void SePlay()
    {
        seAudioSource.Play();
    }

    //--- SE��~ ���� ---
    public void SeStop()
    {
        seAudioSource.Stop();
    }

    //--- SE�ꎞ��~ ���� ---
    public void SePause()
    {
        seAudioSource.Pause();
    }

    //--- SE�ꎞ��~���� ���� ---
    public void SeUnPause()
    {
        seAudioSource.UnPause();
    }

    //--- �X�V���� ---
    void Update()
    {
        /*if(GamePause.isPaused)
        {// �|�[�Y���j���[���̏ꍇ
            // �|�[�Y����Mastervolume������������
            if(GamePause.isPaused)
            {
                originalMasterVolume = masterAudioSlider.value;
            }

            // �|�[�Y���̓}�X�^�[�{�����[����������
            OnMasterVolumeChanged(Mathf.Clamp01(originalMasterVolume - pauseVolumeReduction));
        }
        else
        {// �|�[�Y���j���[������Ȃ��ꍇ(�ʏ�)
            // Mastervolume��������܂��̒l�ɖ߂�
            if (!GamePause.isPaused)
            {
                 OnMasterVolumeChanged(originalMasterVolume);
            }
        }*/

    }
}
