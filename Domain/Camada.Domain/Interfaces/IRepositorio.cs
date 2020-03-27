using Camada.Domain.Entidades;
using System.Collections.Generic;

namespace Camada.Domain.Interfaces
{
    public interface IRepositorio
    {
        RetornoPadrao Insert(ItemEntidade obj);

        RetornoPadrao Update(ItemEntidade obj);

        RetornoPadrao Remove(int id);

        ItemEntidade Select(int id);

    }
}
