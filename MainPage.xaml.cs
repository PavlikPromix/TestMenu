using Microsoft.Maui.Controls;

namespace TestMenu;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        MenuGrid grid = new MenuGrid();

        grid.AddItem("sheets.png", "Справки", new NewPage1());
        grid.AddItem("slides.png", "Приказы", new NewPage1());
        grid.AddItem("forms.png", "Объявления", new NewPage1());
        grid.AddItem("docs.png", "Антиплагиат", new NewPage1());

        stack.Content = grid;
	}
}

