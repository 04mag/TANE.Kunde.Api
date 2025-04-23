using TANE.Kunde.Api.Model;

namespace TANE.Kunde.Api.REPO.Interface
{
    public interface IKundeREPO
    {
        Task<List<KundeModel>> GetAllKunderAsync();
        Task<KundeModel> GetKundeByIdAsync(int id);
        Task<KundeModel> AddKundeAsync(KundeModel kunde);
        Task<KundeModel> UpdateKundeAsync(KundeModel kunde);
        Task<bool> DeleteKundeAsync(int id);
    }
}
