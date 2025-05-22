using System.Collections.Generic;
using System.Linq;
using Data;

namespace Behaviours
{
    sealed class RandomImageSelector : RandomSelector<DataInsideImage>
    {
        public RandomImageSelector(ShapesBundle shapesBundle) : base(shapesBundle)
        {
            _randomValues = new List<DataInsideImage>(_shapesBundle.InsideImages.Count);
            CheckToRefill();
        }

        protected override void CheckToRefill()
        {
            if (IsNeededToRefill())
            {
                _randomValues = _shapesBundle.InsideImages.Values.ToList();
            }
        }
        protected override bool IsNeededToRefill()
        {
            var difference = _shapesBundle.InsideImages.Count - _randomValues.Count;
            return difference > 2 ? true : false;
        }
    }
}
