using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //== SerializeField ===
    [SerializeField] private float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] Transform Camera;



    //=== 更新処理 ===
    void Update()
    {

        //=== 移動処理 ===
        if (PlayerStateManager.ePlayerState == PlayerStateManager.PLAYERSTATE.DAMAGED)
        {// ダメージを受けたら移動できない
            return;
        }

        Vector3 inputVector = new Vector3(0, 0, 0);     // 移動方向を検知

        if (Input.GetKey(KeyCode.A))
        {// 左方向に移動
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {// 右方向に移動
            inputVector.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {// 上方向に移動
            inputVector.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {// 下方向に移動
            inputVector.y = -1;
        }

        inputVector = inputVector.normalized;   // 正規化
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
