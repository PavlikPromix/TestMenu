using Microsoft.Maui.Controls.Shapes;

namespace TestMenu;

public class NewPage3 : ContentPage
{
	public NewPage3()
	{
        Button btn = new Button
        {
            Text = "Go back"
        };
        btn.Clicked += async (sender, e) => { await Navigation.PopAsync(); };
        Content = new VerticalStackLayout
        {
            Children = {
                new Polygon
                {
                    Margin = new Thickness(30),
                    HeightRequest = 300,
                    WidthRequest = 300,
                    Points = new PointCollection
                    {
                        new Point(0, 200),
                        new Point(100, 0),
                        new Point(200, 200)
                    },
                    Fill = Colors.Purple
                },
                btn
            }
        };
    }
}