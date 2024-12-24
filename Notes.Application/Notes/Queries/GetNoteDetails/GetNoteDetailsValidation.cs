using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsValidation : AbstractValidator<GetNoteDetailsQueries>
{
    GetNoteDetailsValidation()
    {
        RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        RuleFor(note => note.Id).NotEqual(Guid.Empty);
    }
}
