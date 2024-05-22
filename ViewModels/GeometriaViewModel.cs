using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using MVVM_Geometria.Models;
using MVVM_Geometria.Views;

namespace MVVM_Geometria.ViewModels;

public sealed class GeometriaViewModel: INotifyPropertyChanged
{
    private readonly Geometria _geo = new();
    
    public string? LadoMayor { 
        get => _geo.LadoMayor.ToString();
        set
        {
            if (value == "")
                _geo.LadoMayor = null;
            else
            {
                try
                {
                    _geo.LadoMayor = Double.Parse(value!);
                }
                catch (Exception e)
                {
                    Mensaje = $"Error: {e.Message}";
                }
            }
        }
    }
    public string? LadoMenor { 
        get => _geo.LadoMenor.ToString();
        set
        {
            if (value == "")
                _geo.LadoMenor = null;
            else
            {
                try
                {
                    _geo.LadoMenor = Double.Parse(value!);
                }
                catch (Exception e)
                {
                    Mensaje = $"Error: {e.Message}";
                }
            }
        }
    }
    public string? Radio { 
        get => _geo.Radio.ToString();
        set
        {
            if (value == "")
                _geo.Radio = null;
            else
            {
                try
                {
                    _geo.Radio = Double.Parse(value!);
                }
                catch (Exception e)
                {
                    Mensaje = $"Error: {e.Message}";
                }
            }
        }
    }
    public double? AreaRectangulo => _geo.AreaRectangulo;
    public double? AreaCirculo => _geo.AreaCirculo;
    public double? Perimetro => _geo.Perimetro;
    public double? LongitudCircunf => _geo.LongitudCircunferencia;
    
    private string? _mensaje = String.Empty;

    public string ColorAreaRect
    {
        get
        {
            return AreaRectangulo switch
            {
                < 15 => "Green",
                < 20 => "Yellow",
                _ => "Red"
            };
        }
    }
    public string ColorAreaCirc
    {
        get
        {
            return AreaCirculo switch
            {
                < 15 => "Green",
                < 50 => "Yellow",
                _ => "Red"
            };
        }
    }
    public string? Mensaje
    {
        get => _mensaje;
        set
        {
            if (_mensaje != value)
            {
                _mensaje = value;
                OnPropertyChanged();
            }
        }
    }
    public void CmdCalcular()
    {
        NotificarResultados();
        Mensaje = "Datos recalculados";
    }

    private void NotificarResultados()
    {
        OnPropertyChanged(nameof(AreaRectangulo));
        OnPropertyChanged(nameof(Perimetro));
        OnPropertyChanged(nameof(LongitudCircunf));
        OnPropertyChanged(nameof(AreaCirculo));
        OnPropertyChanged(nameof(ColorAreaRect));
        OnPropertyChanged(nameof(ColorAreaCirc));
    }
    public void CmdLimpiar()
    {
        LadoMayor = "0";
        LadoMenor = "0";
        Radio = "0";
        OnPropertyChanged(nameof(LadoMayor));
        OnPropertyChanged(nameof(LadoMenor));
        OnPropertyChanged(nameof(Radio));
        NotificarResultados();
        Mensaje = "Datos inicializados";    
    }
    public void CmdSalir(object parametro)
    {
        if (parametro is Int32 )
            Mensaje = $"Comando de salir ejecutado: {parametro}";
        if (parametro is Window)
        {
            ((Window)parametro).Close();
            Mensaje = "Detectado cierre de ventana, rechazado";
        }
    }
    
    public bool CanCmdSalir(object parameter)
    {
        return true;
    }

    public void CmdAyuda(object ventanaPadre)
    {
        new AyudaWindow().ShowDialog((Window)ventanaPadre);
    }
    public void CmdAcercaDe(object ventanaPadre)
    {
        new AcercaDeWindow().ShowDialog((Window)ventanaPadre);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}