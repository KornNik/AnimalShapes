using DG.Tweening;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShapeData", menuName = "Data/Shapes/ShapeData")]
    class ShapeData : ScriptableObject
    {
        [SerializeField] private ShapeType _shapeType;
        [SerializeField] private AudioClip _clickOnShapeSound;
        [SerializeField] private AudioClip _goToBoardSound;
        [SerializeField] private float _flyingDuration = 1f;
        [SerializeField] private Ease _easeType = Ease.InOutQuad;
        
        public ShapeType ShapeType => _shapeType;
        public AudioClip ClickOnShapeSound => _clickOnShapeSound;
        public AudioClip GoToBoardSound => _goToBoardSound;
        public float FlyingDuration => _flyingDuration;
        public Ease EaseType => _easeType;
    }
}