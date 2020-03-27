namespace Camada.Domain.Entidades
{
    public abstract class ItemEntidade : BaseEntity
    {
        public int Id { get; set; }
        public string EstaCompleto { get; set; }
        public string Nome { get; set; }
    }
}
