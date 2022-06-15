using WebApi.Domain;
using WebApi.Dto;
using WebApi.Infrastructure;
using WebApi.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IApplicationContext, ApplicationContext>();
builder.Services.AddSingleton<IClinicReader, ClinicReader>();
builder.Services.AddSingleton<IPatientReader, PatientReader>();
builder.Services.AddSingleton<IFileReader, FileReader>();
builder.Services.AddSingleton<ICsvMapper<Clinic>, ClinicMapper>();
builder.Services.AddSingleton<ICsvMapper<Patient>, PatientMapper>();
builder.Services.AddSingleton<IMapper<Patient, PatientDto>, PatientDtoMapper>();
builder.Services.AddSingleton<IMapper<Clinic, ClinicDto>, ClinicDtoMapper>();
builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();