using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 2; // 敵の動くスピード

    int nRand = 0;
    int nCount = 0;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;


        //--- カメラの範囲内なら処理 ---
        if(IsVisible())
        {
            // プレイヤーに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // カウント
            nCount += 1;
            float fMAXCount = 4.0f;

            if (nCount > fMAXCount * 60.0f)
            {
                nRand = Random.Range(0, 4);

                switch (nRand)
                {
                    case 0:
                        transform.DOLocalMove(new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f), fMAXCount);

                        break;
                    case 1:
                        transform.DOLocalMove(new Vector2(this.transform.position.x - 0.5f, this.transform.position.y + 0.5f), fMAXCount);

                        break;
                    case 2:
                        transform.DOLocalMove(new Vector2(this.transform.position.x + 0.5f, this.transform.position.y - 0.5f), fMAXCount);

                        break;
                    case 3:
                        transform.DOLocalMove(new Vector2(this.transform.position.x + 0.5f, this.transform.position.y + 0.5f), fMAXCount);

                        break;
                }

                nCount = 0;
            }


        }
    }

    // オブジェクトがカメラに映っているかどうかを確認するメソッド
    bool IsVisible()
    {
        // オブジェクトの位置をビューポート座標に変換
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        // オブジェクトがカメラの視界内にあるかどうかをチェック
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0;
    }

}
