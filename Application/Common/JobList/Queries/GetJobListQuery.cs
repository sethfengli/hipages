using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.JobList.DTO;
using System.Collections.Generic;

namespace Application.JobList.Querieies
{
    public class GetJobListQuery : IRequest<IList<JobItemDTO>>
    {
        public string status;
        public class GetJobListQueryHandler : IRequestHandler<GetJobListQuery, IList<JobItemDTO>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
          
            public GetJobListQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<JobItemDTO>> Handle(GetJobListQuery request, CancellationToken cancellationToken)
            {
                var JobList = new List<JobItemDTO>();

                JobList = await _context.Jobs.Where(job => job.Status == request.status)
                    .ProjectTo<JobItemDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return JobList;
            }
        }
    }
}
