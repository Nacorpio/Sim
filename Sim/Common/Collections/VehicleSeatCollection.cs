using System;
using System.Collections;
using System.Collections.Generic;

using JetBrains.Annotations;

using Sim.API.Objects;
using Sim.Common.Objects;

namespace Sim.Common.Collections
{

  /// <summary>
  /// Represents a collection of vehicle seats.
  /// </summary>
  public class VehicleSeatCollection : IEnumerable<IVehicleSeat>
  {
    private readonly Dictionary<ulong, IVehicleSeat> _seats;

    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleSeatCollection"/> class.
    /// </summary>
    public VehicleSeatCollection()
    {
      _seats = new Dictionary<ulong, IVehicleSeat>();
    }


    /// <summary>
    /// Adds the specified <see cref="VehicleSeat"/> to the <see cref="VehicleSeatCollection"/>.
    /// </summary>
    /// <param name="seat">The vehicle seat to add.</param>
    public void Add([NotNull] IVehicleSeat seat)
    {
      if (!(seat.InstanceId is ulong instanceId))
      {
        return;
      }

      _seats.Add(instanceId, seat);
    }


    /// <summary>
    /// Removes the specified <see cref="VehicleSeat"/> from the <see cref="VehicleSeatCollection"/>.
    /// </summary>
    /// <param name="seat">The vehicle seat to remove.</param>
    /// <returns><c>true</c> if the vehicle seat was successfully removed; otherwise, <c>false</c>.</returns>
    public bool Remove(IVehicleSeat seat)
    {
      return seat.InstanceId is ulong instanceId && Remove(instanceId);
    }

    /// <summary>
    /// Removes a <see cref="VehicleSeat"/> with the specified instance identifier from the <see cref="VehicleSeatCollection"/>.
    /// </summary>
    /// <param name="instanceId">The instance identifier of the vehicle seat to remove.</param>
    /// <returns><c>true</c> if the vehicle seat was successfully removed; otherwise, <c>false</c>.</returns>
    public bool Remove(ulong instanceId)
    {
      return Contains(instanceId) && _seats.Remove(instanceId);
    }


    /// <summary>
    /// Returns a value indicating whether the <see cref="VehicleSeatCollection"/> contains the specified <see cref="VehicleSeat"/>.
    /// </summary>
    /// <param name="seat">The vehicle seat to find.</param>
    /// <returns><c>true</c> if the vehicle seat was found; otherwise, <c>false</c>.</returns>
    public bool Contains([NotNull] IVehicleSeat seat)
    {
      return seat.InstanceId is ulong instanceId && Contains(instanceId);
    }

    /// <summary>
    /// Returns a value indicating whether the <see cref="VehicleSeatCollection"/> contains a <see cref="VehicleSeat"/> with the specified instance identifier.
    /// </summary>
    /// <param name="instanceId">The instance identifier of the vehicle seat to find.</param>
    /// <returns><c>true</c> if the vehicle seat was found; otherwise, <c>false</c>.</returns>
    public bool Contains(ulong instanceId)
    {
      return _seats.ContainsKey(instanceId);
    }


    private IVehicleSeat AddPassengerSeat()
    {
      throw new NotImplementedException();
    }

    private IVehiclePart AddDriverSeat()
    {
      throw new NotImplementedException();
    }


    public IEnumerator<IVehicleSeat> GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

}