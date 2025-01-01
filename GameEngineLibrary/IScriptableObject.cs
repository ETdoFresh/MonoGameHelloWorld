namespace GameEngineLibrary
{
    public interface IScriptableObject : IObject
    {
        void CreateAsset();
        void Save();
        void Load();
    }
}
