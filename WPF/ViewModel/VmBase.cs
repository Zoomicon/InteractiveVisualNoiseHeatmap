//Project: ReadableAthens
//Filename: VmBase.cs
//Version: 20140329

using System.ComponentModel;

namespace ReadableAthens
{
  public class VmBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

  }

}
