using GenShop.Invoicing.Contract;
using System.Threading.Tasks;

namespace GenShop.Invoicing.App.UseCases
{
    public interface ICommand
    {
        Task Execute();
    }

    public interface ICommand<Tout>
    {
        Task<Tout> Execute();
    }

    public interface ICommand<Tin, Tout>
        where Tin : IRequest
    {
        Task<Tout> Execute(Tin request);
    }
}
