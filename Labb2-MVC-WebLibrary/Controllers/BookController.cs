using Labb1_MinimalAPI.Models.DTOs;
using Labb2_MVC_WebLibrary.Models;
using Labb2_MVC_WebLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace Labb2_MVC_WebLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        public async Task<IActionResult> BookIndex()
        {
            List<BookDTO> list = new List<BookDTO>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            BookDTO bookDTO = new BookDTO();
            var response = await _bookService.GetSingleBook<ResponseDTO>(Id);
            if (response != null && response.isSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        public async Task<IActionResult> BookCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookCreateDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if (response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }               
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBook(Guid bookId)
        {
            var response = await _bookService.GetSingleBook<ResponseDTO>(bookId);
            if (response != null && response.isSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);
                if(response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            var response = await _bookService.GetSingleBook<ResponseDTO>(Id);
            if(response != null && response.isSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.Id);
                if(response != null && response.isSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return NotFound();
        }



    }
}
