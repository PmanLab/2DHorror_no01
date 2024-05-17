using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      // DOTween 用
using UnityEngine.Rendering.Universal;  //Light2D用

public class PlayerLightControll : MonoBehaviour
{
    [Header("intensityの初期値")] [SerializeField] float intensityValue = 2.5f;
    [Header("OuterRadadiusの初期値")] [SerializeField] float outerradiusVlue = 5.0f;
    [Header("intensityの減少時間")] [SerializeField] float intensityAnimTimeSpeed = 10.0f;
    [Header("OuterRadiusの減少時間")] [SerializeField] float OuterRadiusAnimTimeSpeed = 10.0f;
    [Header("減少するライト量")] [SerializeField] float decreaseIntensity = 0.25f;

    public static Light2D light2d;                    // ライト情報格納用
    Tween intensityTween;               // 強さのween
    Tween pointLightOuterRadius;        // RadiusのOuter

    public static bool isGameOver;      // ゲームオーバー検知用 (ライトの光があるかどうか)
    bool isDamage = false;

    void Start()
    {
        // 初期化
        light2d = GetComponent<Light2D>();  // ライト情報を取得
        light2d.intensity = intensityValue;
        light2d.pointLightOuterRadius = outerradiusVlue;
    }

    void Update()
    {
        //--- 攻撃を受けたら強制的に処理 ---
        if (PlayerStateManager.ePlayerState == PlayerStateManager.PLAYERSTATE.DAMAGED)
        {
            if (!isDamage)
            {
                ForceIntensityDecrease();
                isDamage = true; // フラグを設定して、減少処理を一度だけ行うようにする
            }
        }
        else
        {
            // プレイヤーの状態がダメージを受けていない場合、フラグをリセット
            isDamage = false;
        }

        // メニュー画面表示入力 検知関数
        ToggleIntensityTween();

        if (light2d.intensity <= 0.0f)
        {// ライトの光が残っていない場合はtrue
            isGameOver = true;
        }
        else
        {// ライトの光が残っている場合はfalse
            isGameOver = false;
        }

    }

    void ToggleIntensityTween()
    {
        //--- Tweenの処理を行っている場合 ---
        if (intensityTween != null && pointLightOuterRadius != null)
        {//--- Tweenが更新されている場合 ---
            if (intensityTween.IsPlaying() && pointLightOuterRadius.IsPlaying())
            {
                //--- Tweenが再生中なら一時停止 ---
                intensityTween.Pause();
                pointLightOuterRadius.Pause();
            }
            else
            {
                //--- Tweenが一時停止中なら再生 ---
                intensityTween.Play();
                pointLightOuterRadius.Play();
            }
        }
        else
        {
            // intensityTween がまだ作成されていない場合は、IntensityChange() を呼び出して作成します
            IntensityChange();
        }
    }

    public void IntensityChange()
    {// ライトの強さを変更する関数
        //--- intensity ---
        intensityTween = DOTween.To(
            () => light2d.intensity,            // 対象物
            num => light2d.intensity = num,     // 値の更新
            0.0f,                               // 最終値
            intensityAnimTimeSpeed              // アニメーション時間
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
        // 現在のTweenを強制終了
        intensityTween?.Kill();
        pointLightOuterRadius?.Kill();

        // ライトの一度だけ強さを減少
        light2d.intensity -= decreaseIntensity;


        // 再度Tweenを設定して開始
        IntensityChange();
    }
}
