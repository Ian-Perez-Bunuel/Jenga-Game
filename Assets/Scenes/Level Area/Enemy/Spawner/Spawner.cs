using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnTime = 1f;

    private void Start()
    {
        StartCoroutine(Spawn(enemyPrefab));
    }
    IEnumerator Spawn(GameObject enemyPrefab)
    {
        // makes it wait for 3 seconds
        yield return new WaitForSecondsRealtime(spawnTime);

        // creating Enemy (giving it all the information it will need)
        GameObject bullet = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        // makes it wait for 3 seconds
        yield return new WaitForSeconds(3f * Time.deltaTime);

        StartCoroutine(Spawn(enemyPrefab));

    }


}