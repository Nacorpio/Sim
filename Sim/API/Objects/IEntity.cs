namespace Sim.API.Objects
{
  /// <summary>
  /// Defines functionality for an object with a unique identity, defined by its identifier.
  /// </summary>
  public interface IEntity : IObject
  {
    /// <summary>
    /// Gets the instance identifier of the entity.
    /// </summary>
    ulong? InstanceId { get; }

    /// <summary>
    /// Gets the template identifier of the entity.
    /// </summary>
    ulong? TemplateId { get; }
  }

}