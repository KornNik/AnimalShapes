using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "DataInsideImage", menuName = "Data/Shapes/DataInsideImage")]
    sealed class DataInsideImage : ScriptableObject
    {
        [SerializeField] private Sprite _imageSprite;
        [SerializeField] private Color _imageColor = Color.white;
        [SerializeField] private Vector2 _imageSize;

        public Sprite ImageSprite => _imageSprite;
        public Color ImageColor => _imageColor;
        public Vector2 ImageSize => _imageSize;
    }
}
