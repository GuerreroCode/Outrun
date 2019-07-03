using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallScript : MonoBehaviour
{
 
    [Header("Set in Inspector")]
    public GameObject enemyPrefab;
    public int numEnemies = 3;
    public float enemySpacingX = 5f;
    public List<GameObject> enemyList;
    public float zSpacing = 25;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject tEnemyGO = Instantiate<GameObject>(enemyPrefab);
            Vector3 pos = Vector3.zero;
            pos.z = transform.position.z - zSpacing;
            pos.x = (transform.position.x - (transform.localScale.x / numEnemies) - 2) + (enemySpacingX * i);
            pos.y = 6;
            tEnemyGO.transform.position = pos;
            enemyList.Add(tEnemyGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
            }
        }
        if (enemyList.Count == 0)
        {
            Destroy(this.gameObject);
        }
            
    }
}
