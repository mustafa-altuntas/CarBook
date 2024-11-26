using CarBook.Aplication.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Aplication.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Aplication.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Aplication.Features.CQRS.Handlers.CarHandlers;
using CarBook.Aplication.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Aplication.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Aplication.Features.RepositoryPattern;
using CarBook.Aplication.Interfaces;
using CarBook.Aplication.Interfaces.AppUserInterfaces;
using CarBook.Aplication.Interfaces.BlogInterfaces;
using CarBook.Aplication.Interfaces.CarDescriptionInterfaces;
using CarBook.Aplication.Interfaces.CarFeatureInterfaces;
using CarBook.Aplication.Interfaces.CarInterfaces;
using CarBook.Aplication.Interfaces.CarPricingInterfaces;
using CarBook.Aplication.Interfaces.RentACarInterfaces;
using CarBook.Aplication.Interfaces.ReviewInterfaces;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using CarBook.Aplication.Interfaces.TagCloudBlogInterfaces;
using CarBook.Aplication.Services;
using CarBook.Aplication.Tools;
using CarBook.Aplication.Validators.ReviewValidators;
using CarBook.Domain;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.AppUserRepositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Persistence.Repositories.StatisticRepositories;
using CarBook.Persistence.Repositories.TagCloudBlogRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CarbookCorsPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; //HttpS kullanýlsýnmý
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience, // dinleyici, izleyici
        ValidIssuer = JwtTokenDefaults.ValidIssuer,  // yayýncý
        ClockSkew = TimeSpan.Zero, // token baþlangýç zamanýný sýfýrlar
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});






// Add services to the container.

builder.Services.AddDbContext<CarBookContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudBlogRepository), typeof(TagCloudBlogRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository),typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository),typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository),typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IAppUserRepository),typeof(AppUserRepository));


builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();


builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();

builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();


builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWhithBrandsQueryHandler>();


builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();


builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.AddServiceRegistiration(builder.Configuration);



builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();


builder.Services.AddControllers();
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


app.UseCors("CarbookCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
