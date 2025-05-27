using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class ShapesCreator : MonoBehaviour, IShapesCreator, IEventListener<ShapesConstructEvent>
    {
        [SerializeField] private Transform _spawnTransform;

        private ShapeFactory _shapeFactory;
        private ShapesShaffler _shaffler;
        private Formater _formater;
        private ShapesContainer _shapesContainer;

        private void Awake()
        {
            _shapeFactory = new ShapeFactory(_spawnTransform);
            _shapesContainer = new ShapesContainer();
            _shaffler = new ShapesShaffler();
            _formater = new Formater();
        }
        private void OnEnable()
        {
            this.EventStartListening<ShapesConstructEvent>();
        }
        private void OnDisable()
        {
            this.EventStopListening<ShapesConstructEvent>();
        }

        public void CreateAndPlace(Transform activatePoint)
        {
            var shapes = _shapeFactory.Create();
            _shapesContainer.FillShapes(shapes);
            
            var shaffleShapes = _shaffler.ShaffleShapes(shapes);
            _formater.MakeFormation(shaffleShapes, activatePoint);
        }

        public void DestroyShapes()
        {
            _shapeFactory.Destroy();
        }

        public void OnEventTrigger(ShapesConstructEvent eventType)
        {
            if (eventType.EventType == ConstructEventType.Create)
            {
                CreateAndPlace(Services.Instance.Level.ServicesObject.StartSpawnPoint);
            }
            else if (eventType.EventType == ConstructEventType.Destroy)
            {
                DestroyShapes();
            }
        }
    }
}
