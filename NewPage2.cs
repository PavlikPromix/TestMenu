using Microsoft.Maui.Controls.Shapes;

namespace TestMenu;

public class NewPage2 : ContentPage
{
	public NewPage2()
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
                    HeightRequest = 400,
                    WidthRequest = 400,
                    BackgroundColor = Colors.Yellow
                },
                btn
            }
        };
    }
}