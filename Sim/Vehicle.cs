using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace Sim
{
  public class Vehicle : Thing, IVehicle, IAssembly<IVehiclePart>, IDamageable
  {
    public const int VehicleMaxHealth = 100;
    public const int VehicleMinHealth = 0;

    public event EventHandler Fixed;
    public event EventHandler Broken;
    public event EventHandler DamageTaken;
    public event EventHandler HealthValueChanged;

    private readonly VehiclePartCollection _parts;
    private readonly VehicleSeatCollection _seats;

    public new static Entity Null => new Vehicle();

    public event EventHandler PartInstalled;
    public event EventHandler PartUninstalled;

    protected Vehicle(ulong instanceId, [NotNull] IVehicleTemplate template) : base(instanceId, template)
    {
      _parts = new VehiclePartCollection();
      _seats = new VehicleSeatCollection();
    }

    protected Vehicle()
    {
      _parts = null;
      _seats = null;
    }

    public new IVehicleTemplate Template => base.Template as IVehicleTemplate;

    public int Health { get; private set; }
    public bool IsBroken { get; private set; }

    public IReadOnlyList<IPart> Parts => new List<IPart>(_parts);
    public IReadOnlyList<IVehicleSeat> Seats => new List<IVehicleSeat>(_seats);

    public IOrganism GetDriver() => GetDriverSeat().Occupant;

    public void InstallPart(IVehiclePart part)
    {
      _parts.Add(part);
      OnPartInstalled();
    }

    public bool UninstallPart(IVehiclePart part)
    {
      if (!_parts.Remove(part))
      {
        return false;
      }

      OnPartUninstalled();
      return true;
    }

    public IVehicleSeat GetDriverSeat()
    {
      return _seats.FirstOrDefault(x => x.Kind.Equals(VehicleSeatKind.Driver));
    }

    public IEnumerable<IVehicleSeat> GetPassengerSeats()
    {
      return _seats.Where(x => x.Kind.Equals(VehicleSeatKind.Passenger));
    }

    public void Fix()
    {
      if (!IsBroken)
      {
        return;
      }

      IsBroken = false;
      SetHealth(VehicleMaxHealth);

      OnFixed();
    }

    public void Break()
    {
      if (IsBroken)
      {
        return;
      }

      IsBroken = true;
      SetHealth(0);

      OnBroken();
    }

    public int ApplyDamage(DamageInfo damageInfo)
    {
      var newValue = Health - damageInfo.HealthValue;

      if (newValue <= VehicleMinHealth)
      {
        Break();
        return 0;
      }

      SetHealth(newValue);
      OnDamageTaken();
    }

    public void SetHealth(int hpValue)
    {
      if (hpValue > VehicleMaxHealth)
      {
        return;
      }

      if (hpValue <= VehicleMinHealth)
      {
        Break();
        return;
      }

      Health = hpValue;
      OnHealthValueChanged();
    }

    protected virtual void OnFixed()
    {
      Fixed?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnBroken()
    {
      Broken?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnHealthValueChanged()
    {
      HealthValueChanged?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnPartInstalled()
    {
      PartInstalled?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnPartUninstalled()
    {
      PartUninstalled?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnDamageTaken()
    {
      DamageTaken?.Invoke(this, EventArgs.Empty);
    }
  }

}