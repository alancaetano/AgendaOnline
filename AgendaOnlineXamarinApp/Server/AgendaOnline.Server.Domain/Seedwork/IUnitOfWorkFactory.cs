namespace AgendaOnline.Server.Domain.Seedwork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}