using System.Collections.Generic;

namespace GameEngineLibrary
{
    public interface IScene
    {
        string Name { get; }
        int BuildIndex { get; }
        bool IsLoaded { get; }
        IEnumerable<IGameObject> GameObjects { get; }

        void AddGameObject(IGameObject gameObject);
        void RemoveGameObject(IGameObject gameObject);
    }
}
