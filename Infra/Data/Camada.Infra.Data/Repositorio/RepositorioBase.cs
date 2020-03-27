using System;
using System.Collections.Generic;
using System.Text;
using Camada.Domain.Entidades;
using Camada.Domain.Interfaces;
using Camada.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Camada.Infraestrutura.Repositorio
{
    class RepositorioBase : IRepositorio
    {
        private MySqlContext context = new MySqlContext();

        public void Insert(ItemEntidade obj)
        {
            try
            {
                context.Set<ItemEntidade>().Add(obj);
                context.SaveChanges();
            }
            catch (Exception excecao)
            {
                throw new Exception("Falha ao inserir item no banco");
            }
        }
        public void Update(ItemEntidade obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                if (context.Item.Find(obj.Id) == null)
                    throw new DllNotFoundException("Não existe esse item no banco, exception:", exception);
                else
                    throw new Exception("Falha ao atualizar item no banco, exception:", exception);
            }

        }

        public void Remove(int id)
        {
            try
            {
                var todoItem = context.Item.Find(id);
                if(todoItem == null)
                {
                    throw new Exception("Não é possível remover o item pois o mesmo não existe");
                }
                else
                {
                    

                }
            }
            catch (Exception exception)
            {

            }
        }

        public ItemEntidade Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemEntidade> SelectAll()
        {
            throw new NotImplementedException();
        }

    }
}
