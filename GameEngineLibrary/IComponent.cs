namespace GameEngineLibrary
{
    public interface IComponent
    {
        IGameObject GameObject { get; }
        bool Enabled { get; set; }
        void OnEnable();
        void OnDisable();
    }
}
