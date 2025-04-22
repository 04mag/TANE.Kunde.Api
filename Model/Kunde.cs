using System.ComponentModel.DataAnnotations;

namespace TANE.Kunde.Api.Model
{
    public class Kunde
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

        public Kunde() { }
        public Kunde(int id, string forNavn, string efterNavn, string email)
        {
            Id = id;
            Fornavn = forNavn;
            Efternavn = efterNavn;
            Email = email;
        }

    }
}
