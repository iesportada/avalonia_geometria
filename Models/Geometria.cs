using System;

namespace MVVM_Geometria.Models;

public class Geometria
{
    private double? _ladoMayor= 3, _ladoMenor = 4, _radio = 5;

    public double? LadoMayor
    {
        get => _ladoMayor;
        set {
            if (value < 0)
                throw new Exception("Valor negativo");
            else
            {
                _ladoMayor = value ?? 0;
            }
        }
    }
    public double? LadoMenor
    {
        get => _ladoMenor;
        set {
            if (value < 0)
                throw new Exception("Valor negativo");
            else
            {
                _ladoMenor = value ?? 0;
            }
        }
    } 
    public double? Radio
    {
        get => _radio;
        set {
            if (value < 0)
                throw new Exception("Valor negativo");
            else
            {
                _radio = value ?? 0;
            }
        }
    }
    public double? Perimetro => 2 * LadoMayor + 2 * LadoMenor;
    public double? AreaRectangulo => LadoMayor * LadoMenor;
    public double? LongitudCircunferencia => 2 * Radio * Math.PI;
    public double? AreaCirculo => Radio * Radio * Math.PI;
}