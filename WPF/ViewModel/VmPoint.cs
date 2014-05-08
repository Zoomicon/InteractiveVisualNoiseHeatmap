//Project: ReadableAthens
//Filename: VmPoint.cs
//Version: 20140329

using MapControl;
using System;
using System.Windows.Media;

namespace ReadableAthens
{
  public class VmPoint : VmBase
  {
    private string name;
    private Location location;
    private Uri image;
    //private ImageSource image;
    private string text;

    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        OnPropertyChanged("Name");
      }
    }

    public Location Location
    {
      get { return location; }
      set
      {
        location = value;
        OnPropertyChanged("Location");
      }
    }

    //public ImageSource Image
    public Uri Image
    {
      get { return image; }
      set
      {
        image = value;
        OnPropertyChanged("Image");
      }
    }

    public string Text
    {
      get { return text; }
      set
      {
        text = value;
        OnPropertyChanged("Text");
      }
    }

  }

}
