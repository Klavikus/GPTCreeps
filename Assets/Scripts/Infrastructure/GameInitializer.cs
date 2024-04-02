using Creeps;
using Data;
using UnityEngine;

namespace Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        public Creep prefab; // Префаб крипа, установите в редакторе
        public CreepStats redTeamStats; // ScriptableObject для красной команды
        public CreepStats blueTeamStats; // ScriptableObject для синей команды

        void Awake()
        {
            // Создаем и инициализируем двух крипов как пример
            InstantiateAndInitializeCreep(prefab, redTeamStats);
            InstantiateAndInitializeCreep(prefab, blueTeamStats);
        }

        private void InstantiateAndInitializeCreep(Creep prefab, CreepStats stats)
        {
            Creep creepInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            creepInstance.Initialize(stats, null); // Передайте настоящие waypoints
            // Остальная логика инициализации
        }
    }
}