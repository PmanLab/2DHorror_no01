using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    //--- SerializeField ---
    [SerializeField] float speed, flashInterval;    //�ړ��X�s�[�h�Ɠ_�ł̊Ԋu
    [SerializeField] int loopCount;                 //�_�ł�����Ƃ��̃��[�v�J�E���g
    [SerializeField] GameObject GetKeyPanel;        // ������肵���Ƃ���Panel

    //--- �ϐ� ---
    SpriteRenderer sp;                              //�_�ł����邽�߂�SpriteRenderer
    Collider2D physicsCollider;                     //�R���C�_�[���I���I�t���邽�߂�Collider2D
    public static bool isGetKey = false;            // �E�o�p�̌� �擾���i�[�p

    //--- �� ---
    //�v���C���[�̏�ԗp�񋓌^�i�m�[�}���A�_���[�W�A���G��3��ށj
    public enum PLAYERSTATE
    {
        NOMAL,
        DAMAGED,
        MUTEKI
    }

    //--- STATE�^�̕ϐ� ---
    public static PLAYERSTATE ePlayerState;

    //=== ���������� ===
    private void Start()
    {
        // �v���C���[�̏������
        ePlayerState = PLAYERSTATE.NOMAL;

        //SpriteRenderer�i�[
        sp = GetComponent<SpriteRenderer>();
        //BoxCollider2D�i�[
        physicsCollider = GetComponent<Collider2D>();
    }


    //=== �X�V���� ===
    void Update()
    {
        if (GetKeyPanel.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetKeyPanel.SetActive(false);
                isGetKey = true;
                Time.timeScale = 1;     // �Q�[�������Ԏn��
                Debug.Log("���������" + isGetKey);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //--- �S�[���A�C�e������莞 ���� ---
        if (collision.gameObject.name == "Key")
        {
            Debug.Log("������肵��");
            GetKeyPanel.SetActive(true);
            Time.timeScale = 0;     // �Q�[�������Ԓ�~
        }

        //--- �G�ɓ��������Ƃ��̏��� ---
        if (collision.gameObject.tag == "Enemy")
        {
            //�ʏ��Ԃ���Ȃ����
            if (ePlayerState != PLAYERSTATE.NOMAL)
            {
                return;
            }
            //�R���[�`�����J�n
            ePlayerState = PLAYERSTATE.DAMAGED;      //�_���[�W�󂯂Ă���
            StartCoroutine(EnemyHit());
        }
    }

    //�_�ł����鏈��
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