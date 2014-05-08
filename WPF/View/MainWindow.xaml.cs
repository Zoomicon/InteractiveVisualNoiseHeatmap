//Project: ReadableAthens
//Filename: MainWindow.xaml.cs
//Version: 20140329

using Caching;
using MapControl;
using System;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace ReadableAthens.WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    #region --- Constants ---

    const string IMAGE_EXTENSIONS = "jpg"; //only JPEG supports EXIF (else would separate multiple extensions with | )

    public const string DATA_FOLDER = "App_Data";
    public const string POSTERS_FOLDER = "posters";
    public const string OCR_TEXTS_FOLDER = "OCR_texts";

    #endregion

    #region --- Initialization ---

    public MainWindow()
    {
      TileImageLoader.Cache = new ImageFileCache(TileImageLoader.DefaultCacheName, TileImageLoader.DefaultCacheDirectory);
      InitializeComponent();
      LoadPushpins();
    }

    private void LoadPushpins()
    {
      VmPoints pins = ((ViewModel)map.DataContext).Pushpins;

      var imageFilenames = Directory.EnumerateFiles(Path.Combine(new String[] { System.AppDomain.CurrentDomain.BaseDirectory, DATA_FOLDER, POSTERS_FOLDER })).Where(file => Regex.IsMatch(file, @"^.+\.(" + IMAGE_EXTENSIONS + ")$"));
      foreach (string filename in imageFilenames)
      {
        try
        {
          string textFilename = Path.Combine(new String[] { System.AppDomain.CurrentDomain.BaseDirectory, DATA_FOLDER, OCR_TEXTS_FOLDER, Path.GetFileNameWithoutExtension(filename) + ".txt" });
          Image img = Image.FromFile(filename);
          Location pos = EXIF.GetLocation(img);
          img.Dispose();
          img = null;

          VmPoint pin = new VmPoint()
          {
            Name = "", //Path.GetFileNameWithoutExtension(filename),
            Location = pos,
            Image = /*new BitmapImage*/(new Uri(filename, UriKind.Absolute)),
            Text = File.ReadAllText(textFilename)
          };
          pins.Add(pin);
        }
        catch
        {
          //NOP (ignore images without lat/long EXIF info
        }
      }

    }

    #endregion

    #region --- Events ---

    private void MapMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 2)
      {
        map.ZoomMap(e.GetPosition(map), Math.Floor(map.ZoomLevel + 1.5));
        //map.TargetCenter = map.ViewportPointToLocation(e.GetPosition(map));
      }
    }

    private void MapMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ClickCount == 2)
      {
        map.ZoomMap(e.GetPosition(map), Math.Ceiling(map.ZoomLevel - 1.5));
      }
    }

    private void MapMouseLeave(object sender, MouseEventArgs e)
    {
      mouseLocation.Text = string.Empty;
    }

    private void MapMouseMove(object sender, MouseEventArgs e)
    {
      var location = map.ViewportPointToLocation(e.GetPosition(map));

      UpdateVolume(location);
      UpdateMouseLocation(location); 
    }

    private void MapManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
    {
      e.TranslationBehavior.DesiredDeceleration = 0.001;
    }

    private void MapItemTouchDown(object sender, TouchEventArgs e)
    {
      var mapItem = (MapItem)sender;
      mapItem.IsSelected = !mapItem.IsSelected;

      //mapImage.Source = ((VmPoint)mapItem.DataContext).Image;

      e.Handled = true;
    }

    #endregion

    private void UpdateMouseLocation(Location location)
    {
      var longitude = Location.NormalizeLongitude(location.Longitude);
      var latString = location.Latitude < 0 ?
          string.Format(CultureInfo.InvariantCulture, "S  {0:00.00000}", -location.Latitude) :
          string.Format(CultureInfo.InvariantCulture, "N  {0:00.00000}", location.Latitude);
      var lonString = longitude < 0 ?
          string.Format(CultureInfo.InvariantCulture, "W {0:000.00000}", -longitude) :
          string.Format(CultureInfo.InvariantCulture, "E {0:000.00000}", longitude);
      mouseLocation.Text = latString + ", " + lonString;
    }

    private const double MIN_DISTANCE = 2000; //squared

    private void UpdateVolume(Location location)
    {
      var mousePoint = map.LocationToViewportPoint(location);

      ViewModel vm = (ViewModel)DataContext;

      int maxLen = 1; //don't use 0 to be safe from division by zero later on
      foreach (var p in vm.Pushpins)
      {
        int len = p.Text.Length;
        if (maxLen < len) maxLen = len;
      }

      double volume = 0;
      foreach (var p in vm.Pushpins)
      {
        int len = p.Text.Length;
        if (maxLen < len) maxLen = len;
        if (DistanceSqr(mousePoint, map.LocationToViewportPoint(p.Location)) < MIN_DISTANCE)
          volume += (double)len/(double)maxLen;
      }

      sound.Volume = Math.Min(volume, 1.0);
    }

    private double DistanceSqr(System.Windows.Point p1, System.Windows.Point p2)
    {
      return Square(p1.X - p2.X) + Square(p1.Y - p2.Y);
    }

    private double Square(double v)
    {
      return v * v;
    }

  }
}
