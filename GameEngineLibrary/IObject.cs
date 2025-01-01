namespace GameEngineLibrary
{
    public interface IObject
    {
        int InstanceID { get; }
        bool IsActive { get; set; }
    }
}
