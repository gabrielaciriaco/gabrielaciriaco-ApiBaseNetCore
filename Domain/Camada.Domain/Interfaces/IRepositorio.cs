using Camada.Domain.Entidades;
using System.Collections.Generic;

namespace Camada.Domain.Interfaces
{
    public interface IRepositorio
    {
        void Insert(ItemEntidade obj);

        void Update(ItemEntidade obj);

        void Remove(Int id);

        ItemEntidade Select(Int id);

        IList<ItemEntidade> SelectAll();

    }
}
