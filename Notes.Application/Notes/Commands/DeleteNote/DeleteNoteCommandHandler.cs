using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Common.Exeptions;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INotesDbContext _context;
    public DeleteNoteCommandHandler(INotesDbContext context) 
    {
        _context = context;
    }

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var item = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);
        if (item == null || item.UserId != request.UserId)
        {
            throw new NotFoundExeptions(nameof(Note), request.Id);
        }
        _context.Notes.Remove(item);
        _context.SaveChangeAsync(cancellationToken);
        
    }
}
