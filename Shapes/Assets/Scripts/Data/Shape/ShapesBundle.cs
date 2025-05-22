using Helpers.Extensions;
using UnityEngine;

namespace Data
{
    enum ShapeType
    {
        None,
        Square,
        Circle,
        Triangle
    }
    enum ImageType
    {
        None,
        Fish,
        Pig,
        Bug
    }
    [CreateAssetMenu(fileName = "ShapeBundle", menuName = "Data/Shapes/ShapeBundle")]
    sealed class ShapesBundle : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<ShapeType, DataMainShape> _shapes;
        [SerializeField] private SerializableDictionary<ImageType, DataInsideImage> _insideImages;
        [SerializeField] private Color[] _colors;
        [SerializeField] private int _shapesCount = 30;
        [SerializeField] private int _minimalShapeGroup = 3;

        public int ShapesCount => _shapesCount;
        public int MinimalShapeGroup  => _minimalShapeGroup;
        public Color[] Colors  => _colors;
        public SerializableDictionary<ShapeType, DataMainShape> Shapes => _shapes;
        public SerializableDictionary<ImageType, DataInsideImage> InsideImages  => _insideImages;
    }
}
