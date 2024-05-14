using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //�ړ��X�s�[�h�Ɠ_�ł̊Ԋu
    [SerializeField] float speed, flashInterval;
    //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] int loopCount;
    //�_�ł����邽�߂�SpriteRenderer
    SpriteRenderer sp;
    //�R���C�_�[���I���I�t���邽�߂�Collider2D
    //BoxCollider2D bc2d;
    Collider2D physicsCollider;

    //�v���C���[�̏�ԗp�񋓌^�i�m�[�}���A�_���[�W�A���G��3��ށj
    public enum PLAYERSTATE
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }
    //STATE�^�̕ϐ�
    public static PLAYERSTATE ePlayerState;

    private void Start()
    {
        //SpriteRenderer�i�[
        sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D�i�[
        physicsCollider = GetComponent<Collider2D>();
    }

    void Update()
    {

    }

    //���������Ƃ��̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ʏ��Ԃ���Ȃ����
        if (ePlayerState != PLAYERSTATE.NOMAL)
        {
            return;
        }
        //�R���[�`�����J�n
        ePlayerState = PLAYERSTATE.DAMAGED;      //�_���[�W�󂯂Ă���
        StartCoroutine(_hit());
    }

    //�_�ł����鏈��
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