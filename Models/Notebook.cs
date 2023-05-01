using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using segundoPractico.Models;


namespace segundoPractico.Controllers;
public class Notebook {
    public int id { get; set; }
    public string marca { get; set; }
    public string modelo { get; set; }
    public int precio { get; set; }

    public virtual List<Empresa> Empresas { get; set; }
}
