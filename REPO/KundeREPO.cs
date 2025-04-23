using Microsoft.EntityFrameworkCore;
using TANE.Kunde.Api.Context;
using TANE.Kunde.Api.Model;
using TANE.Kunde.Api.REPO.Interface;


namespace TANE.Kunde.Api.REPO
{
    public class KundeREPO : IKundeREPO
    {
        private readonly KundeDbContext _context;
        public KundeREPO(KundeDbContext context)
        {
            _context = context;
        }
        public async Task<List<KundeModel>> GetAllKunderAsync()
        {
            return await _context.Kunder.ToListAsync();
        }
        public async Task<KundeModel> GetKundeByIdAsync(int id)
        {
            return await _context.Kunder.FindAsync(id);
        }
        public async Task<KundeModel> AddKundeAsync(KundeModel kunde)
        {
            var resultat = await _context.Kunder.AddAsync(kunde);
            await _context.SaveChangesAsync();
            return resultat.Entity;
        }
        public async Task<KundeModel> UpdateKundeAsync(KundeModel kunde)
        {
            try
            {
                var resulat = _context.Kunder.Update(kunde);
                await _context.SaveChangesAsync();
                return resulat.Entity; 

            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Kunden blev ændret af en anden, genlæs siden og prøv igen.");
            }
        }

        public async Task<bool> DeleteKundeAsync(int id)
        {
            var kunde = await GetKundeByIdAsync(id);
            if (kunde != null)
            {
                _context.Kunder.Remove(kunde);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
