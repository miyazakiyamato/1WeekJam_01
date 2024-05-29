using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements.Experimental;

public class EnemyShildScript : MonoBehaviour
{
    public GameObject bulletPreFab;
    private GameObject bullet;
    private GameObject player;
    //�����܂łɂ����鎞��
    private float timeTaken = 2.0f;
    //�o�ߎ���
    private float timeErapsed;

    private float ct;
    private float leftCt;
    private Vector3 enemyPos;
    private Vector3 blockPos;
    bool isBlockMove = false;
    public void BulletDestroy()
    {
        Destroy(bullet);
    }
    public void SetPlayer(GameObject player) {  this.player = player; }
    public void SetEnemyPos(Vector3 pos)
    {
        enemyPos = pos;
    }
    public void SetBlockPos(Vector3 pos)
    {
        blockPos = pos;
    }
    public void SetIsBlockMove(bool isBlockMove)
    {
        this.isBlockMove = isBlockMove;
    }
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (leftCt <= 0 && collision.gameObject.tag == "Player")
        {
            bullet = Instantiate(
                           bulletPreFab,
                           new Vector3(transform.position.x, transform.position.y, 0),
                           Quaternion.identity
                           );
            Vector3 velocity = (player.transform.position - transform.position).normalized;
            bullet.GetComponent<EnemyBulletScript>().GetComponent<EnemyBulletScript>().SetVelocity(velocity);
            leftCt = ct;
        }
    }
    void Start()
    {
        ct = 1.0f;
        leftCt = ct;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlockMove)
        {
            //Vector3 currentPosition

            //�ړI�n�ɓ������Ă����珈�����Ȃ�
            if (blockPos == enemyPos) {
                isBlockMove = false;
                return;
            }
            //���Ԍo�߂����Z
            timeErapsed += Time.deltaTime;
            //�o�ߎ��Ԃ��������Ԃ̉��������Z�o
            float timeRate = timeErapsed / timeTaken;
            //�������Ԃ𒴂���悤�ł���Ύ��s���ԑ����Ɋۂ߂�
            if (timeRate >= 1) {
                isBlockMove = false; 
                timeRate = 1;}
            //�C�[�W���O�p�v�Z�i���j�A�j
            float easing = timeRate;
            //���W���Z�o
            Vector3 currentPosition = Vector3.Lerp(enemyPos, blockPos, easing);
            //�Z�o�������W��Position�ɑ��
            transform.position = currentPosition;
        }
        else
        {
            timeErapsed = 0.0f;
            transform.position = enemyPos;
        }
        //�c�莞�Ԃ��J�E���g�_�E��
        leftCt -= Time.deltaTime;
    }
}
