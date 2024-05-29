using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private bool isBreak = false;
    List<GameObject> enemyList;
    public void SetEnemy(List<GameObject> enemyList)
    {
        this.enemyList = enemyList;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    enemyList[i].GetComponent<EnemyScript>().GetShield().GetComponent<EnemyShildScript>().SetBlockPos(transform.position);
                    enemyList[i].GetComponent<EnemyScript>().GetShield().GetComponent<EnemyShildScript>().SetIsBlockMove(true);
                }
                isBreak = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBreak)
        {
            Destroy(gameObject);
        }
    }
}
