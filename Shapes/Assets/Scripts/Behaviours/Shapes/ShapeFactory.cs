using UnityEngine;
using System.Collections.Generic;
using Data;
using Helpers;

namespace Behaviours
{
    sealed class ShapeFactory
    {
        private FactoryBuilder _builder;
        private ShapesBundle _shapesBundle;
        private RandomShapeSelector _shapeSelector;
        private RandomColorSelector _colorSelector;
        private RandomImageSelector _imageSelector;
        private Formater _formater;
        private Transform _spawnPoint;

        private List<Shape> _shapes;

        public ShapeFactory()
        {
            _spawnPoint = Services.Instance.Level.ServicesObject.StartSpawnPoint;
            _shapesBundle = Services.Instance.DatasBundle.ServicesObject.GetData<ShapesBundle>();

            _builder = new FactoryBuilder(_shapesBundle, _spawnPoint);
            _shapeSelector = new RandomShapeSelector(_shapesBundle);
            _colorSelector = new RandomColorSelector(_shapesBundle);
            _imageSelector = new RandomImageSelector(_shapesBundle);
            _formater = new Formater(_shapesBundle);
        }

        public void Create()
        {
            var cyclePasses = _shapesBundle.ShapesCount /
                _shapesBundle.MinimalShapeGroup;

            for (int j = 0; j < cyclePasses; j++)
            {
                var shape = _shapeSelector.GetValue();
                var color = _colorSelector.GetValue();
                var image = _imageSelector.GetValue();
            }
        }
    }
}
