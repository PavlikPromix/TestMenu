namespace TestMenu;

public partial class MenuItem : ContentView
{
    public MenuItem()
    {
        InitializeComponent();
    }
    public MenuItem(string imagePath, string title, ContentPage page)
    {
        InitializeComponent();
        ImageButton imageButton = new ImageButton
        {
            Source = ImageSource.FromFile(imagePath),
            HeightRequest = frame.HeightRequest * 0.6,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 10, 0, 5),
        };
        imageButton.Clicked += async (sender, e) => { await Navigation.PushAsync(page); };
        StackLayout layout = new StackLayout
        {
            Children =
            {
                imageButton,
                new Label
                {
                    TextColor = Color.FromRgb(56, 54, 150), // цвет текста из Figma прототипа
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