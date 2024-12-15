using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNotelist
{
    public class GetNoteListQueries : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
            
    }
}
