using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public List<Transform> locations;
    public static int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in locations)
        {
            Debug.Log("Position"+t);
            Instantiate(enemies[0], t.position, enemies[0].transform.rotation);
        }
        enemyCount = 9;
        }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 9)
        {
            Instantiate(enemies[Random.Range(0,enemies.Length)], locations[Random.Range(0, locations.Count)].position, enemies[1].transform.rotation);
            enemyCount += 1;
        } else if (enemyCount < 15&&ScoreTracker.score>=1000)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], locations[Random.Range(0, locations.Count)].position, enemies[1].transform.rotation);
            enemyCount += 1;
        }
    }
}
