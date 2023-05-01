using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using segundoPractico.Models;


namespace segundoPractico.Controllers;
public class Empresa {
    public int id { get; set; }
    public string nombre { get; set; }
    public string ubicacion { get; set; }

    public string mail { get; set; }

    public int NotebookId { get; set; }
    public virtual Notebook Notebook {get; set; }

    public int PaisOrigenId { get; set; }
    public virtual PaisOrigen PaisOrigen { get; set; }

}
