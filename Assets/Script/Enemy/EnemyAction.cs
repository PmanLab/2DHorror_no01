using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;

    private float fDis;             // ����
    private Vector2 fPlayerPos;     //�v���C���[���W
    private Vector2 fEnemyPos;      // �G���W

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�ƓG�̍��W���i�[
        fPlayerPos = Player.transform.position;
        fEnemyPos = Enemy.transform.position;

        //--- �v���C���[�ƓG�̋��������߂� ---
        fDis = Vector2.Distance(fPlayerPos, fEnemyPos);
    }
}
