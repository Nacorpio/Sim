namespace Sim
{

  public interface IObject
  {
    ITemplate Template { get; }
    bool IsNull { get; }
  }

}