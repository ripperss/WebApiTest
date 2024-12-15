using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNotelist
{
    public class GetNoteListQueriesHandler : IRequestHandler<GetNoteListQueries, NoteListVm>
    {
        private readonly INotesDbContext notesDbContext;
        private readonly IMapper mapper;
        public GetNoteListQueriesHandler(INotesDbContext notesDbContext, IMapper mapper)
        {
            this.notesDbContext = notesDbContext;
            this.mapper = mapper;

        }
        public async Task<NoteListVm> Handle(GetNoteListQueries request, CancellationToken cancellationToken)
        {
            var noteQuerie = await notesDbContext.Notes
                .Where(notes => notes.UserId == request.UserId)
                .ProjectTo<NoteLookUpDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new NoteListVm { Notes = noteQuerie };
        }
    }
}
