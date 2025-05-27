using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Behaviours
{
    sealed class RandomImageSelector : RandomSelector<ImageType>
    {
        public RandomImageSelector(ShapesBundle shapesBundle) : base(shapesBundle)
        {
            _randomValues = new List<ImageType>(_shapesBundle.InsideImages.Count);
            CheckToRefill();
        }

        protected override void CheckToRefill()
        {
            if (IsNeededToRefill())
            {
                _randomValues = Enum.GetValues(typeof(ImageType)).Cast<ImageType>().ToList();
            }
        }
        protected override bool IsNeededToRefill()
        {
            var difference = _shapesBundle.InsideImages.Count - _randomValues.Count;
            return difference > 2 ? true : false;
        }
    }
}
