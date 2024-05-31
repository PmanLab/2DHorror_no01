using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 2; // �G�̓����X�s�[�h

    int nRand = 0;
    int nCount = 0;

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;


        //--- �J�����͈͓̔��Ȃ珈�� ---
        if(IsVisible())
        {
            // �v���C���[�Ɍ����Đi��
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        else
        {
            // �J�E���g
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

    // �I�u�W�F�N�g���J�����ɉf���Ă��邩�ǂ������m�F���郁�\�b�h
    bool IsVisible()
    {
        // �I�u�W�F�N�g�̈ʒu���r���[�|�[�g���W�ɕϊ�
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        // �I�u�W�F�N�g���J�����̎��E���ɂ��邩�ǂ������`�F�b�N
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0;
    }

}
