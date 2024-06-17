using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Models
{//Inicio do escopo do namespace
  public class Client
  {//Inicio do escopo da classe
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? CPF { get; set; }

    public string? Email { get; set; }

    // Os métodos construtores são responsáveis por instanciar uma variável do tipo especificado pela classe.
    public Client()
    {

    }

    // Método SEMPRE utiliza()
    // O Método construtor deve ter o mesmo nome da classe
    public Client(
     int id,
     string? firstName,
     string? lastName,
     string? cPF,
     string? email
     )
    { //Inicio do escopo deste método
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      CPF = cPF;
      Email = email;
    }//Fim do escopo deste método
     //() Delimitam os parametros, {} chaves delimitam as instruções, o escopo

    public string FullName => $"{this.FirstName} {this.LastName}";

    public override string ToString()
    {
      return $"Id: {this.Id}; Name: {this.FullName}";
    }
  } //Fim do escopo da classe

} // Fim do escopo do namespace
