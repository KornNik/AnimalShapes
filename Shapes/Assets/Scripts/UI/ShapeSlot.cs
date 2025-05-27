using System;
using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class ShapeSlot : MonoBehaviour
    {
        [SerializeField] private Image _shapeImage;
        [SerializeField] private Image _outlineImage;
        [SerializeField] private Image _insideImage;
        [SerializeField] private CanvasGroup _canvasGroup;

        private ShapeInfo _shapeInfo;

        private bool _isEmpty = true;

        public bool IsEmpty() => _isEmpty;
        public ShapeInfo ShapeInfo => _shapeInfo;

        private void OnEnable()
        {
            ClearSlot();
        }

        public void FillSlot(ShapeInfo shapeInfo)
        {
            _shapeInfo = shapeInfo;
            _shapeImage.sprite = _shapeInfo.ModelSprite;
            _outlineImage.sprite = _shapeInfo.ModelSprite;
            _insideImage.sprite = _shapeInfo.InsideImageSprite;
            _shapeImage.color = _shapeInfo.Color;
            _canvasGroup.alpha = 1;
            _isEmpty = false;
        }
        public void ClearSlot()
        {
            _canvasGroup.alpha = 0;
            _shapeInfo = default;
            _isEmpty = true;
        }
    }
}
