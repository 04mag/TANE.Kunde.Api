using TANE.Kunde.Api.Model;

namespace TANE.Kunde.Api.REPO.Interface
{
    public interface IKundeREPO
    {
        Task<List<KundeModel>> GetAllKunderAsync();
        Task<KundeModel> GetKundeByIdAsync(int id);
        Task AddKundeAsync(KundeModel kunde);
        Task UpdateKundeAsync(KundeModel kunde);
        Task DeleteKundeAsync(int id);
    }
}
