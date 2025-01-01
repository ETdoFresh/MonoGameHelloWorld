using System.Numerics;

namespace GameEngineLibrary
{
    public class Transform : ITransform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public IGameObject GameObject { get; private set; } = null!;
        public bool Enabled { get; set; } = true;

        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }

        public void Translate(Vector3 translation)
        {
            Position += translation;
        }

        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
        }

        public void ScaleBy(Vector3 scale)
        {
            Scale *= scale;
        }

        public void OnEnable()
        {
            Enabled = true;
        }

        public void OnDisable()
        {
            Enabled = false;
        }
    }
}
