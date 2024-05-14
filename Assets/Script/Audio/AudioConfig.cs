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
    //[SerializeField] float pauseVolumeReduction;  // ポーズ中のマスターボリュームの減少量

    public const string MasterVolumeKey = "MasterVolume";
    public const string BGMVolumeKey = "BGMVolume";
    public const string SEVolumeKey = "SEVolume";
    //private float originalMasterVolume;             // ポーズ中に一時的に保存する音量
          
    private void Start()
    {
        // スライダーの初期値を設定
        masterAudioSlider.value = PlayerPrefs.GetFloat(MasterVolumeKey, 1.0f);
        bgmSlider.value = PlayerPrefs.GetFloat(BGMVolumeKey, 1.0f);
        seSlider.value = PlayerPrefs.GetFloat(SEVolumeKey, 1.0f);

        // スライダー変更時のリスナーを設定
        masterAudioSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSEVolumeChanged);

        // スライダーの値に基づいて音量を設定
        OnMasterVolumeChanged(masterAudioSlider.value);
        OnBGMVolumeChanged(bgmSlider.value);
        OnSEVolumeChanged(seSlider.value);
    }

    private void OnMasterVolumeChanged(float value)
    {
        //=== 主音量 ===
        value = Mathf.Clamp01(value);
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        // オーディオミキサーの "Master" パラメータを更新
        audioMixer.SetFloat("Master", decibel);

        PlayerPrefs.SetFloat(MasterVolumeKey, value);   // 情報保存
    }

    private void OnBGMVolumeChanged(float value)
    {
        //=== BGM ===
        value = Mathf.Clamp01(value);
        // 変化するのは-80～0の間
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        audioMixer.SetFloat("BGM", decibel);

        PlayerPrefs.SetFloat(BGMVolumeKey, value);  // 情報保存
    }
        
    private void OnSEVolumeChanged(float value)
    {
        value = Mathf.Clamp01(value);
        // 変化するのは-80～0の間
        float decibel = 20.0f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80.0f, 0.0f);
        audioMixer.SetFloat("SE", decibel);

        PlayerPrefs.SetFloat(SEVolumeKey, value);   // 情報保存
    }

    //--- BGM再生 処理 ---
    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    //--- BGM停止 処理 ---
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    //--- BGM一時停止 処理 ---
    public void PauseBGM()
    {
        bgmAudioSource.Pause();
    }

    //--- BGM再生処理 ---
    public void UnPauseBGM()
    {
        bgmAudioSource.UnPause();
    }

    //--- SE再生 処理 ---
    public void SePlay()
    {
        seAudioSource.Play();
    }

    //--- SE停止 処理 ---
    public void SeStop()
    {
        seAudioSource.Stop();
    }

    //--- SE一時停止 処理 ---
    public void SePause()
    {
        seAudioSource.Pause();
    }

    //--- SE一時停止解除 処理 ---
    public void SeUnPause()
    {
        seAudioSource.UnPause();
    }

    //--- 更新処理 ---
    void Update()
    {
        /*if(GamePause.isPaused)
        {// ポーズメニュー中の場合
            // ポーズ中はMastervolumeを少しさげる
            if(GamePause.isPaused)
            {
                originalMasterVolume = masterAudioSlider.value;
            }

            // ポーズ中はマスターボリュームを下げる
            OnMasterVolumeChanged(Mathf.Clamp01(originalMasterVolume - pauseVolumeReduction));
        }
        else
        {// ポーズメニュー中じゃない場合(通常)
            // Mastervolumeをさげるまえの値に戻す
            if (!GamePause.isPaused)
            {
                 OnMasterVolumeChanged(originalMasterVolume);
            }
        }*/

    }
}
