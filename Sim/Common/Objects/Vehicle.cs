using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using Sim.API;
using Sim.API.Objects;
using Sim.API.Templates;
using Sim.Common.Collections;

namespace Sim.Common.Objects
{
  public class Vehicle : Unit, IVehicle, IAssembly<IVehiclePart>
  {
    public const int VehicleMaxHealth = 100;
    public const int VehicleMinHealth = 0;

    private readonly VehiclePartCollection _parts;
    private readonly VehicleSeatCollection _seats;


    /// <summary>
    /// Gets a new <see cref="Vehicle"/> with a null state.
    /// </summary>
    public new static Entity Null => new Vehicle();


    /// <summary>
    /// Raised when a part has been installed to the <see cref="Vehicle"/>.
    /// </summary>
    public event EventHandler PartInstalled;

    /// <summary>
    /// Raised when a part has been uninstalled to the <see cref="Vehicle"/>.
    /// </summary>
    public event EventHandler PartUninstalled;


    /// <summary>
    /// Initializes a new instance of the <see cref="Vehicle"/> class, specifying its unique instance identifier and template.
    /// </summary>
    /// <param name="instanceId">The unique instance identifier.</param>
    /// <param name="template">The template to use.</param>
    protected Vehicle(ulong instanceId, [NotNull] IVehicleTemplate template) : base(instanceId, template)
    {
      _parts = new VehiclePartCollection();
      _seats = new VehicleSeatCollection();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vehicle"/> class.
    /// </summary>
    protected Vehicle()
    {
      _parts = null;
      _seats = null;
    }

    /// <summary>
    /// Gets the template of the vehicle.
    /// </summary>
    public new IVehicleTemplate Template => base.Template as IVehicleTemplate;


    /// <summary>
    /// Gets the installed parts of the <see cref="Vehicle"/>.
    /// </summary>
    public IReadOnlyList<IPart> Parts => new List<IPart>(_parts);

    /// <summary>
    /// Gets a collection of the seats in the <see cref="Vehicle"/>.
    /// </summary>
    public IReadOnlyList<IVehicleSeat> Seats => new List<IVehicleSeat>(_seats);


    /// <summary>
    /// Returns the driver of the <see cref="Vehicle"/>.
    /// </summary>
    /// <returns>The driver of the vehicle.</returns>
    public IOrganism GetDriver() => GetDriverSeat().Occupant;


    /// <summary>
    /// Installs the specified part to the <see cref="Vehicle"/>.
    /// </summary>
    /// <param name="part">The part to install.</param>
    public void InstallPart(IVehiclePart part)
    {
      _parts.Add(part);
      OnPartInstalled();
    }

    /// <summary>
    /// Uninstalls the specified part from the <see cref="Vehicle"/>.
    /// </summary>
    /// <param name="part">The part to uninstall.</param>
    /// <returns><c>true</c> if the part was successfully uninstalled; otherwise, <c>false</c>.</returns>
    public bool UninstallPart(IVehiclePart part)
    {
      if (!_parts.Remove(part))
      {
        return false;
      }

      OnPartUninstalled();
      return true;
    }


    /// <summary>
    /// Returns the driver seat of the <see cref="Vehicle"/>.
    /// </summary>
    /// <returns>The driver seat.</returns>
    public IVehicleSeat GetDriverSeat()
    {
      return _seats.FirstOrDefault(x => x.Kind.Equals(VehicleSeatKind.Driver));
    }


    public IEnumerable<IVehicleSeat> GetPassengerSeats()
    {
      return _seats.Where(x => x.Kind.Equals(VehicleSeatKind.Passenger));
    }

    protected virtual void OnPartInstalled()
    {
      PartInstalled?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnPartUninstalled()
    {
      PartUninstalled?.Invoke(this, EventArgs.Empty);
    }
  }

}