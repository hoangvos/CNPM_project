using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MyCompanyName.AbpZeroTemplate.PhoneBook.Dto;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);

    }
}
