namespace TestMenu;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        MenuGrid grid = new MenuGrid();

        grid.DeleteItemAt(0);
        grid.InsertItemAt(0, new MenuItem("sheets.png", "Справки", new NewPage1()));
        grid.SetTileScale(200);

        stack.Content = grid;
    }
}

