using System.Threading.Tasks;

namespace GenShop.Invoicing.App.UseCases
{
    public interface ICommand
    {
        Task Execute();
    }

    public interface ICommand<T>
    {
        Task<T> Execute();
    }
}
