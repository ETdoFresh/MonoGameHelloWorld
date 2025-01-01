using System;

namespace GameEngineLibrary
{
    public interface ISceneManager
    {
        /// <summary>
        /// Loads a scene by name
        /// </summary>
        void LoadScene(string sceneName);

        /// <summary>
        /// Loads a scene by build index
        /// </summary>
        void LoadScene(int sceneBuildIndex);

        /// <summary>
        /// Gets the currently active scene
        /// </summary>
        Scene GetActiveScene();

        /// <summary>
        /// Gets the number of scenes in Build Settings
        /// </summary>
        int SceneCount { get; }

        /// <summary>
        /// Event triggered when a scene is loaded
        /// </summary>
        event Action<Scene> SceneLoaded;
    }
}
