using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShildScript : MonoBehaviour
{
    public GameObject bulletPreFab;

    private float ct;
    private float leftCt;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (leftCt <= 0)
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
        ct = 0.5f;
        leftCt = ct;
    }

    // Update is called once per frame
    void Update()
    {
        //残り時間をカウントダウン
        leftCt -= Time.deltaTime;
    }
}
