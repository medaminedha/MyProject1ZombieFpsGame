//by Dhaoui Mohamed amine E2 A
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;

    //spawn the enemies in diff location 
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text ="Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        for(var x=0; x < round; x++)
        {
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();        enemiesAlive++;
        }


    }
}
