#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Swashbuckle.AspNetCore.Annotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace ApiProyect.Models
{
    [Table("AspNetUsers")]
    public partial class AppUser : IdentityUser
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        [Required]
        [MinLength(5)]

        public int PostalCode { get; set; }

        public string clave { get; set; }

     
        public IList<string> Roles { get; set; }

     

    }
}
