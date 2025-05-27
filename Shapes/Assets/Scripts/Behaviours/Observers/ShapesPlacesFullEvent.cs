using Helpers;

namespace Behaviours
{
    struct ShapesPlacesFullEvent
    {
        private static ShapesPlacesFullEvent _shapesPlacesFullEvent;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_shapesPlacesFullEvent);
        }
    }
}