using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.EmailService;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.JobList.Commands
{
    public partial class UpdateJobItemCommand : IRequest
    {
        public long Id { get; set; }
        public string Status { get; set; }

        public class UpdateJobItemCommandHandler : IRequestHandler<UpdateJobItemCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IEmailSender _emailSender;
            public UpdateJobItemCommandHandler(IApplicationDbContext context,  IEmailSender emailSender)
            {
                _context = context;
                _emailSender = emailSender;
            }

            public async Task<Unit> Handle(UpdateJobItemCommand request, CancellationToken cancellationToken)
            {
                var job = await _context.Jobs.FindAsync(request.Id);

                if (job == null)
                {
                    throw new NotFoundException(nameof(JobItem), request.Id);
                }

                job.Status = request.Status;

                if (job.Price > 500 )
                {
                    job.Price = Convert.ToInt32(job.Price * 0.9);
                    var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test email async", "This is the content from our async email.", null);
                    await _emailSender.SendEmailAsync(message);
                }
                   
                job.UpdatedAt = DateTime.Now;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
