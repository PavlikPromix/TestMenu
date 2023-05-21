namespace TestMenu;

public partial class MenuGrid : ContentView
{
    int currentColumn = 0;
    int currentRow = 0;
    int maxColumns = 2; // ������������ ���-�� ������ � ����� ����

    double originalSize;

    public MenuGrid() // ����������� ��������� � Grid 1 ��� � 2 �������
    {
        InitializeComponent();
        for (int i = 0; i < maxColumns; i++)
            MainGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        AddItem(new MenuItem("sheets.png", "�������", new NewPage1()));
        AddItem(new MenuItem("slides.png", "�������", new NewPage2()));
        AddItem(new MenuItem("forms.png", "����������", new NewPage3()));
        AddItem(new MenuItem("docs.png", "�����������", new NewPage4()));
    }

    public void AddItem(MenuItem menuItem) // ���������� �����
    {
        if (currentColumn == maxColumns) // ���� ������������ ���������� ������ � ����, ������� �� ��������� ���
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
    public void DeleteItemAt(int index) // ������� Item ���, ��� ��� ����������� ����� "��������", ������� �������
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