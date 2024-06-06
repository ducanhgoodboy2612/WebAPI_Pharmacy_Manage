using BBL.Interfaces;
using BBL;

using DAL.Helper.Interfaces;
using DAL.Helper;
using DAL.Interfaces;
using DAL;

using Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Code;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerBusiness, CustomerBusiness>();

builder.Services.AddTransient<IEmailBusiness, EmailBusiness>();

builder.Services.AddTransient<IPromotionRepository, PromotionRepository>();
builder.Services.AddTransient<IPromotionBusiness, PromotionBusiness>();


builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<IBrandBusiness, BrandBusiness>();

builder.Services.AddTransient<IUserAcc_Repository, UserAcc_Repository>();
builder.Services.AddTransient<IUserAcc_Business, UserAcc_Business>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRespository>();
builder.Services.AddTransient<IEmpBusiness, EmpBusiness>();

builder.Services.AddTransient<ICateRepository, CateRepository>();
builder.Services.AddTransient<ICateBusiness, CateBusiness>();

builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<ISupplierBusiness, SupplierBusiness>();

builder.Services.AddTransient<I_InvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<I_InvoiceBusiness, InvoiceBusiness>();

builder.Services.AddTransient<IProd_ImageRepository, Prod_ImageRepository>();
builder.Services.AddTransient<IProd_ImageBusiness, Prod_ImageBusiness>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();
builder.Services.AddTransient<IReportBusiness, ReportBusiness>();
builder.Services.AddTransient<I_ImpInvoiceRepository, ImpInvoiceRepository>();
builder.Services.AddTransient<I_ImpInvoiceBusiness, ImpInvoiceBusiness>();
builder.Services.AddTransient<ITools, Tools>();


builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailRepository, EmailRepository>();






// configure strongly typed settings objects
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.
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
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();