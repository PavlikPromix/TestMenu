namespace TestMenu;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        MenuGrid grid = new MenuGrid();

        grid.DeleteItemAt(0);

        grid.InsertItemAt(0, new MenuItem("sheets.png", "Справки", new NewPage1()));

        grid.AddItem(new MenuItem("slides.png", "Фигуры))0)", new NewPage5()));

        stack.Content = grid;
    }
}

