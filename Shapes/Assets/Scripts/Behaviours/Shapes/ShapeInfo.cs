using Data;
using UnityEngine;

namespace Behaviours
{
    struct ShapeInfo
    {
        public ShapeType ShapeType;
        public ImageType ImageType;
        public Color Color;
        public Sprite ModelSprite;
        public Sprite InsideImageSprite;

        public ShapeInfo(ShapeType shapeType, ImageType imageType, Color color,
            Sprite modelSpriteRenderer,Sprite insideImageSpriteRenderer)
        {
            ShapeType = shapeType;
            ImageType = imageType;
            Color = color;
            ModelSprite= modelSpriteRenderer;
            InsideImageSprite = insideImageSpriteRenderer;
        }
    }
}