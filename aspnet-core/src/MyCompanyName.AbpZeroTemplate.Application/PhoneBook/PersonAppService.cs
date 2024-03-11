using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using MyCompanyName.AbpZeroTemplate.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook
{
    public class PersonAppService : AbpZeroTemplateAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var people = _personRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                         p.Surname.Contains(input.Filter) ||
                         p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(people));
        }

        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

    }

}
