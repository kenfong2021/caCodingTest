using System.Collections.Generic;

namespace C4.Imaging
{
  public interface IAspectRatioRepository
  {
    IEnumerable<AspectRatio> All { get; }
  }
}