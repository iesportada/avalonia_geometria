using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MVVM_Geometria.Views;

public partial class GeometriaWindow : Window
{
    public GeometriaWindow()
    {
        InitializeComponent();
    }

    private void BtnSalir_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}