namespace GameEngineLibrary
{
    public interface IGameObject : IObject
    {
        string Name { get; set; }
        void Initialize();
        void Update(float deltaTime);
        void Destroy();
    }
}
