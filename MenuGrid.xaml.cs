namespace TestMenu;

public partial class MenuGrid : ContentView
{
    int currentColumn = 0;
    int currentRow = 0;
    int maxColumns = 2; // Максимальное кол-во тайлов в одном ряду

    double originalSize;

    public MenuGrid() // Конструктор добавляет в Grid 1 ряд и 2 столбца
    {
        InitializeComponent();
        for (int i = 0; i < maxColumns; i++)
            MainGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        AddItem(new MenuItem("sheets.png", "Справки", new NewPage1()));
        AddItem(new MenuItem("slides.png", "Приказы", new NewPage2()));
        AddItem(new MenuItem("forms.png", "Объявления", new NewPage3()));
        AddItem(new MenuItem("docs.png", "Антиплагиат", new NewPage4()));
    }

    public void AddItem(MenuItem menuItem) // Добавление тайла
    {
        if (currentColumn == maxColumns) // Если максимальное количество тайлов в ряду, переход на следующий ряд
        {
            currentColumn = 0;
            currentRow += 1;
            MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
        }

        MainGrid.Add(menuItem, currentColumn, currentRow);

        currentColumn += 1;
    }
    public void InsertItemAt(int index, MenuItem menuItem)
    {
        if (index >= MainGrid.Count || index < 0)
            return;
        MainGrid.Insert(index, menuItem);
        Reorder();
    }
    public void DeleteItemAt(int index) // Удаляет Item так, что все последующие тайлы "съезжают", заолняя пустоту
    {
        if (index >= MainGrid.Count || index < 0)
            return;
        MainGrid.RemoveAt(index);
        Reorder();
    }
    public void ReplaceItemAt(int index, MenuItem newItem)
    {
        if (index >= MainGrid.Count || index < 0)
            return;
        MainGrid[index] = newItem;
    }
    public void SetTileScale(double newScale)
    {
        MainGrid.AsParallel().ForAll((item) =>
        {
            (item as MenuItem).CurrentSize = newScale;
        });

    }
    private void Reorder()
    {
        IView[] items = MainGrid.AsParallel().ToArray(); // Copy of an array of items
        for (int i = MainGrid.Count - 1; i >= 0; i--) // Emptying an original array
            MainGrid.RemoveAt(i);

        // Resetting row definitions
        MainGrid.RowDefinitions.Clear();
        MainGrid.AddRowDefinition(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

        MainGrid.ColumnDefinitions.Clear();
        for (int i = 0; i < maxColumns; i++)
            MainGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        // Readding an items in the right order
        currentColumn = 0;
        currentRow = 0;
        foreach (MenuItem item in items)
            AddItem(item);
    }
}