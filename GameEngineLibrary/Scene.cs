using System.Collections.Generic;

namespace GameEngineLibrary
{
    public class Scene : IScene
    {
        public string Name { get; private set; }
        public int BuildIndex { get; private set; }
        public bool IsLoaded { get; private set; }
        public IEnumerable<IGameObject> GameObjects => _gameObjects;
        private List<IGameObject> _gameObjects;

        public Scene(string name, int buildIndex)
        {
            Name = name;
            BuildIndex = buildIndex;
            _gameObjects = new List<IGameObject>();
            IsLoaded = false;
        }

        public void AddGameObject(IGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public void Destroy()
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Destroy();
            }
            _gameObjects.Clear();
            IsLoaded = false;
        }

        public void Update(float deltaTime)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(deltaTime);
            }
        }
    }
}
