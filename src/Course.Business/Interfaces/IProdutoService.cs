using Course.Business.Models;

namespace Course.Business.Interfaces
{
    public interface IProdutoService 
    {
        Task Adicionar(Produto produto);

        Task Atualizar(Produto produto);

        Task Remover(Guid Id);
    }
}
