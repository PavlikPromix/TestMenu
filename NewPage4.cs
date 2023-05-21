using Microsoft.Maui.Controls.Shapes;

namespace TestMenu;

public class NewPage4 : ContentPage
{
	public NewPage4()
	{
        Button btn = new Button
        {
            Text = "Go back"
        };
        btn.Clicked += async (sender, e) => { await Navigation.PopAsync(); };
        Content = new VerticalStackLayout
        {
            Children = {
                new AbsoluteLayout
                {
                    Margin = new Thickness(30),
                    HeightRequest = 300,
                    WidthRequest = 300,
                    Children =
                    {
                        new Line
                        {
                            X1 = 0,
                            Y1 = 0,
                            X2 = 200,
                            Y2 = 200,
                            StrokeThickness = 10,
                            Stroke = Colors.Red
                        },
                        new Line
                        {
                            X1 = 200,
                            Y1 = 0,
                            X2 = 0,
                            Y2 = 200,
                            StrokeThickness = 10,
                            Stroke = Colors.Red
                        }
                    }
                },
                btn
            }
        };
    }
}