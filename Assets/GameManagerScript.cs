using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPreFab;
    public GameObject boxPreFab;
    public GameObject noBreakBoxPreFab;
    public GameObject enemyPreFab;
    public GameObject goalPreFab;
    public GameObject clearText;

    int[,] map;
    GameObject[,] field;
    List<GameObject> goalsField;
    bool IsCleared()
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    GameObject f = field[y,x];
                    if (f == null || f.tag == "Player")
                    {
                        
                        return true;
                    }
                }
            }
        }
        return false;
        //
        //for (int i = 0; i < goals.Count; i++)
        //{
        //    GameObject f = field[goals[i].y, goals[i].x];
        //    if (f == null || f.tag != "Player")
        //    {
        //        return false;
        //    }
        //}
    }
    void Reset()
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Destroy(field[y, x]);
            }
        }
        for (int i = 0; i < goalsField.Count; i++)
        {
            Destroy(goalsField[i]);
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
            { 4,0,0,0,0,0,0,0,0,3,4},
            { 4,1,0,0,0,2,0,0,0,0,4},
            { 4,0,0,0,2,2,2,0,5,0,4},
            { 4,0,0,0,0,2,0,0,0,0,4},
            { 4,0,0,0,0,0,0,0,0,0,4},
            { 4,0,0,0,0,0,0,0,0,0,4},
            { 4,0,0,0,0,0,0,0,0,0,4},
            { 4,4,4,4,4,4,4,4,4,4,4},
            };

        field = new GameObject[map.GetLength(0), map.GetLength(1)];
        goalsField = new List<GameObject>();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                        boxPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 3)
                {
                    goalsField.Add(Instantiate(
                        goalPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0.01f),
                        Quaternion.identity
                        ));
                }
                if (map[y, x] == 4)
                {
                    field[y, x] = Instantiate(
                        noBreakBoxPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        );
                }
                if (map[y, x] == 5)
                {
                    field[y, x] = Instantiate(
                        enemyPreFab,
                        new Vector3(x - map.GetLength(1) / 2, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                        );
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCleared())
        {
           
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
              
               // Reset();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
}
