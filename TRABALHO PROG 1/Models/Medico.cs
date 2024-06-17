namespace Arquivos.Models
{
  public class Medico
  {
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? CPF { get; set; }

    public string? CRM { get; set; }

    public Medico()
    {

    }
    public Medico(
        int id,
        string firstName,
        string lastName,
        string cPF,
        string cRM)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      CPF = cPF;
      CRM = cRM;
    }

    public string FullName => $"{this.FirstName} {this.LastName}";

    public override string ToString()
    {
      return $"Id: {this.Id}; Name: {this.FullName}; CRM: {this.CRM}";
    }
  }
}