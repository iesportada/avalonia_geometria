using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace MVVM_Geometria.ViewModels;

public struct EstructAyuda
{
    public string Id;
    public string Valor;
}
public sealed class AyudaViewModel: INotifyPropertyChanged 
{
    public string? TextoAyuda => ListarJson("Assets/ayuda.json");
    private string ListarJson(string ruta) {
        if (!File.Exists(ruta))
        {
            return String.Empty;
        }
        string json = File.ReadAllText(ruta);
        dynamic? listado = JsonConvert.DeserializeObject<List<EstructAyuda>>(json);

        string resultado = String.Empty;
        if (listado != null)
            foreach (EstructAyuda item in listado)
                resultado += $"{item.Id}: {item.Valor} \n";
        
        return resultado;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}