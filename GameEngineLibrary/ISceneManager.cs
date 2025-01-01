namespace GameEngineLibrary
{
    public interface ISceneManager
    {
        void LoadScene(string sceneName);
        void UnloadCurrentScene();
        void Update(float deltaTime);
    }
}
