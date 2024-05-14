using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //== SerializeField ===
    [SerializeField] private float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] Transform Camera;



    //=== �X�V���� ===
    void Update()
    {

        //=== �ړ����� ===
        if (PlayerStateManager.ePlayerState == PlayerStateManager.PLAYERSTATE.DAMAGED)
        {// �_���[�W���󂯂���ړ��ł��Ȃ�
            return;
        }

        Vector3 inputVector = new Vector3(0, 0, 0);     // �ړ����������m

        if (Input.GetKey(KeyCode.A))
        {// �������Ɉړ�
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {// �E�����Ɉړ�
            inputVector.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {// ������Ɉړ�
            inputVector.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {// �������Ɉړ�
            inputVector.y = -1;
        }

        inputVector = inputVector.normalized;   // ���K��
        Player.transform.position += inputVector * Speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (Camera.position.x != Player.transform.position.x ||
            Camera.position.y != Player.transform.position.y)
        {
            Camera.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
        }

    }

}
