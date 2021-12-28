using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyShipPrefab;
    [SerializeField]
    private GameObject[] PowerUps;
    private GameManager ManageGame;

    // Use this for initialization
    void Start ()
    {
        ManageGame = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(EnemySpwanRoutine());
        StartCoroutine(PowerUpsSpwanRoutine());
	}

    public void StartSpwanRoutiness()
    {
        StartCoroutine(EnemySpwanRoutine());
        StartCoroutine(PowerUpsSpwanRoutine());
    }

    IEnumerator EnemySpwanRoutine()
    {
        while(ManageGame.IsGameOver == false)
        {
            Instantiate(EnemyShipPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpsSpwanRoutine()
    {
        while (ManageGame.IsGameOver == false)
        {
            int RandomPowerUp = Random.Range(0, 3);
            Instantiate(PowerUps[RandomPowerUp], new Vector3(Random.Range(-7.5f, 7.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
}
