using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasManager : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject UICanvas;

    //--- ���������� ---
    void Start()
    {
        UICanvas.SetActive(true);     // UI �S�\���`��
    }

    //--- �X�V���� ---
    void Update()
    {

    }

    public void UICanvasUnDraw()
    {
        UICanvas.SetActive(false);
    }

}