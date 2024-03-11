using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook
{
    [Table("PbPersons")]
    public class Person : FullAuditedEntity
    {
        public const int MaxNameLength = PersonConsts.MaxNameLength;
        public const int MaxSurnameLength = PersonConsts.MaxSurnameLength;
        public const int MaxEmailAddressLength = PersonConsts.MaxEmailAddressLength;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [MaxLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }
    }
}
