﻿using JetBrains.Annotations;

namespace Sim
{

  public interface IVehicleSeat : IVehiclePart
  {
    VehicleSeatKind Kind { get; }
    IOrganism Occupant { get; }

    bool IsOccupied { get; }
    bool IsEmpty { get; }

    void Occupy([NotNull] IOrganism newOccupant, bool force = true);

    void Clear();
  }

}