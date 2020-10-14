using System.Collections.Generic;

namespace Sim
{
  /// <summary>
  /// Defines functionality for an object that can be driven/rode by a creature.
  /// </summary>
  public interface IVehicle : IThing
  {
    /// <summary>
    /// Gets the template of the vehicle.
    /// </summary>
    new IVehicleTemplate Template { get; }


    /// <summary>
    /// Gets a collection of the seats in the vehicle.
    /// </summary>
    IReadOnlyList <IVehicleSeat> Seats { get; }


    /// <summary>
    /// Returns the driver seat of the vehicle.
    /// </summary>
    /// <returns>The driver seat.</returns>
    IVehicleSeat GetDriverSeat();

    /// <summary>
    /// Returns a collection of the passenger seats in the vehicle.
    /// </summary>
    /// <returns>The passenger seats in the vehicle.</returns>
    IEnumerable <IVehicleSeat> GetPassengerSeats();
  }

}