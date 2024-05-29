using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public GameObject playerBulletPreFab;
	[SerializeField]
	private float speed;
	private Vector3 velocity;
	GameObject bullet;
	int hp = 5;

    private bool isClear = false;
	private bool isDed = false;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Goal")
		{
			isClear = true;
		}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
		{
			hp--;
		}
    }
    public bool GetIsClear()
	{
		return isClear;
	}
	public bool GetIsDed()
	{
		return isDed;
	}
	// Start is called before the first frame update
	void Start()
	{
        isClear = false;
    }

	// Update is called once per frame
	void Update()
	{
		if(hp < 0)
		{
			isDed = true;
		}

		Vector2 direction = new Vector2(0, 0);
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			direction.x = 1.0f;
		}
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			direction.x = -1.0f;
		}
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			direction.y = 1.0f;
		}
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            direction.y = -1.0f;
        }
		float ruto = math.length(direction);
        if (ruto > 0) {
            velocity = (new Vector3(direction.x, direction.y, 0) / ruto);
            transform.position += velocity * Time.deltaTime * speed;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
            bullet = Instantiate(
                        playerBulletPreFab,
                        new Vector3(transform.position.x,transform.position.y,0) + velocity * Time.deltaTime * speed,
                        Quaternion.identity
                        );
			bullet.GetComponent<PlayerBulletScript>().SetVelocity(velocity);
        }
	}
}
