namespace Sim
{

  public class VehicleSeat : PartBase, IVehicleSeat
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleSeat"/> class, specifying the unique instance identfier and kind.
    /// </summary>
    /// <param name="instanceId">The unique instance identifier.</param>
    /// <param name="kind">The kind of seat.</param>
    public VehicleSeat(ulong instanceId, VehicleSeatKind kind) : base(instanceId, null)
    {
      Kind = kind;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleSeat"/> class.
    /// </summary>
    public VehicleSeat()
    {
      Kind = VehicleSeatKind.Undefined;
    }

    /// <summary>
    /// Gets the kind of the <see cref="VehicleSeat"/>.
    /// </summary>
    public VehicleSeatKind Kind { get; }


    /// <summary>
    /// Gets the creature currently occupying the <see cref="VehicleSeat"/>.
    /// </summary>
    public IOrganism Occupant { get; internal set; }


    /// <summary>
    /// Gets a value indicating whether the <see cref="VehicleSeat"/> is occupied.
    /// </summary>
    public bool IsOccupied => Occupant != null;

    /// <summary>
    /// Gets a value indicating whether the <see cref="VehicleSeat"/> is empty.
    /// </summary>
    public bool IsEmpty => !IsOccupied;


    /// <summary>
    /// Occupies the <see cref="VehicleSeat"/> with the specified creature.
    /// </summary>
    /// <param name="newOccupant">The creature to occupy the seat with.</param>
    /// <param name="force">Whether to boot the current occupant out.</param>
    public void Occupy(IOrganism newOccupant, bool force = true)
    {
      if (IsOccupied)
      {
        if (force)
          Occupant = newOccupant;

        return;
      }

      Occupant = newOccupant;
    }

    /// <summary>
    /// Removes the current occupant from the <see cref="VehicleSeat"/>.
    /// </summary>
    public void Clear()
    {
      if (!IsOccupied)
      {
        return;
      }

      Occupant = null;
    }
  }

}