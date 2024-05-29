using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    //消滅するまでの時間
    private float lifeTime;
    //消滅するまでの残り時間
    private float leftLifeTime;
    //移動量
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
        //消滅するまでの時間を0.3秒とする
        lifeTime = 2.0f;
        //残り時間を初期化
        leftLifeTime = lifeTime;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //残り時間をカウントダウン
        leftLifeTime -= Time.deltaTime;
        //自身の座標を移動
        transform.position += velocity * Time.deltaTime;
        //残り時価が0以下になったら自身のゲームオブジェクトを削除
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}
