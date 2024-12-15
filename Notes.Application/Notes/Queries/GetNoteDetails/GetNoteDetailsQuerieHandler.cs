using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Common.Exeptions;
using System.Reflection.Metadata;
using Notes.Domain;
namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQuerieHandler : IRequestHandler<GetNoteDetailsQueries, NoteDetailsVm>
{

    private readonly INotesDbContext _dvContext;
    private readonly IMapper _mapper;
    public GetNoteDetailsQuerieHandler(INotesDbContext notesDbContext, IMapper mapper)
    {
        _dvContext
            = notesDbContext;
        _mapper = mapper;
    }

    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQueries request, CancellationToken cancellationToken)
    {
        var entity = await _dvContext.Notes
            .FirstOrDefaultAsync(note =>  note.Id == request.Id,cancellationToken) ;
        if (entity == null || request.UserId != entity.UserId)
        {
            throw new NotFoundExeptions(nameof(Note), request.Id);
        }
        return _mapper.Map<NoteDetailsVm>(entity);

    }
}
