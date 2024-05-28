using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
	//���ł���܂ł̎���
	private float lifeTime;
	//���ł���܂ł̎c�莞��
	private float leftLifeTime;
    //�ړ���
    [SerializeField]
    private float speed;
    private Vector3 velocity;
	//����Scale
	/// <summary>
	//private Vector3 defaultScale;
	/// </summary>
	/// <param name="collision"></param>
	// Start is called before the first frame update
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision != null)
		{
			if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBullet")
			{
				return;
            }
            Destroy(gameObject);
        }
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBullet")
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
		////���݂�Scale���L�^
		//defaultScale = transform.localScale;
		//�����_�����Ō��܂�ړ��ʂ̍ő�l
		//float maxVelocity = 1;
		//�e�����փ����_���Ŕ�΂�
		//velocity = new Vector3(
		//    Random.Range(-maxVelocity, maxVelocity),
		//    Random.Range(-maxVelocity, maxVelocity),
		//    0);
		velocity = Vector3.Normalize(Input.mousePosition - new Vector3(Screen.width / 2,Screen.height / 2,0) - transform.position) * speed;
		
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
