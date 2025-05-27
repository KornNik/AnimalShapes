using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Behaviours
{
    sealed class RandomShapeSelector : RandomSelector<ShapeType>
    {
        public RandomShapeSelector(ShapesBundle shapesBundle) : base(shapesBundle)
        {
            _randomValues = new List<ShapeType>(_shapesBundle.Shapes.Count);
            CheckToRefill();
        }

        protected override void CheckToRefill()
        {
            if (IsNeededToRefill())
            {
                _randomValues = Enum.GetValues(typeof(ShapeType)).Cast<ShapeType>().ToList();
            }
        }
        protected override bool IsNeededToRefill()
        {
            var difference =  _shapesBundle.Shapes.Count - _randomValues.Count;
            return difference > 2 ? true : false;
        }
    }
}
