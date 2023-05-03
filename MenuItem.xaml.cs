namespace TestMenu;

public partial class MenuItem : ContentView
{
    public MenuItem()
    {
        InitializeComponent();
    }
    public MenuItem(string imagePath, string title)
    {
        InitializeComponent();
        StackLayout layout = new StackLayout
        {
            Children =
            {
                new Image
                {
                    Source = ImageSource.FromFile(imagePath),
                    HeightRequest = frame.HeightRequest * 0.6,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 10, 0, 5),
                },
                new Label
                {
                    TextColor = Color.FromRgb(56, 54, 150),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = title,
                    FontSize = 24,
                    LineHeight = 25,
                    FontFamily = "RobotoBold",
                    Margin = new Thickness(0, 5)
                }
            }
        };
        frame.Content = layout;
    }
}