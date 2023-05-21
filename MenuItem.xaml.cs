using Microsoft.Maui.Layouts;

namespace TestMenu;

public partial class MenuItem : ContentView
{
    private double currentSize;
    public double CurrentSize
    {
        get { return currentSize; }
        set 
        {
            if (value < 80) 
                return;

            currentSize = value; 
            border.WidthRequest = value;
            border.HeightRequest = value;

            if (border.Content == null) 
                return;

            ((border.Content as FlexLayout).Children[0] as ImageButton).HeightRequest = value * 0.6;
            ((border.Content as FlexLayout).Children[1] as Label).FontSize = 24 * (value / 155);
        }
    }


    public MenuItem(string imagePath, string title, ContentPage page)
    {
        InitializeComponent();
        ImageButton imageButton = new ImageButton
        {
            Source = ImageSource.FromFile(imagePath),
            HeightRequest = border.HeightRequest * 0.6,
        };
        imageButton.Clicked += async (sender, e) => { await Navigation.PushAsync(page); };
        FlexLayout layout = new FlexLayout
        {
            Direction = FlexDirection.Column,
            JustifyContent = FlexJustify.SpaceEvenly,
            AlignItems = FlexAlignItems.Center,
            Children =
            {
                imageButton,
                new Label
                {
                    TextColor = Color.FromRgb(56, 54, 150), // цвет текста из Figma прототипа
                    Text = title,
                    FontSize = 24,
                    FontFamily = "RobotoBold",
                }
            }
        };
        border.Content = layout;
        currentSize = 155;
    }
}