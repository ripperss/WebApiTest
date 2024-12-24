using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidation : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidation() 
        {
            RuleFor(delteNote => delteNote.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteNote => deleteNote.Id).NotEqual(Guid.Empty);
        }
    }
}
