using Microsoft.Maui.Controls;

namespace TestMenu;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        MenuGrid grid = new MenuGrid();

        grid.AddItem("sheets.png", "Справки");
        grid.AddItem("slides.png", "Приказы");
        grid.AddItem("forms.png", "Объявления");
        grid.AddItem("docs.png", "Антиплагиат");

        stack.Content = grid;
	}
}

