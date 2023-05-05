namespace TestMenu;

public partial class MenuGrid : ContentView
{
    int column = 0;
    int row = 0;
    int maxColumns = 2; // Максимальное кол-во тайлов в одном ряду
    public MenuGrid() // Конструктор добавляет в Grid 1 ряд и 2 столбца
    {
        InitializeComponent();
        for (int i = 0; i < maxColumns; i++)
            MainGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
    }

    public void AddItem(string imagePath, string title, ContentPage page) // Добавление тайла
    {
        if (column == maxColumns) // Если максимальное количество тайлов в ряду, переход на следующий ряд
        {
            column = 0;
            row += 1;
            MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        }

        MainGrid.Add(new MenuItem(imagePath, title, page), column, row);

        column += 1;
    }
}