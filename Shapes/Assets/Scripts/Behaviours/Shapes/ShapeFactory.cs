using UnityEngine;
using System.Collections.Generic;
using Data;
using Helpers;

namespace Behaviours
{
    sealed class ShapeFactory
    {
        private FactoryBuilder _factoryBuilder;
        private ShapesBundle _shapesBundle;
        private RandomShapeSelector _shapeSelector;
        private RandomColorSelector _colorSelector;
        private RandomImageSelector _imageSelector;
        

        public ShapeFactory(Transform spawnPoint)
        {
            _shapesBundle = Services.Instance.DatasBundle.ServicesObject.GetData<ShapesBundle>();

            _factoryBuilder = new FactoryBuilder(_shapesBundle, spawnPoint);
            _shapeSelector = new RandomShapeSelector(_shapesBundle);
            _colorSelector = new RandomColorSelector(_shapesBundle);
            _imageSelector = new RandomImageSelector(_shapesBundle);
        }

        public List<Shape> Create()
        {
            _factoryBuilder.Clear();
            var shapeList = new List<Shape>(_shapesBundle.ShapesCount);
            var cyclePasses = _shapesBundle.ShapesCount /
                _shapesBundle.MinimalShapeGroup;

            for (int i = 0; i < cyclePasses; i++)
            {
                var shapeType = _shapeSelector.GetValue();
                var color = _colorSelector.GetValue();
                var image = _imageSelector.GetValue();
                for (int j = 0; j < _shapesBundle.MinimalShapeGroup; j++)
                {
                    var shape = _factoryBuilder.Create(shapeType, color, image);
                    shape.ActiveObject();
                    shapeList.Add(shape);
                }
            }
            return shapeList;
        }

        public void Destroy()
        {
            _factoryBuilder.Destroy();
        }
    }
}
