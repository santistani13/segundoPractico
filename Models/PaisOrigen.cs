using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using segundoPractico.Models;


namespace segundoPractico.Controllers;
public class PaisOrigen {
    public int id { get; set; }
    public string nombre { get; set; }
   

    public virtual List<Empresa> Empresas { get; set; }
    public int NotebookId { get; set; }
    public virtual Notebook Notebook { get; set; }
}
