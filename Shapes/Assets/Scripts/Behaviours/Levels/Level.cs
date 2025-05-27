using UnityEngine;

namespace Behaviours
{
    sealed class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startSpawnPoint;
        [SerializeField] private Transform _endShapePoint;

        public Transform EndShapePoint => _endShapePoint;
        public Transform StartSpawnPoint => _startSpawnPoint;
    }
}
