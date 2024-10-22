using System.Collections.ObjectModel;
using System.ComponentModel;
using CheckInSystem.Models;

namespace CheckInSystem.ViewModels;

public class ViewmodelBase : INotifyPropertyChanged
{
    public static ObservableCollection<Employee> employees { get; set; }
    public static ObservableCollection<Group> Groups { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}