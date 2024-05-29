using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
	Rigidbody rb;
	//消滅するまでの時間
	private float lifeTime;
	//消滅するまでの残り時間
	private float leftLifeTime;
    //移動量
    [SerializeField]
    private float speed;
    private Vector3 velocity;
	//初期Scale
	/// <summary>
	//private Vector3 defaultScale;
	/// </summary>
	/// <param name="collision"></param>
	public void SetVelocity(Vector3 velocity)
	{
		this.velocity = velocity;
	}
	// Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBullet")
        {
            return;
        }
        Destroy(gameObject);
    }
    void Start()
	{
		//消滅するまでの時間を0.3秒とする
		lifeTime = 2.0f;
		//残り時間を初期化
		leftLifeTime = lifeTime;
		////現在のScaleを記録
		//defaultScale = transform.localScale;
		//ランダムｎで決まる移動量の最大値
		//float maxVelocity = 1;
		//各方向へランダムで飛ばす
		//velocity = new Vector3(
		//    Random.Range(-maxVelocity, maxVelocity),
		//    Random.Range(-maxVelocity, maxVelocity),
		//    0);
		//velocity = Vector3.zero;
    }

	// Update is called once per frame
	void Update()
	{
		//残り時間をカウントダウン
		leftLifeTime -= Time.deltaTime;
		//自身の座標を移動
		transform.position += velocity * Time.deltaTime * speed;
		//残り時価が0以下になったら自身のゲームオブジェクトを削除
		if (leftLifeTime <= 0) { Destroy(gameObject); }
	}
}
