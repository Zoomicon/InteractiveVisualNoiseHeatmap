//Project: ReadableAthens
//Filename: ViewModel.cs
//Version: 20140329

using System.Collections.ObjectModel;
using MapControl;

namespace ReadableAthens
{

  public class ViewModel : VmBase
  {

    #region --- Fields ---

    private Location mapCenter;

    #endregion

    #region --- Properties ---

    public VmPoints Pushpins { get; set; }

    public Location MapCenter
    {
      get { return mapCenter; }
      set
      {
        mapCenter = value;
        OnPropertyChanged("MapCenter");
      }
    }

    #endregion

    #region --- Initialization ---
    
    public ViewModel()
    {
      MapCenter = new Location(37.984971, 23.735747);
      Pushpins = new VmPoints();
    }

    #endregion

  }

}
