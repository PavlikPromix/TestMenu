using Microsoft.Maui.Controls.Shapes;

namespace TestMenu;

public class NewPage1 : ContentPage
{
    public NewPage1()
    {
        Button btn = new Button
        {
            Text = "Go back"
        };
        btn.Clicked += async (sender, e) => { await Navigation.PopAsync(); };
        Content = new VerticalStackLayout
        {
            Children = {
                new Ellipse
                {
                    Margin = new Thickness(30),
                    HeightRequest = 300,
                    WidthRequest = 300,
                    Fill = Colors.Green
                },
                btn
            }
        };
    }
}