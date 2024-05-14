using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject Panel;

    public void ShowPanel()
    {// パネルを開く
        Panel.SetActive(true);
    }

    public void HidePanel()
    {// パネルを閉じる
        Panel.SetActive(false);
    }
}
