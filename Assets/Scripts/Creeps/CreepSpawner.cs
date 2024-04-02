using System.Collections;
using Data;
using UnityEngine;

namespace Creeps
{
    public class CreepSpawner : MonoBehaviour
    {
        // Удалим сериализацию полей, так как будем присваивать их через Initialize()
        private CreepSpawnConfig _spawnConfig;
        private Transform[] _waypoints;

        // Создаём метод Initialize, который будет вызываться из GameInitializer для установки конфигурации
        public void Initialize(CreepSpawnConfig spawnConfig, Transform[] waypoints)
        {
            _spawnConfig = spawnConfig;
            _waypoints = waypoints;

            // Запускаем процесс спавнинга
            StartCoroutine(SpawnCreeps());
        }

        private IEnumerator SpawnCreeps()
        {
            // Если конфигурация не установлена, выходим из корутины
            if (_spawnConfig == null || _waypoints == null) yield break;

            while (true) // Бесконечный цикл для постоянного спавна крипов
            {
                // Создаем крипа на позиции спавнера и с заданным поворотом
                Creep creepInstance =
                    Instantiate(_spawnConfig.creepConfig.Prefab, transform.position, Quaternion.identity);
                // Инициализируем крипа с конфигурацией и waypoints
                creepInstance.Initialize(_spawnConfig.creepConfig.Stats, _waypoints);

                yield return new WaitForSeconds(_spawnConfig.spawnDelay);
            }
        }
    }
}