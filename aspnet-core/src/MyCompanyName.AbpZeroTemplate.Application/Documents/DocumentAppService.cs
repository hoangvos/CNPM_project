using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Internal;
using MyCompanyName.AbpZeroTemplate.Documents.Dto;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Documents
{
    public class DocumentAppService: AbpZeroTemplateAppServiceBase, IDocumentAppServive
    {
        private readonly IRepository<Document> _DocumentRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public DocumentAppService(IRepository<Document> DocumentRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _DocumentRepository = DocumentRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public ListResultDto<DocumentListDto> GetDocuments(GetDocumentsInput input)
        {
            var documents = _DocumentRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Title.Contains(input.Filter) ||
                         p.Code.Contains(input.Filter) ||
                         p.Organization.Contains(input.Filter) ||
                         p.Type.Contains(input.Filter)

                )
                .OrderBy(p => p.Title)
                .ThenBy(p => p.Code)
                .ToList();

            return new ListResultDto<DocumentListDto>(ObjectMapper.Map<List<DocumentListDto>>(documents));
        }
        public async Task CreateDocuments(DocumentListDto input)
        {
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                await _DocumentRepository.InsertAsync(new Document
                {
                    Title = input.Title,
                    ReleaseDate = DateTime.UtcNow,
                    Organization = "HCMUT",
                    EffectiveDate = input.EffectiveDate,
                    ExpirationDate = input.ExpirationDate,
                    Type = input.Type,
                    Code = input.Code,
                });
                await CurrentUnitOfWork.SaveChangesAsync();
                unitOfWork.Complete();
            }
        }
    }
}
