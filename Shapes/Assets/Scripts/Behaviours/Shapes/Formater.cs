using UnityEngine;
using System.Collections.Generic;
using Data;
using Helpers.Extensions;

namespace Behaviours
{
    sealed class Formater
    {
        private Transform _startingPoint;
        private List<Vector2> _groupPosition;
        private ShapesBundle _shapesBundle;
        private Vector2 _startingPointPosition;

        public Formater(ShapesBundle shapesBundle)
        {
            _shapesBundle = shapesBundle;
            _startingPointPosition = _startingPoint.position;
        }

        public void MakeFormation(Shape shape)
        {
            bool gotRelativePosition = false;
            var totalObjectsCount = _shapesBundle.ShapesCount;
            int positionIndex = default;

            for (int j = 0; j < totalObjectsCount; j++)
            {
                //Make formation
                if (!gotRelativePosition)
                {
                    _groupPosition = SpawnExtender.MakeFormation(shape.Collider, totalObjectsCount);
                    gotRelativePosition = true;
                }
                shape.transform.position = _groupPosition[positionIndex] + _startingPointPosition;
                    positionIndex++;
            }
        }
    }
}
