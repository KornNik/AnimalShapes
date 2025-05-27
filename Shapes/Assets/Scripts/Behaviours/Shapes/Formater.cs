using UnityEngine;
using System.Collections.Generic;
using Helpers.Extensions;

namespace Behaviours
{
    sealed class Formater
    {
        private List<Vector2> _groupPosition;
        private Vector2 _startingPointPosition;

        public void MakeFormation(List<Shape> shapes ,Transform startingPoint)
        {
            bool gotRelativePosition = false;
            var totalObjectsCount = shapes.Count;
            int positionIndex = default;
            _startingPointPosition = startingPoint.position;

            for (int i = 0; i < totalObjectsCount; i++)
            {
                if (!gotRelativePosition)
                {
                    _groupPosition = SpawnExtender.MakeFormation(shapes[i].Collider, totalObjectsCount);
                    gotRelativePosition = true;
                }
                shapes[i].transform.position = _groupPosition[positionIndex] + _startingPointPosition;
                    positionIndex++;
                shapes[i].ActiveObject();
            }
        }
    }
}
