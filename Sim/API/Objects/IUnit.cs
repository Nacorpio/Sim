using Sim.API.Templates;

namespace Sim.API.Objects
{
  /// <summary>
  /// Defines functionality for a thing that is damageable. 
  /// </summary>
  public interface IUnit : IThing, IDamageable
  {
    /// <summary>
    /// Gets the template of the unit.
    /// </summary>
    new IUnitTemplate Template { get; }
  }

}