using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShildScript : MonoBehaviour
{
    public GameObject bulletPreFab;

    private float ct;
    private float leftCt;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (leftCt <= 0 && collision.gameObject.tag == "Player")
        {
            Instantiate(
                           bulletPreFab,
                           new Vector3(transform.position.x, transform.position.y, 0),
                           Quaternion.identity
                           );
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
        //残り時間をカウントダウン
        leftCt -= Time.deltaTime;
    }
}
