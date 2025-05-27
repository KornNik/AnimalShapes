namespace Behaviours
{
    sealed class ComponentInitializerAsync : BaseInitializerAsync
    {
        protected override void FillInitializers()
        {
            Initializers.Add(new ShapeServiceInitializerAsync());
            Initializers.Add(new LevelLoaderInitializerAsync());
            Initializers.Add(new GameStateInitializerAsync());
        }
    }
}
