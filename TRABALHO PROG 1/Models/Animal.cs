namespace Arquivos.Models
{
  public class Animal
  {
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Tipo { get; set; }

    public string? Raca { get; set; }

    public Animal()
    {

    }

    public Animal(
        int id,
         string name,
         string tipo,
         string raca
         )
    {
      Id = id;
      Name = name;
      Tipo = tipo;
      Raca = raca;
    }

    public override string ToString()
    {
      return $"Id: {this.Id}; Nome: {this.Name}; Tipo: {this.Tipo}";
    }
  }
}