//Project: ReadableAthens
//Filename: EXIF.cs
//Version: 20140329

using System;
using System.Drawing; //WARNING: don't have "using System.Windows.Controls", has other Image class (a UI control)
using System.Drawing.Imaging;

using MapControl;

namespace ReadableAthens
{
  class EXIF
  {

    public static Location GetLocation(Image img) //throws exception if can't get location
    {
      return new Location()
      {
        Latitude = (double)GetLatitude(img),
        Longitude = (double)GetLongitude(img)
      };
    }

    private static double? GetLatitude(Image targetImg)
    {
      try
      {
        //Property Item 0x0001 - PropertyTagGpsLatitudeRef
        PropertyItem propItemRef = targetImg.GetPropertyItem(1);
        //Property Item 0x0002 - PropertyTagGpsLatitude
        PropertyItem propItemLat = targetImg.GetPropertyItem(2);
        return ExifGpsToDouble(propItemRef, propItemLat);
      }
      catch (ArgumentException)
      {
        return null;
      }
    }
    private static double? GetLongitude(Image targetImg)
    {
      try
      {
        ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
        PropertyItem propItemRef = targetImg.GetPropertyItem(3);
        //Property Item 0x0004 - PropertyTagGpsLongitude
        PropertyItem propItemLong = targetImg.GetPropertyItem(4);
        return ExifGpsToDouble(propItemRef, propItemLong);
      }
      catch (ArgumentException)
      {
        return null;
      }
    }

    private static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
    {
      double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
      double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
      double degrees = degreesNumerator / (double)degreesDenominator;

      double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
      double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
      double minutes = minutesNumerator / (double)minutesDenominator;

      double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
      double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
      double seconds = secondsNumerator / (double)secondsDenominator;


      double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
      string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
      if (gpsRef == "S" || gpsRef == "W")
        coorditate = coorditate * -1;
      return coorditate;
    }

  }
}
