using System;
using System.Collections.Generic;

namespace GameEngineLibrary
{
    public class GameObject : IGameObject
    {
        private static int _nextInstanceID = 1;
        public int InstanceID { get; private set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public bool ActiveSelf { get; private set; }
        public Transform Transform { get; private set; }
        private List<IComponent> _components = new List<IComponent>();

        public GameObject(string name)
        {
            Name = name;
            ActiveSelf = true;
            IsActive = true;
            InstanceID = _nextInstanceID++;
            Transform = new Transform();
            AddComponent(Transform);
        }

        public void Initialize()
        {
            // Initialize all components
            foreach (var component in _components)
            {
                if (component is IInitializable initializable)
                {
                    initializable.Initialize();
                }
            }
        }

        public void Update(float deltaTime)
        {
            if (!IsActive) return;
            
            // Update all components
            foreach (var component in _components)
            {
                if (component is IUpdatable updatable)
                {
                    updatable.Update(deltaTime);
                }
            }
        }

        public void Destroy()
        {
            // Clean up all components
            foreach (var component in _components)
            {
                if (component is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            _components.Clear();
            IsActive = false;
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
