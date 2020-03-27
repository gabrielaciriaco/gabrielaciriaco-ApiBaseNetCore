using Camada.Domain.Entidades;
using Camada.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camada.Service.Services
{
    public class ServiceBase
    {
        private readonly IRepositorio repositorioBase;

        public ServiceBase(IRepositorio repositorioBase)
        {
            this.repositorioBase = repositorioBase;
        }

        public RetornoPadrao ExecutarInsert(ItemEntidade obj)
        {
            ValidarRequisicao(obj);
            return repositorioBase.Insert(obj);
        }

        public RetornoPadrao ExecutarUpdate(ItemEntidade obj)
        {
            ValidarRequisicao(obj);
            return repositorioBase.Update(obj);
        }
        public RetornoPadrao ExecutarRemove(int id)
        {
            ValidarRequisicao(id);
            return repositorioBase.Remove(id);
        }

        public ItemEntidade ExecutarSelect(int id)
        {
            ValidarRequisicao(id);
            return repositorioBase.Select(id);
        }

        public void ValidarRequisicao(ItemEntidade obj)
        {
            if(obj == null)
            {
                throw new NullReferenceException("Registro não identificado");
            }

        }

        public void ValidarRequisicao(int id)
        {
            if (repositorioBase.Select(id) == null)
            {
                throw new NullReferenceException("Item não existente");
            }
        }
    }
}
