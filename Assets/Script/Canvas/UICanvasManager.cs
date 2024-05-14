using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject UICanvas;

    //--- 初期化処理 ---
    void Start()
    {
        UICanvas.SetActive(true);     // UI 全表示描画
    }

    //--- 更新処理 ---
    void Update()
    {

    }

    public void UICanvasUnDraw()
    {
        UICanvas.SetActive(false);
    }

}