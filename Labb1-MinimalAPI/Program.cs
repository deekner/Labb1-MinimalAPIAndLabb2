using AutoMapper;
using FluentValidation;
using Labb1_MinimalAPI;
using Labb1_MinimalAPI.Data;
using Labb1_MinimalAPI.Models;
using Labb1_MinimalAPI.Models.DTOs;
using Labb1_MinimalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<IBookService, BookService>();

//Register BooksDBContext
builder.Services.AddDbContext<BooksDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapGet("/api/books", async (IBookService _bookservice) =>
{
    APIResponse response = new();
    response.Result = await _bookservice.GetAllBooks();
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.OK;
    return Results.Ok(response);

}).WithName("GetBooks").Produces<APIResponse>(200);



app.MapGet("/api/book/{id}", async (IBookService _bookservice, Guid Id) =>
{
    var book = await _bookservice.GetSingleBook(Id);
    if (book == null)
    {
        return Results.NotFound("Book not found");
    }
    return Results.Ok(book);
});



app.MapPost("/api/book/", async (IValidator<BookCreateDTO> _validator, IBookService _bookservice, IMapper _mapper, BookCreateDTO book_Create_DTO) =>
{
    APIResponse response = new() 
    { 
        IsSuccess = false, 
        StatusCode = HttpStatusCode.BadRequest 
    };

    var validationResult = await _validator.ValidateAsync(book_Create_DTO);
    if (!validationResult.IsValid)
    {
        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault().ToString());
        return Results.BadRequest(response);
    }


    Book book = _mapper.Map<Book>(book_Create_DTO);
    response.Result = await _bookservice.AddBook(book);
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.Created;
    return Results.Ok(response);

}).WithName("CreateBook").Accepts<BookCreateDTO>("application/json").Produces<APIResponse>(201).Produces(400);




app.MapPut("/api/book/", async (IValidator<BookUpdateDTO> _validator, IBookService _bookservice, IMapper _mapper, BookUpdateDTO UpdatedBook, Guid Id) =>
{
    APIResponse response = new()
    {
        IsSuccess = false,
        StatusCode = HttpStatusCode.BadRequest
    };

    var validationResult = await _validator.ValidateAsync(UpdatedBook);
    if (!validationResult.IsValid)
    {
        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault().ToString());
        return Results.BadRequest(response);
    }

    Book bookUpdate = await _bookservice.GetSingleBook(Id);

    bookUpdate.Title = UpdatedBook.Title;
    bookUpdate.Author = UpdatedBook.Author;
    bookUpdate.Year = UpdatedBook.Year;
    bookUpdate.Description = UpdatedBook.Description;
    bookUpdate.isAvailable = UpdatedBook.isAvailable;

    response.Result = await _bookservice.UpdateBook(bookUpdate);
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.Created;
    return Results.Ok(response);
}).WithName("UpdateBook").Accepts<BookUpdateDTO>("application/json").Produces<APIResponse>(200).Produces(400);

//app.MapPut("/api/book/{id}", async (IMapper _mapper, BooksDbContext context, BookUpdateDTO UpdatedBook, Guid Id) =>
//{
//    var book = await context.books.FindAsync(Id);
//    if (book == null)
//    {
//        return Results.NotFound("Book not found");
//    }

//    Book bookUpdate = await context.books.FindAsync(Id);
//    bookUpdate.Title = UpdatedBook.Title;
//    bookUpdate.isAvailable = UpdatedBook.isAvailable;
//    await context.SaveChangesAsync();
//    return Results.Ok(await context.books.ToListAsync());
//});//another App.MapPost



app.MapDelete("/api/book/{id}", async (IBookService bookservice, Guid Id) =>
{
    APIResponse response = new()
    {
        IsSuccess = false,
        StatusCode = HttpStatusCode.BadRequest
    };

    var book = await bookservice.GetSingleBook(Id);

    if(book == null)
    {
        return Results.NotFound("Cannot find book because It's not in the database");

    }

    response.Result = await bookservice.DeleteBook(book.Id);
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.NotFound;
    return Results.Ok(response);
});

app.Run();


