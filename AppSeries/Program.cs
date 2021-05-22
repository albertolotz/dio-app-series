using System;

namespace AppSeries
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por Utilizar");
      Console.ReadLine();
    }
    private static void VisualizarSerie()
    {
      int indiceSerie = ObterIdSerie();

      Console.WriteLine();

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.Write(serie);

      Console.WriteLine();

    }
    private static void ExcluirSerie()
    {
      int indiceSerie = ObterIdSerie();

      repositorio.Excluir(indiceSerie);

      Console.WriteLine();

      Console.WriteLine("********* Série Excluída *********");
    }
    private static void AtualizarSerie()
    {

      int indiceSerie = ObterIdSerie();

      String[] dadosSerie = ObterDadosSerie();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                                  genero: (Genero)int.Parse(dadosSerie[0]),
                                  titulo: dadosSerie[1],
                                  ano: int.Parse(dadosSerie[2]),
                                  descricao: dadosSerie[3]
                                  );

      repositorio.Atualiza(indiceSerie, atualizaSerie);
      Console.WriteLine();

      Console.WriteLine("********* Série Atualizada *********");
    }


    private static void ListarSeries()
    {
      Console.WriteLine("Listar séries");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma Série Cadastrada!");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir séries");

      String[] dadosSerie = ObterDadosSerie();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)int.Parse(dadosSerie[0]),
                                  titulo: dadosSerie[1],
                                  ano: int.Parse(dadosSerie[2]),
                                  descricao: dadosSerie[3]
                                  );

      Console.WriteLine();
      repositorio.Insere(novaSerie);

      Console.WriteLine("********* Série Inserida *********");

    }


    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();

      Console.WriteLine("LotzFlix a seu dispor!!!");

      Console.WriteLine();

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      Console.Write("Informe a opção desejada: ");
      string opcaoUsuario = Console.ReadLine().ToUpper();

      Console.WriteLine();
      return opcaoUsuario;
    }

    private static String[] ObterDadosSerie()
    {

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine();

      Console.Write("Digite o Gênero de acordo com opções acima: ");
      string entradaGenero = Console.ReadLine();

      Console.Write("Digite o Titulo da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano da Série: ");
      string entradaAno = Console.ReadLine();

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();



      int n;

      if (!Int32.TryParse(entradaGenero, out n))
      {
        Console.WriteLine("Genero não é um numero");
        throw new InvalidCastException();
      }

      if (!Int32.TryParse(entradaAno, out n))
      {
        Console.WriteLine("Ano não é um numero");
        throw new InvalidCastException();
      }

      String[] dadosSerie = { entradaGenero, entradaTitulo, entradaAno, entradaDescricao };


      return dadosSerie;
    }

    private static int ObterIdSerie()
    {
      Console.Write("Digite o ID de uma Série: ");
      return int.Parse(Console.ReadLine());
    }
  }
}
