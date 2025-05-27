using Data;
using DG.Tweening;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class Shape : MonoBehaviour, IPoolable, ISelectable, IMovable
    {
        [Header("Physic")]
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [Header("Visual")]
        [SerializeField] private SpriteRenderer _modelSpriteRenderer;
        [SerializeField] private SpriteRenderer _outlineSpriteRenderer;
        [SerializeField] private SpriteRenderer _insideImageSpriteRenderer;
        [Header("Info")]
        [SerializeField] private ShapeData _shapeData;

        private Transform _poolTransform;
        private ShapeInfo _shapeInfo;

        public Collider2D Collider => _collider;
        public ShapeInfo ShapeInfo => _shapeInfo;
        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        private void Awake()
        {
            _shapeInfo = new ShapeInfo();
            _shapeInfo.ShapeType = _shapeData.ShapeType;
            _shapeInfo.ModelSprite = _modelSpriteRenderer.sprite;
        }

        public void SetColor(Color color)
        {
            _shapeInfo.Color = color;
            _modelSpriteRenderer.color = color;
        }
        public void SetInsideImage(DataInsideImage imageData, ImageType imageType)
        {
            _shapeInfo.ImageType = imageType;
            _shapeInfo.InsideImageSprite = imageData.ImageSprite;
            _insideImageSpriteRenderer.sprite = imageData.ImageSprite;
        }


        #region IPoolable

        public void ReturnToPool()
        {
            _rigidbody.velocity = Vector3.zero;
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            gameObject.SetActive(false);

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }
        public void ActiveObject()
        {
            PoolableObject.SetActive(true);
            _rigidbody.simulated = true;
            _collider.enabled = true;
            transform.SetParent(null);
        }

        #endregion
        

        #region ISelectable

        public void Select()
        {
            _rigidbody.simulated = false;
            _collider.enabled = false;
            Move(Services.Instance.Level.ServicesObject.EndShapePoint.position);
            
            MakeSoundEvent.Trigger(new SoundEventInfo(_shapeData.ClickOnShapeSound,transform.position));
        }

        #endregion


        #region IMovable

        public void Move(Vector3 movement)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Join(transform.DOMove(movement, _shapeData.FlyingDuration).SetEase(_shapeData.EaseType));

            sequence.OnComplete(() =>
            {
                MakeSoundEvent.Trigger(new SoundEventInfo(_shapeData.GoToBoardSound,transform.up));
                ReturnToPool();
                ShapeSelectedComplete.Trigger(new ShapeEventInfo(_shapeInfo, this));
            });
        }

        #endregion
    }
}
