using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_key : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {// �v���C���[�ɓ��������Ƃ��̏���
        if(collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
