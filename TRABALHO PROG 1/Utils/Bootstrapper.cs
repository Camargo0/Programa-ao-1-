using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Utils
{
  public class Bootstrapper
  {
    public static void ChargeClients()
    {
      var c1 = new Client
      {
        Id = 1,
        FirstName = "Wesllen",
        LastName = "Da Cruz",
        CPF = "000.000.000-00",
        Email = "wesllenf11@gmail.com"
      };
      DataSet.Clients.Add(c1);

      DataSet.Clients.Add(
          new Client
          {
            Id = 2,
            FirstName = "Jorge",
            LastName = "Sampaoli",
            CPF = "000.000.000-01",
            Email = "sampaoli@gmail.com"
          }
      );

      DataSet.Clients.Add(
          new Client
          {
            Id = 3,
            FirstName = "Flávio",
            LastName = "Caça Rato",
            CPF = "000.000.000-02",
            Email = "cacarato@gmail.com"
          }
      );
    }

    public static void ChargeDoctors()
    {
      DataSet.Medicos.Add(
          new Medico
          {
            Id = 1,
            FirstName = "Jeferson",
            LastName = "de melo",
            CPF = "000.000.000-11",
            CRM = "1254"
          }
      );

      DataSet.Medicos.Add(
          new Medico
          {
            Id = 2,
            FirstName = "Claudemar",
            LastName = "Pereira",
            CPF = "123.000.000-15",
            CRM = "5463"
          }
      );

      DataSet.Medicos.Add(
         new Medico
         {
           Id = 3,
           FirstName = "Gabriel",
           LastName = "Barbosa",
           CPF = "123.000.000-20",
           CRM = "2465"
         }
     );
    }

    public static void ChargeAnimals()
    {
      DataSet.Animals.Add(
          new Animal
          {
            Id = 1,
            Name = "Thor",
            Tipo = "Chachorro",
            Raca = "Dachshund",
          }
      );

      DataSet.Animals.Add(
         new Animal
         {
           Id = 2,
           Name = "Trovão",
           Tipo = "Cavalo",
           Raca = "Campolina",
         }
     );

      DataSet.Animals.Add(
         new Animal
         {
           Id = 3,
           Name = "Cristal",
           Tipo = "Gato",
           Raca = "Persa",
         }
     );
    }
  }

}