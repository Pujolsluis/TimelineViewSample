using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TimelineViewSample.Models;
using TimelineViewSample.Services;
using Xamarin.Forms;

namespace TimelineViewSample.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TimelineItem> Data { get; set; } = new ObservableCollection<TimelineItem>();
        public ICommand OnLoadMoreCommand { get; set; }
        public ICommand OnItemTappedCommand { get; set; }
        public DataService _dataService { get; set; } = new DataService();
        int _pageNumber = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        bool IsBusy { get; set; }

        public MainPageViewModel()
        {
            // Command to load more data from our service
            OnLoadMoreCommand = new Command(async () =>
            {
                IsBusy = true;

                try
                {
                    var users = await _dataService.GetUsersAsync(_pageNumber++, 10);

                    //Add the new data loaded from our service to our existing collection.
                    foreach (var user in users)
                    {
                        Data.Add(user);
                    }

                }
                catch (Exception ex)
                {
                    //Log any errors that might had occured while calling or using your service.
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }

            });

            // Command to react to taps on the listview
            OnItemTappedCommand = new Command<TimelineItem>(async (TimelineItem item) =>
            {
                await Application.Current.MainPage.DisplayAlert("Selected User", $"You have selected {item.UserName}", "OK");
            });

            OnLoadMoreCommand.Execute(null);
        }
    }
}
