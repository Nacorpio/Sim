using Sim.API.Templates;

namespace Sim.API.Objects
{

  public interface IObject
  {
    ITemplate Template { get; }
    bool IsNull { get; }
  }

}