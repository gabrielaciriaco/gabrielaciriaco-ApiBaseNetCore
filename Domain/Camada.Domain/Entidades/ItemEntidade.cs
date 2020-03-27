namespace Camada.Domain.Entidades
{
    public abstract class ItemEntidade : BaseEntity
    {
        public override int Id { get; set; }
        public string EstaCompleto { get; set; }
        public string Nome { get; set; }
    }
}
