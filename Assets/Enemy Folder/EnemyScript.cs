using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject shieldPreFab;
    GameObject shield;
    // Start is called before the first frame update
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    void Start()
    {
        shield = 
            Instantiate(
                           shieldPreFab,
                           new Vector3(transform.position.x, transform.position.y, 0),
                           Quaternion.identity
                           );
    }

    // Update is called once per frame
    void Update()
    {
        shield.transform.position = transform.position;
    }
}
