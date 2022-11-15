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

        public string clave { get; set; }

        [SwaggerSchema(ReadOnly =true)]
        public IList<string> Roles { get; set; }

       /* [SwaggerSchema(ReadOnly = true)]
        public override string UserName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override string NormalizedUserName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override string NormalizedEmail { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override bool EmailConfirmed { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override string PasswordHash { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override string SecurityStamp { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        [SwaggerSchema(ReadOnly = true)]
        public override string PhoneNumber { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override bool PhoneNumberConfirmed { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override bool TwoFactorEnabled { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override bool LockoutEnabled { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public override int AccessFailedCount { get; set; }*/

    }
}
