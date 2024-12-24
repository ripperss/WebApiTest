using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNotelist;

public  class GetNoteListValidation : AbstractValidator<GetNoteListQueries>
{
    public GetNoteListValidation()
    {
        RuleFor(getNote => getNote.UserId).Equal(Guid.Empty);
        RuleFor(getNote => getNote.Id).Equal(Guid.Empty);
    }
}
