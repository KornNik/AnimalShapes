using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Behaviours
{
    sealed class RandomColorSelector : RandomSelector<Color>
    {
        public RandomColorSelector(ShapesBundle shapesBundle) : base(shapesBundle)
        {
            _randomValues = new List<Color>(_shapesBundle.Colors.Length);
            CheckToRefill();
        }

        protected override void CheckToRefill()
        {
            if (IsNeededToRefill())
            {
                _randomValues = _shapesBundle.Colors.ToList();
            }
        }
        protected override bool IsNeededToRefill()
        {
            var difference = _shapesBundle.Colors.Length - _randomValues.Count;
            return difference > 2 ? true : false;
        }
    }
}
