using Newtonsoft.Json;

using UnitsNet;

namespace Sim.API.Templates
{

  public interface IVehicleTemplate : IThingTemplate
  {
    [JsonProperty("model", Order = 3)]
    string Model { get; }

    [JsonProperty("manufacturer", Order = 4)]
    string Manufacturer { get; }


    [JsonProperty("volume_capacity", Order = 5)]
    Volume? VolumeCapacity { get; }

    [JsonProperty("mass_capacity", Order = 6)]
    Mass? MassCapacity { get; }
  }

}