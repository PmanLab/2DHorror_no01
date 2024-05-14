using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    //=== SerializeField ===
    [SerializeField] GameObject Panel;

    public void ShowPanel()
    {// �p�l�����J��
        Panel.SetActive(true);
    }

    public void HidePanel()
    {// �p�l�������
        Panel.SetActive(false);
    }
}
