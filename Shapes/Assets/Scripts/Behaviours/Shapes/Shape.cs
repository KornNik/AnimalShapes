using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class Shape : MonoBehaviour, IPoolable
    {
        [Header("Physic")]
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [Header("Visual")]
        [SerializeField] private SpriteRenderer _modelSpriteRenderer;
        [SerializeField] private SpriteRenderer _outlineSpriteRenderer;
        [SerializeField] private SpriteRenderer _insideImageSpriteRenderer;

        private Transform _poolTransform;

        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }
        public Collider2D Collider => _collider;

        public void ReturnToPool()
        {
            _rigidbody.velocity = Vector3.zero;
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            PoolableObject.SetActive(false);

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

        public void SetColor(Color color)
        {
            _modelSpriteRenderer.color = color;
        }
        public void SetInsideImage(Sprite sprite)
        {
            _insideImageSpriteRenderer.sprite = sprite;
        }
    }
}
