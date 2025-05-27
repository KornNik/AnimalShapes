using System.Collections.Generic;

namespace UI
{
    sealed class DefaultRulesChecker : CombinationsChecker
    {
        public DefaultRulesChecker(ShapeSlot[] shapeSlots)
        {
            _shapeSlots = shapeSlots;
        }

        public override bool CheckForCombinations()
        {
            List<ShapeSlot> similarShapes = new List<ShapeSlot>(3);
            for (int i = 0; i < _shapeSlots.Length; i++)
            {
                for (int j = i + 1; j < _shapeSlots.Length; j++)
                {
                    if (!_shapeSlots[i].IsEmpty())
                    {
                        if (IsTwoShapesSimilar(_shapeSlots[i].ShapeInfo, _shapeSlots[j].ShapeInfo))
                        {
                            similarShapes.Add(_shapeSlots[i]);
                            similarShapes.Add(_shapeSlots[j]);
                        }

                        if (similarShapes.Count >= 3)
                        {
                            foreach (var shape in similarShapes)
                            {
                                shape.ClearSlot();
                            }

                            return true;
                        }
                    }
                }

                similarShapes.Clear();
            }

            return false;
        }
    }
}
