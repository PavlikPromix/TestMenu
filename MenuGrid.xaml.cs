namespace TestMenu;

public partial class MenuGrid : ContentView
{
    int column = 0;
    int row = 0;
    int maxColumns = 2;
    public MenuGrid()
    {
        InitializeComponent();
        for (int i = 0; i < maxColumns; i++)
            MainGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
    }

    public void AddItem(string imagePath, string title)
    {
        if (column == maxColumns)
        {
            column = 0;
            row += 1;
            MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        }

        MainGrid.Add(new MenuItem(imagePath, title), column, row);

        column += 1;
    }
}