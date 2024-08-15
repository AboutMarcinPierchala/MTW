namespace MTW.UseCases.Inventories.Interfaces
{
    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(int id);
    }
}