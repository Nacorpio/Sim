using Newtonsoft.Json;

namespace Sim.API.Templates
{

  public interface ITemplate
  {
    [JsonProperty("id", Order = 0)]
    ulong Id { get; }

    [JsonProperty("name", Order = 1)]
    string Name { get; }
  }

}