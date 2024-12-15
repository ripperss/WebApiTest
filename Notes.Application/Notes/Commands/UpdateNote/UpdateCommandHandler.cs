using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exeptions;
using Notes.Application.interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateCommandHandler : IRequestHandler<UpdateNote>
{
    private readonly INotesDbContext _dbContext;
    public UpdateCommandHandler(INotesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateNote request, CancellationToken cancellationToken)
    {
        var entity = 
            await _dbContext.Notes
            .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundExeptions(nameof(Note), request.Id);
        }
        entity.Details = request.Details;
        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangeAsync(cancellationToken);


    }
}
