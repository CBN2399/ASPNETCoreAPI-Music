#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiProyect.Models
{
    [Table("AspNetUsers")]
    public partial class AppUser : IdentityUser
    {
        public string nombre { get; set; }

        public string apellidos { get; set; }

        public int CodPostal { get; set; }

        [SwaggerSchema(ReadOnly =true)]
        public IList<string> Roles { get; set; }
    }
}
