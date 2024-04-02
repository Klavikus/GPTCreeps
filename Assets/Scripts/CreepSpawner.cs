using System.Collections;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    public GameObject creepPrefab; // Префаб крипа, который будем спавнить
    public float spawnDelay = 20f; // Задержка перед спавном
    public Transform spawnPoint; // Точка, где крипы будут появляться

    private void Start()
    {
        StartCoroutine(SpawnCreepRoutine());
    }

    private IEnumerator SpawnCreepRoutine()
    {
        while (true) // Бесконечный цикл для постоянного спавна
        {
            yield return new WaitForSeconds(spawnDelay);

            SpawnCreep();
        }
    }

    private void SpawnCreep()
    {
        Instantiate(creepPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}