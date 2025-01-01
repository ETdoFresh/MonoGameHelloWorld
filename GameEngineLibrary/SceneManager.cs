using System;
using System.Collections.Generic;

namespace GameEngineLibrary
{
    public class SceneManager : ISceneManager
    {
        private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
        private Scene _activeScene;
        private int _nextBuildIndex = 0;

        public int SceneCount => _scenes.Count;
        public event Action<Scene> SceneLoaded;

        public void LoadScene(string sceneName)
        {
            if (_scenes.TryGetValue(sceneName, out var scene))
            {
                _activeScene = scene;
                SceneLoaded?.Invoke(scene);
            }
            else
            {
                throw new ArgumentException($"Scene '{sceneName}' not found");
            }
        }

        public void LoadScene(int sceneBuildIndex)
        {
            foreach (var scene in _scenes.Values)
            {
                if (scene.BuildIndex == sceneBuildIndex)
                {
                    _activeScene = scene;
                    SceneLoaded?.Invoke(scene);
                    return;
                }
            }
            throw new ArgumentException($"Scene with build index {sceneBuildIndex} not found");
        }

        public Scene GetActiveScene()
        {
            return _activeScene;
        }

        public Scene CreateScene(string name)
        {
            var scene = new Scene(name, _nextBuildIndex++);
            _scenes[name] = scene;
            return scene;
        }

        public void UnloadCurrentScene()
        {
            if (_activeScene != null)
            {
                _activeScene.Destroy();
                _activeScene = null;
            }
        }

        public void Update(float deltaTime)
        {
            _activeScene?.Update(deltaTime);
        }
    }
}
