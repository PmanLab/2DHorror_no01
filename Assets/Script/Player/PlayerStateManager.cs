using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //移動スピードと点滅の間隔
    [SerializeField] float speed, flashInterval;
    //点滅させるときのループカウント
    [SerializeField] int loopCount;
    //点滅させるためのSpriteRenderer
    SpriteRenderer sp;
    //コライダーをオンオフするためのCollider2D
    //BoxCollider2D bc2d;
    Collider2D physicsCollider;

    //プレイヤーの状態用列挙型（ノーマル、ダメージ、無敵の3種類）
    public enum PLAYERSTATE
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }
    //STATE型の変数
    public static PLAYERSTATE ePlayerState;

    private void Start()
    {
        //SpriteRenderer格納
        sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D格納
        physicsCollider = GetComponent<Collider2D>();
    }

    void Update()
    {

    }

    //当たったときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //通常状態じゃなければ
        if (ePlayerState != PLAYERSTATE.NOMAL)
        {
            return;
        }
        //コルーチンを開始
        ePlayerState = PLAYERSTATE.DAMAGED;      //ダメージ受けている
        StartCoroutine(_hit());
    }

    //点滅させる処理
    IEnumerator _hit()
    {
        physicsCollider.enabled = false;
        sp.color = Color.black;
        for (int i = 0; i < loopCount; i++)
        {

            yield return new WaitForSeconds(flashInterval);
            sp.enabled = false;
            yield return new WaitForSeconds(flashInterval);
            sp.enabled = true;
            if (i > 20)
            {
                ePlayerState = PLAYERSTATE.MUTEKI;
                sp.color = Color.green;
            }
        }
        ePlayerState = PLAYERSTATE.NOMAL;
        physicsCollider.enabled = true;
        sp.color = Color.white;

    }
}