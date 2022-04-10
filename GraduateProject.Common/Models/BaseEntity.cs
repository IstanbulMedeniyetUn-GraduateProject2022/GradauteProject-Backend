
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduateProject.Common.Models
{
    //--------------------------------------------------------------------
    public class BaseEntity<T> : BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsDeleted = false;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

    }

    //--------------------------------------------------------------------
    public class BaseEntityNoIdentity<T> : BaseEntity
    {
        public BaseEntityNoIdentity()
        {
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsDeleted = false;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }

    }

    //--------------------------------------------------------------------
    public class BaseEntityTranslate<T> : BaseEntity<T>
    {
        public string LanguageId { get; set; }
    }

    //--------------------------------------------------------------------
    public interface IBaseEntity
    {
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false),Column(TypeName = "datetime2")]
        public DateTime LastModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime DeletionDate { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }

    //--------------------------------------------------------------------
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsDeleted = false;
        }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false),Column(TypeName = "datetime2")]
        public DateTime LastModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime DeletionDate { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; } = false;

    }

    //--------------------------------------------------------------------
    public class BaseEntityIdentityUser : IdentityUser, IBaseEntity
    {
        public BaseEntityIdentityUser()
        {
            CreationDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsDeleted = false;
            LastActivityDate = DateTime.Now;
        }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false),Column(TypeName = "datetime2")]
        public DateTime LastModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime DeletionDate { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastActivityDate { get; set; }

    }



}
