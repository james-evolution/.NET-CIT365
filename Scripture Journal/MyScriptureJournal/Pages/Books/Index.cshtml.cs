using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NoteString { get; set; }


        public async Task OnGetAsync()
        {
            var books = from b in _context.Book
                         select b;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.BookName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(NoteString))
            {
                books = books.Where(s => s.Note.Contains(NoteString));
            }

            Book = await books.ToListAsync();
        }
    }
}
