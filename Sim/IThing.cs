using UnitsNet;

namespace Sim
{

  public interface IThing : IEntity
  {
    /// <summary>
    /// Gets the template of the thing.
    /// </summary>
    new IThingTemplate Template { get; }


    /// <summary>
    /// Gets the volume of the thing.
    /// </summary>
    Volume? Volume { get; }

    /// <summary>
    /// Gets the mass of the thing.
    /// </summary>
    Mass? Mass { get; }
  }

}