using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_key_ui : MonoBehaviour
{
    Color UI_Key;

    void Start()
    {
        // UI�̐F��� �擾
        UI_Key = gameObject.GetComponent<Image>().color;

        // �ݒ肷��F�̒l �ݒ�
        UI_Key.a = 0.2f;

        // �ݒ肵���F���Đݒ�
        gameObject.GetComponent<Image>().color = UI_Key;
    }

    void Update()
    {
        if (PlayerStateManager.isGetKey == true)
        {
            // �ݒ肷��F�̒l �ݒ�
            UI_Key.a = 1.0f;

            // �ݒ肵���F���Đݒ�
            gameObject.GetComponent<Image>().color = UI_Key;
        }
    }
}
