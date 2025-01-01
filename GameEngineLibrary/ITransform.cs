using System.Numerics;

namespace GameEngineLibrary
{
    public interface ITransform : IComponent
    {
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Scale { get; set; }

        void Translate(Vector3 translation);
        void Rotate(Vector3 rotation);
        void ScaleBy(Vector3 scale);
    }
}
