namespace GameEngineLibrary
{
    public interface IBehaviour : IComponent
    {
        void Start();
        void Update();
        void LateUpdate();
        void FixedUpdate();
    }
}
