using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace Sim
{

  /// <summary>
  /// Represents a collection of vehicle parts.
  /// </summary>
  public class VehiclePartCollection : IEnumerable<IVehiclePart>
  {
    private readonly Dictionary<ulong, IVehiclePart> _parts;

    /// <summary>
    /// Initializes a new instance of the <see cref="VehiclePartCollection"/> class.
    /// </summary>
    public VehiclePartCollection()
    {
      _parts = new Dictionary<ulong, IVehiclePart>();
    }

    /// <summary>
    /// Adds the specified vehicle part to the <see cref="VehiclePartCollection"/>.
    /// </summary>
    /// <param name="part">The vehicle part to add.</param>
    public void Add([NotNull] IVehiclePart part)
    {
      if (!(part.InstanceId is ulong instanceId))
      {
        return;
      }

      _parts.Add(instanceId, part);
    }


    /// <summary>
    /// Removes the specified vehicle part from the <see cref="VehiclePartCollection"/>.
    /// </summary>
    /// <param name="part">The vehicle part to remove.</param>
    /// <returns><c>true</c> if the vehicle part was succesfully removed; otherwise, <c>false</c>.</returns>
    public bool Remove([NotNull] IVehiclePart part)
    {
      return part.InstanceId is ulong instanceId && Remove(instanceId);
    }

    /// <summary>
    /// Removes a vehicle part with the specified instance identifier from the <see cref="VehiclePartCollection"/>.
    /// </summary>
    /// <param name="instanceId">The instance identifier of the vehicle part to remove.</param>
    /// <returns><c>true</c> if the vehicle part was successfully removed; otherwise, <c>false</c>.</returns>
    public bool Remove(ulong instanceId)
    {
      return _parts.Remove(instanceId);
    }


    public IEnumerator<IVehiclePart> GetEnumerator()
    {
      return _parts.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

}