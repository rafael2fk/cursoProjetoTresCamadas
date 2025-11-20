
namespace Course.Business.Models
{
    public class Fornecedor : Entity
    {
        public string? Name { get; set; }

        public string? Documento { get; set; }

        public TipoFornecedor TipoFornecedor { get; set; }

        public bool Ativo { get; set; }

        public Endreco? Endreco { get; set; }
    }
}
