using System;
using System.Collections.Generic;
using System.Text;
using Camada.Domain.Entidades;
using Camada.Domain.Interfaces;
using Camada.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;
using Camada.Domain.Enum;

namespace Camada.Infraestrutura.Repositorio
{
    class RepositorioBase : IRepositorio
    {
        private MySqlContext context = new MySqlContext();

        public RetornoPadrao Insert(ItemEntidade obj)
        {
            try
            {
                context.Add(obj);
                context.Set<ItemEntidade>().Add(obj);
                context.SaveChanges();

                return new RetornoPadrao()
                {
                    IdObjeto = obj.Id,
                    Resultado = EstadoResultado.OK
                };
            }
            catch (Exception exception)
            {
                throw new Exception($"Falha ao inserir item no banco, exception: {exception}");
            }
        }
        public RetornoPadrao Update(ItemEntidade obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();

                return new RetornoPadrao()
                {
                    IdObjeto = obj.Id,
                    Resultado = EstadoResultado.OK
                };
            }
            catch (Exception exception)
            {
                var todoItem = context.Item.Find(obj.Id);
                if (todoItem == null)
                    throw new Exception($"Não existe esse item no banco, exception: {exception}");
                else
                    throw new Exception($"Falha ao atualizar item no banco, exception: {exception}");
            }
        }
        public RetornoPadrao Remove(int id)
        {
            try
            {
                var todoItem = context.Item.Find(id);
                if (todoItem == null)
                    throw new Exception("Não é possível remover o item pois o mesmo não existe");
                else
                {
                    context.Item.Remove(todoItem);
                    context.SaveChanges();
                    return new RetornoPadrao()
                    {
                        IdObjeto = todoItem.Id,
                        Resultado = EstadoResultado.OK
                    };
                }

            }
            catch (Exception exception)
            {
                throw new Exception($"Não é possível remover item do banco, exception: {exception}");
            }
        }

        public ItemEntidade Select(int id)
        {
            try
            {
                var todoitem = context.Item.Find(id);
                if (todoitem == null)
                    throw new Exception("Não é possível selecionar o item pois o mesmo não existe");
                return new RItemEntidade()
                {
                    Id = todoitem.Id,
                    Nome = todoitem.Nome,
                    EstaCompleto = todoitem.EstaCompleto
                };
            }
            catch (Exception exception)
            {
                throw new Exception($"Não é possível selecionar este item, exception: {exception}");
            }
        }

    }
}
