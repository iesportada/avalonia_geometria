using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MVVM_Geometria.ViewModels;

namespace MVVM_Geometria.Views;

public partial class AyudaWindow : Window
{
    public AyudaWindow()
    {
        InitializeComponent();
        // importante: Si no especificamos su contexto de datos, los bindings no funcionan
        DataContext = new AyudaViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}