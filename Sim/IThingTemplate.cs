using Newtonsoft.Json;

using UnitsNet;

namespace Sim
{

  public interface IThingTemplate : ITemplate
  {
    [JsonProperty("mass", Order = 1)]
    Mass? Mass { get; }

    [JsonProperty("volume", Order = 2)]
    Volume? Volume { get; }
  }

}