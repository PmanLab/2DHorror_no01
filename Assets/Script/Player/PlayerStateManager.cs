using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    //--- SerializeField ---
    [SerializeField] float speed, flashInterval;    //移動スピードと点滅の間隔
    [SerializeField] int loopCount;                 //点滅させるときのループカウント
    [SerializeField] GameObject GetKeyPanel;        // 鍵を入手したときのPanel

    //--- 変数 ---
    SpriteRenderer sp;                              //点滅させるためのSpriteRenderer
    Collider2D physicsCollider;                     //コライダーをオンオフするためのCollider2D
    public static bool isGetKey = false;            // 脱出用の鍵 取得情報格納用

    //--- 列挙 ---
    //プレイヤーの状態用列挙型（ノーマル、ダメージ、無敵の3種類）
    public enum PLAYERSTATE
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }

    //--- STATE型の変数 ---
    public static PLAYERSTATE ePlayerState;

    //=== 初期化処理 ===
    private void Start()
    {
        // プレイヤーの初期状態
        ePlayerState = PLAYERSTATE.NOMAL;

        //SpriteRenderer格納
        sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D格納
        physicsCollider = GetComponent<Collider2D>();
    }


    //=== 更新処理 ===
    void Update()
    {
        if (GetKeyPanel.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetKeyPanel.SetActive(false);
                isGetKey = true;
                Time.timeScale = 1;     // ゲーム内時間始動
                Debug.Log("鍵を入手情報" + isGetKey);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //--- ゴールアイテムを入手時 処理 ---
        if (collision.gameObject.name == "Key")
        {
            Debug.Log("鍵を入手した");
            GetKeyPanel.SetActive(true);
            Time.timeScale = 0;     // ゲーム内時間停止
        }

        //--- 敵に当たったときの処理 ---
        if (collision.gameObject.tag == "Enemy")
        {
            //通常状態じゃなければ
            if (ePlayerState != PLAYERSTATE.NOMAL)
            {
                return;
            }
            //コルーチンを開始
            ePlayerState = PLAYERSTATE.DAMAGED;      //ダメージ受けている
            StartCoroutine(EnemyHit());
        }
    }

    //点滅させる処理
    IEnumerator EnemyHit()
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