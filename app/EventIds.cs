using Microsoft.Extensions.Logging;

namespace Demo
{
  public static class EventIds
  {
    public static readonly EventId ResourceStateChanged = new EventId(1, nameof(ResourceStateChanged));
  }
}
