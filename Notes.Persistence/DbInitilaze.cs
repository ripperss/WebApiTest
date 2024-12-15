using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence;

public class DbInitilaze
{
    public static void Initialize(NoteDbontext dbontext)
    {
        dbontext.Database.EnsureCreated();
    }
}
