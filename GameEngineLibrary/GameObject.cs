using System.Collections.Generic;

namespace GameEngineLibrary
{
    public class GameObject : IGameObject
    {
        public string Name { get; set; }
        public bool ActiveSelf { get; private set; }
        public Transform Transform { get; private set; }
        private List<IComponent> _components = new List<IComponent>();

        public GameObject(string name)
        {
            Name = name;
            ActiveSelf = true;
            Transform = new Transform();
            AddComponent(Transform);
        }

        public T AddComponent<T>() where T : IComponent, new()
        {
            var component = new T();
            _components.Add(component);
            return component;
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public T GetComponent<T>() where T : IComponent
        {
            foreach (var component in _components)
            {
                if (component is T)
                    return (T)component;
            }
            return default(T);
        }

        public void SetActive(bool active)
        {
            ActiveSelf = active;
        }
    }
}
