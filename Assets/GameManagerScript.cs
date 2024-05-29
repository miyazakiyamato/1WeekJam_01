using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPreFab;
    public GameObject boxPreFab;
    public GameObject noBreakBoxPreFab;
    public GameObject enemyPreFab;
    public GameObject goalPreFab;
    public GameObject clearText;
    public FadeSceneLoader fadeSceneLoader;
    // éüÇÃÉVÅ[ÉìÇÃïœêî
    public string nextSceneName;
    public string nextSceneName2;

    int[,] map;
    GameObject player;
    GameObject goal;
    List<GameObject> enemyList;
    List<GameObject> boxList;
    List<GameObject> noBreakBoxList;
    public GameObject GetPlayer () { return player; }
    public List<GameObject> GetEnemyList() {  return enemyList; }
    public void SetEnemyShieldBlockPos(Vector3 pos)
    {
        for (int i = 0; i < GetComponent<GameManagerScript>().GetEnemyList().Count; i++)
        {
            if (enemyList[i].GetComponent<EnemyScript>().GetShield() != null)
            {
                enemyList[i].GetComponent<EnemyScript>().GetShield().GetComponent<EnemyShildScript>().SetBlockPos(pos);
            }
        }
    }
    bool IsCleared()
    {
        if(player != null && player.GetComponent<PlayerScript>().GetIsClear()) { return true; }
        return false;
    }
    void Reset()
    {
        Destroy(player);
        Destroy(goal);
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i] != null)
            {
                enemyList[i].GetComponent<EnemyScript>().EnemyDestroy();
            }
        }
        for (int i = 0; i < boxList.Count; i++)
        {
            Destroy(boxList[i]);
        }
        for (int i = 0; i < noBreakBoxList.Count; i++)
        {
            Destroy(noBreakBoxList[i]);
        }
        Start();
        clearText.SetActive(IsCleared());
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);

        map = new int[,] {
            { 4,4,4,4,4,4,4,4,4,4,4},
            { 4,0,0,0,2,2,0,0,0,3,4},
            { 4,0,0,0,2,2,0,0,0,0,4},
            { 4,0,0,0,2,2,0,0,5,0,4},
            { 4,0,0,0,2,2,0,0,0,0,4},
            { 4,0,0,0,2,2,0,0,0,0,4},
            { 4,1,0,0,2,2,0,0,0,0,4},
            { 4,0,0,0,2,2,2,2,2,2,4},
            { 4,4,4,4,4,4,4,4,4,4,4},
            };

        enemyList = new List<GameObject>();
        boxList = new List<GameObject>();
        noBreakBoxList = new List<GameObject>();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    player = Instantiate(
                        playerPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 2)
                {
                    boxList.Add(Instantiate(
                        boxPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        ));
                    boxList[boxList.Count - 1].GetComponent<BlockScript>().SetEnemy(enemyList);
                }
                if (map[y, x] == 3)
                {
                    goal = Instantiate(
                        goalPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0.01f),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 4)
                {
                    noBreakBoxList.Add(Instantiate(
                        noBreakBoxPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        ));
                }
                if (map[y, x] == 5)
                {
                    enemyList.Add(Instantiate(
                        enemyPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        ));
                    enemyList[enemyList.Count - 1].GetComponent<EnemyScript>().SetPlayer(player);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCleared())
        {
            if (player != null && player.GetComponent<PlayerScript>().GetIsDed())
            {
                SceneManager.LoadScene(nextSceneName2);
            }
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
}
