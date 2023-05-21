using Microsoft.Maui.Controls.Shapes;

namespace TestMenu;

public class NewPage5 : ContentPage
{
	public NewPage5()
	{
        Button btn = new Button
        {
            Text = "Go back"
        };
        btn.Clicked += async (sender, e) => { await Navigation.PopAsync(); };
        Content = new VerticalStackLayout
        {
            Children = {
                new Rectangle
                {
                    Margin = new Thickness(30),
                    HeightRequest = 300,
                    WidthRequest = 300,
                    Fill = Colors.Blue
                },
                new Ellipse
                {
                    Margin = new Thickness(30),
                    HeightRequest = 300,
                    WidthRequest = 300,
                    Fill = Colors.LimeGreen
                },
                btn
            }
        };
    }
}