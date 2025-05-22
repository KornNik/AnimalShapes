using UnityEngine;

namespace Behaviours
{
    sealed class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startSpawnPoint;

        public Transform StartSpawnPoint => _startSpawnPoint;
    }
}
