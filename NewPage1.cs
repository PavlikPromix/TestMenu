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
                new Label 
                { 
                    HorizontalOptions = LayoutOptions.Center, 
                    VerticalOptions = LayoutOptions.Center, 
                    Text = "Welcome to .NET MAUI!"
                },
                btn
            }
        };
    }
}