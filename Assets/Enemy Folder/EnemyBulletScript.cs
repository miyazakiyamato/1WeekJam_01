using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    //���ł���܂ł̎���
    private float lifeTime;
    //���ł���܂ł̎c�莞��
    private float leftLifeTime;
    //�ړ���
    [SerializeField]
    private float speed;
    private Vector3 velocity;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet" ||
            collision.gameObject.tag == "EnemyShield" || collision.gameObject.tag == "Goal")
        {
            return;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet" ||
           collision.gameObject.tag == "EnemyShield" || collision.gameObject.tag == "Goal")
        {
            return;
        }
        Destroy(gameObject);
    }
    void Start()
    {
        //���ł���܂ł̎��Ԃ�0.3�b�Ƃ���
        lifeTime = 2.0f;
        //�c�莞�Ԃ�������
        leftLifeTime = lifeTime;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //�c�莞�Ԃ��J�E���g�_�E��
        leftLifeTime -= Time.deltaTime;
        //���g�̍��W���ړ�
        transform.position += velocity * Time.deltaTime;
        //�c�莞����0�ȉ��ɂȂ����玩�g�̃Q�[���I�u�W�F�N�g���폜
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
