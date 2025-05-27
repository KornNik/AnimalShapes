using UnityEngine;
using System.Collections.Generic;
using Data;

namespace Behaviours
{
    abstract class RandomSelector<TRandomValueType>
    {
        protected ShapesBundle _shapesBundle;
        protected List<TRandomValueType> _randomValues;

        protected RandomSelector(ShapesBundle shapesBundle)
        {
            _shapesBundle = shapesBundle;
        }

        public virtual TRandomValueType GetValue()
        {
            var random = SelectRandom();
            return random;
        }
        protected abstract void CheckToRefill();
        protected abstract bool IsNeededToRefill();

        protected virtual TRandomValueType SelectRandom()
        {
            var random = Random.Range(0, _randomValues.Count);
            var randomValue = _randomValues[random];
            _randomValues.RemoveAt(random);
            CheckToRefill();
            return randomValue;
        }
    }
}
