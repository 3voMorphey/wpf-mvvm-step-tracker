using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_Klimchenya.Model;

namespace WpfApp_Klimchenya.ModelView;

public class AppViewModel: INotifyPropertyChanged
{
    private ICommand saveCommand;
    

    private UserStatistics selectedUser;
    public PointShapeLineExample PointShapeLineExample { get; set; }
    public ObservableCollection<UserStatistics> Users { get; set; }
    public UserStatistics SelectedUser
    {
        get { return selectedUser;  }
        set { selectedUser = value; OnPropertyChanged("SelectedUser"); }
    }


    public AppViewModel()
    {
        Context context = new Context();
        PointShapeLineExample = new PointShapeLineExample();
        foreach (var user in context.Statistics)
        {
            user.Value.CreateGraph();
        }
        Users = Converter.DictionaryTObservableCollection(context.Statistics);

    }

    public ICommand SaveCommand
    {
        get
        {
            if (saveCommand == null) saveCommand = new Command(o => IO.WriteFile(SelectedUser));
            return saveCommand;
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}