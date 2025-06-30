# How to add a row with auto scrolling behavior in .NET MAUI DataGrid SfDataGrid
This demo shows how to add a row with auto scrolling behavior in the Syncfusion [.NET MAUI DataGrid](https://help.syncfusion.com/maui/datagrid/overview) `SfDataGrid`.

This sample helps you to to auto scroll the DataGrid to the last item added in the collection. In this sample, after adding the new data to the grid, the scrolling was performed automatically.

## MainPage.xaml
```
 <ContentPage.BindingContext>
    <local:OrderInfoRepository x:Name="viewModel" />
</ContentPage.BindingContext>

<Grid RowDefinitions="50,*">
    <Button Text="AddRow" WidthRequest="200"
         Clicked="Button_Clicked" />
    
    <syncfusion:SfDataGrid x:Name="dataGrid" Grid.Row="1"
                           ColumnWidthMode="Fill"
                        ItemsSource="{Binding OrderInfoCollection}">
        
    </syncfusion:SfDataGrid>
</Grid>
```

## MainPage.xaml.cs
```
public partial class MainPage : ContentPage
{
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
            await dataGrid.ScrollToRowIndex(viewModel.OrderInfoCollection.Count - 1);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        OrderInfo order = new OrderInfo("2001", "Andrew Fuller", "France", "BLONP", "Strasbourg");
        viewModel.OrderInfoCollection.Add(order);
    }
}
```


Executing the code example above yields the following output

<img src="https://github.com/user-attachments/assets/14be5823-e5c8-44af-8c9d-0ba973de9856" />


Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).

### Conclusion
I hope you enjoyed learning about how to add a row with auto scroll in SfDataGrid.

You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.

If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums),[Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
