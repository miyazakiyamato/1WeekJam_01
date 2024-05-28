using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject playerBulletPreFab;
	[SerializeField]
	private float speed;
	private void OnCollisionEnter(Collision collision)
	{
		
    }
	// Start is called before the first frame update
	void Start()
	{
	   
	}

	// Update is called once per frame
	void Update()
	{
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
			transform.position += (new Vector3(direction.x,direction.y, 0) / ruto * Time.deltaTime * speed);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
            Instantiate(
                        playerBulletPreFab,
                        new Vector3(transform.position.x,transform.position.y,0),
                        Quaternion.identity
                        );
        }
	}
}
