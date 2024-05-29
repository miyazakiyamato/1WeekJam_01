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
    //完了までにかかる時間
    private float timeTaken = 2.0f;
    //経過時間
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

            //目的地に到着していたら処理しない
            if (blockPos == enemyPos) {
                isBlockMove = false;
                return;
            }
            //時間経過を加算
            timeErapsed += Time.deltaTime;
            //経過時間が完了時間の何割かを算出
            float timeRate = timeErapsed / timeTaken;
            //完了時間を超えるようであれば実行時間相当に丸める
            if (timeRate >= 1) {
                isBlockMove = false; 
                timeRate = 1;}
            //イージング用計算（リニア）
            float easing = timeRate;
            //座標を算出
            Vector3 currentPosition = Vector3.Lerp(enemyPos, blockPos, easing);
            //算出した座標をPositionに代入
            transform.position = currentPosition;
        }
        else
        {
            timeErapsed = 0.0f;
            transform.position = enemyPos;
        }
        //残り時間をカウントダウン
        leftCt -= Time.deltaTime;
    }
}
