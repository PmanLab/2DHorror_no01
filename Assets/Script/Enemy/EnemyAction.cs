using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;

    private float fDis;             // 距離
    private Vector2 fPlayerPos;     //プレイヤー座標
    private Vector2 fEnemyPos;      // 敵座標

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーと敵の座標を格納
        fPlayerPos = Player.transform.position;
        fEnemyPos = Enemy.transform.position;

        //--- プレイヤーと敵の距離を求める ---
        fDis = Vector2.Distance(fPlayerPos, fEnemyPos);
    }
}
