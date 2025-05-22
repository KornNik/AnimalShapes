using System.Collections.Generic;
using System.Linq;
using Data;

namespace Behaviours
{
    sealed class RandomShapeSelector : RandomSelector<DataMainShape>
    {
        public RandomShapeSelector(ShapesBundle shapesBundle) : base(shapesBundle)
        {
            _randomValues = new List<DataMainShape>(_shapesBundle.Shapes.Count);
            CheckToRefill();
        }

        protected override void CheckToRefill()
        {
            if (IsNeededToRefill())
            {
                _randomValues = _shapesBundle.Shapes.Values.ToList();
            }
        }
        protected override bool IsNeededToRefill()
        {
            var difference =  _shapesBundle.Shapes.Count - _randomValues.Count;
            return difference > 2 ? true : false;
        }
    }
}
