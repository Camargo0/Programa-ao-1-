using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
  public class MedicoController
  {
    private string directoryName = "ReportFiles";
    private string fileName = "Medicos.txt";

    public List<Medico> List()
    {
      return DataSet.Medicos;
    }

    // "BOOL" é oque ela vai retornar, nesse caso, true ou false
    public bool Insert(Medico medico)
    {
      if (medico == null)
        return false;

      if (medico.Id <= 0)
        return false;

      if (string.IsNullOrWhiteSpace(medico.FirstName))
        return false;

      DataSet.Medicos.Add(medico);
      return true;
    }

    public bool ExportToTextFile()
    {
      if (!Directory.Exists(directoryName))
        Directory.CreateDirectory(directoryName);

      string fileContent = string.Empty;
      foreach (Medico medico in DataSet.Medicos)
      {
        fileContent += $"{medico.Id};{medico.FirstName};{medico.LastName};{medico.CPF};{medico.CRM}";
        fileContent += "\n";
      }

      try
      {
        StreamWriter sw = File.CreateText($"{directoryName}\\{fileName}");

        sw.Write(fileContent);
        sw.Close();
      }
      catch (IOException ioEx)
      {
        Console.WriteLine("Erro ao manipular o arquivo.");
        Console.WriteLine(ioEx.Message);
        return false;
      }
      return true;
    }

    public bool ImportFromTxtFile()
    {
      try
      {
        StreamReader sr = new StreamReader(($"{directoryName}\\{fileName}"));

        string line = string.Empty;
        line = sr.ReadLine();

        while (line != null)
        {
          Medico medico = new Medico();
          string[] medicoData = line.Split(';');
          medico.Id = Convert.ToInt32(medicoData[0]);
          medico.CPF = medicoData[1];
          medico.FirstName = medicoData[2];
          medico.LastName = medicoData[3];
          medico.CRM = medicoData[4];

          DataSet.Medicos.Add(medico);

          line = sr.ReadLine();

        }
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Oops, algo deu errado ao tentar importar os dados.");
        Console.WriteLine(ex.Message);

        return false;
      }

    }

    public List<Medico> SearchByName(string name)
    {
      if (string.IsNullOrEmpty(name) ||
          string.IsNullOrWhiteSpace(name))
        return null;

      List<Medico> medicos = new List<Medico>();
      for (int i = 0; i < DataSet.Medicos.Count; i++)
      {
        var m = DataSet.Medicos[i];
        if (m.FullName.ToLower().Contains(name.ToLower()))
        {
          medicos.Add(m);
        }
      }

      return medicos;
    }
    public int GetNextId()
    {
      int tam = DataSet.Medicos.Count;

      if (tam > 0)
        return DataSet.Medicos[tam - 1].Id + 1;
      else
        return 1;

    }
  }
}