using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace ApiProyect.Models
{
    [Table("AspNetUsers")]
    public partial class AppUser : IdentityUser
    {
        public string? nombre { get; set; }

        public string? apellidos { get; set; }

        public int CodPostal { get; set; }

       // public List<IdentityRole>? Roles { get; set; }
    }
}
