using System.Reflection.Metadata;
using MicroserviziGr02.Model;

using MicroserviziGr02.Service;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Dependeny Injection



app.MapPost("/InsertUser", (User user) =>
{
    var data = new UserDb();
    data.CreateUser(user);
})
.WithName("afaf")
.WithOpenApi();


app.MapGet("/GetUsersPost/{id}", (int id) =>    // id deve essere uguale anche a quello dentro le graffe
{
    var data = new UserDb();
   var posts= data.GetUserPost(id);
    return posts;
}).WithName("GetProductById")
  .WithOpenApi();

app.MapPost("/InsertPost", (Post post) =>
{
    var data = new PostDb();
    data.CreatePost(post);
})
.WithOpenApi();


app.MapGet("/GetOrderPost", () =>
{
    var data = new PostDb();
   var orderedpost= data.GetListAsync();
    return orderedpost;
}).WithOpenApi();


app.MapPost("/InsertLike", (Likes likes) =>
{
    var data = new PostDb();
    data.LikesPost(likes);
})
.WithOpenApi();
app.MapPost("/Follow", (Follow follow) =>
{
    var data = new UserDb();
    data.Following(follow);
})
.WithOpenApi();

//app.MapGet("/GetUserLikedPost/{id}", (int id) =>    // id deve essere uguale anche a quello dentro le graffe
//{
//    var data = new UserDb();
//    var posts = data.GetUserPost(id);
//    return posts;
//}).WithName("GetProductById")
//  .WithOpenApi();

app.MapPost("/Category", (string CategoryName) =>
{
    var data = new PostDb();
    data.InsertCategory(CategoryName);
})
.WithOpenApi();

app.Run();
