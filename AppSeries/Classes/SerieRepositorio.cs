using System;
using System.Collections;
using System.Collections.Generic;
using AppSeries.Interfaces;

namespace AppSeries
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();

    public void Atualiza(int id, Serie objeto)
    {
      listaSerie[id] = objeto;
    }

    public void Excluir(int id)
    {
      listaSerie[id].Excluir();
      // implemento uma ação de acordo com regra de negócio.
    }

    public void Insere(Serie objeto)
    {
      listaSerie.Add(objeto);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }

    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Serie RetornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}