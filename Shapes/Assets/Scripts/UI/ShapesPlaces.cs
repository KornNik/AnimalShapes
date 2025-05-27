using Behaviours;
using Helpers;
using UnityEngine;

namespace UI
{
    sealed class ShapesPlaces : MonoBehaviour, IEventListener<ShapeSelectedComplete>,
        IEventListener<ShapesConstructEvent>
    {
        [SerializeField] private Transform _shapeSlotsParent;

        private ShapeSlot[] _shapeSlots;
        private CombinationsChecker _combinationsChecker;

        private void Awake()
        {
            _shapeSlots = _shapeSlotsParent.GetComponentsInChildren<ShapeSlot>();
            _combinationsChecker = new DefaultRulesChecker(_shapeSlots);
        }
        private void OnEnable()
        {
            this.EventStartListening<ShapeSelectedComplete>();
            this.EventStartListening<ShapesConstructEvent>();
        }
        private void OnDisable()
        {
            this.EventStopListening<ShapeSelectedComplete>();
            this.EventStopListening<ShapesConstructEvent>();
        }

        private bool TryGetEmptySlot(out ShapeSlot shapeSlot)
        {
            for (int i = 0; i < _shapeSlots.Length; i++)
            {
                if (_shapeSlots[i].IsEmpty())
                {
                    shapeSlot = _shapeSlots[i];
                    return true;
                }
            }
            shapeSlot = null;
            return false;
        }
        private void FillEmptySlot(ShapeInfo shapeInfo)
        {
            bool isCombinationsFound = false;
            
            if (TryGetEmptySlot(out ShapeSlot slot))
            {
                slot.FillSlot(shapeInfo);
                isCombinationsFound = _combinationsChecker.CheckForCombinations();
            }
            if (IsAllSlotsFilled() && !isCombinationsFound)
            {
                ShapesPlacesFullEvent.Trigger();
            }
        }

        private bool IsAllSlotsFilled()
        {
            foreach (var t in _shapeSlots)
            {
                if (t.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public void OnEventTrigger(ShapeSelectedComplete eventType)
        {
            FillEmptySlot(eventType.ShapeEventInfo.ShapeInfo);
        }

        public void OnEventTrigger(ShapesConstructEvent eventType)
        {
            for (int i = 0; i < _shapeSlots.Length; i++)
            {
                _shapeSlots[i].ClearSlot();
            }
        }
    }
}
