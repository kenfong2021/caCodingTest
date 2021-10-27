using System.Drawing;

namespace C4.Imaging
{
  public interface IImageAnalyser
  {
    Size GetImageSize(string imageFileLocation);
  }
}