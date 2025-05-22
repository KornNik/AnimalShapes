using Behaviours;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DataMainShape", menuName = "Data/Shapes/DataMainShape")]
    sealed class DataMainShape : ScriptableObject
    {
        [SerializeField] private Shape _shapePrefab;
        [SerializeField] private Color _outlineColor = Color.white;
        [Range(0.01f, 0.1f)]
        [SerializeField] private float _outlineWidth;

        public Color OutlineColor => _outlineColor;
        public float OutlineWidth => _outlineWidth;
        public Shape ShapePrefab => _shapePrefab;
    }
}
