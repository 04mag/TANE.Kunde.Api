using System.ComponentModel.DataAnnotations;

namespace TANE.Kunde.Api.Model
{
    public class KundeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Fornavn { get; set; }
        [Required]
        [StringLength(50)]
        public string Efternavn { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;
        public KundeModel() { }
        public KundeModel(int id, string forNavn, string efterNavn, string email)
        {
            Id = id;
            Fornavn = forNavn;
            Efternavn = efterNavn;
            Email = email;
        }

    }
}
