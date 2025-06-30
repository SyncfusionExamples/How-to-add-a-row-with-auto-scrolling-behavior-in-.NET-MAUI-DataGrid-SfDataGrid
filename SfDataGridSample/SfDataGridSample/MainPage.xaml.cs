using Syncfusion.Maui.Core.Carousel;
using System.Collections.Specialized;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            dataGrid.Loaded += DataGrid_Loaded;
        }

        private void DataGrid_Loaded(object? sender, EventArgs e)
        {
            dataGrid.View!.CollectionChanged += MainPage_CollectionChanged;
        }

        private async void MainPage_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                await Task.Delay(500);
                await dataGrid.ScrollToRowIndex(ViewModel.OrderInfoCollection.Count - 1);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            OrderInfo order = new OrderInfo("2001", "Andrew Fuller", "France", "BLONP", "Strasbourg");
            ViewModel.OrderInfoCollection.Add(order);
        }
        
    }

}
