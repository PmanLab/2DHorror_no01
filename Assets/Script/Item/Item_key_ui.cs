using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_key_ui : MonoBehaviour
{
    Color UI_Key;

    void Start()
    {
        // UIの色情報 取得
        UI_Key = gameObject.GetComponent<Image>().color;

        // 設定する色の値 設定
        UI_Key.a = 0.2f;

        // 設定した色を再設定
        gameObject.GetComponent<Image>().color = UI_Key;
    }

    void Update()
    {
        if (PlayerStateManager.isGetKey == true)
        {
            // 設定する色の値 設定
            UI_Key.a = 1.0f;

            // 設定した色を再設定
            gameObject.GetComponent<Image>().color = UI_Key;
        }
    }
}
