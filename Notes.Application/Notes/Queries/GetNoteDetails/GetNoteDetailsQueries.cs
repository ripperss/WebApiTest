using MediatR;
using Notes.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueries : IRequest<NoteDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        
    }
}
