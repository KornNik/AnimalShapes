using Helpers;

namespace Behaviours
{
    struct ShapesPlayingFieldClear
    {
        private static ShapesPlayingFieldClear _shapesPlayingFieldClear;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_shapesPlayingFieldClear);
        }
    }
}