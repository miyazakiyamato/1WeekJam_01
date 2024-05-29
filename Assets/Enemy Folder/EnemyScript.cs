using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject shieldPreFab;
    GameObject shield;
    private GameObject player;
    int hp = 3;
    // Start is called before the first frame update
    public GameObject GetShield() {  return shield; }
    public void SetPlayer(GameObject player) { this.player = player; }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            hp--;
        }
    }
    public void EnemyDestroy()
    {
        shield.GetComponent<EnemyShildScript>().BulletDestroy();
        Destroy(shield);
        Destroy(gameObject);
    }
    void Start()
    {
        shield = 
            Instantiate(
                           shieldPreFab,
                           new Vector3(transform.position.x, transform.position.y, 0),
                           Quaternion.identity
                           );
        shield.GetComponent<EnemyShildScript>().SetPlayer(player);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp < 0)
        {
            EnemyDestroy();
        }
        shield.GetComponent<EnemyShildScript>().SetEnemyPos(transform.position);
    }
}
