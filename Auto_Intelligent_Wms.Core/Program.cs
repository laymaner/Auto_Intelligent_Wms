using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Config;
using Auto_Intelligent_Wms.Core.Extensions.Filter;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Mask_STK.Core.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Auto_Intelligent_Wms �ӿ��ĵ�",
        Version = "version 1.0",
        Description = "�ӿ��ĵ�"
    });
    var file = Path.Combine(AppContext.BaseDirectory, "Auto_Intelligent_Wms.Core.WebApi.xml");  // xml�ĵ�����·��
    var path = Path.Combine(AppContext.BaseDirectory, file); // xml�ĵ�����·��
    c.IncludeXmlComments(path, true); // true : ��ʾ��������ע��
    c.OrderActionsBy(o => o.RelativePath); // ��action�����ƽ�����������ж�����Ϳ��Կ���Ч���ˡ�
});

builder.Services.AddMemoryCache();//�ڴ滺��

builder.Services.AddLogging(LogBuilder =>
{
    LogBuilder.AddNLog("nlog.config");
});



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //builder.RegisterModule<AutofacModule>();
    var assemblies = Assembly.GetExecutingAssembly();
    builder.RegisterAssemblyTypes(assemblies)//���������о����� 
    .Where(c => c.Name.EndsWith("Service"))
    .PublicOnly()//ֻҪpublic����Ȩ�޵�
    .Where(cc => cc.IsClass)//ֻҪclass�ͣ���ҪΪ���ų�ֵ��interface���ͣ� 
    .AsImplementedInterfaces();

    //������ʵ��������Զ�ע�ᵽ����
    var service = Assembly.Load("Auto_Intelligent_Wms.Core.Services");

    builder.RegisterAssemblyTypes(service)//���������о����� 
   .Where(c => c.Name.EndsWith("Service"))
   .PublicOnly()//ֻҪpublic����Ȩ�޵�
   .Where(cc => cc.IsClass)//ֻҪclass�ͣ���ҪΪ���ų�ֵ��interface���ͣ� 
   .AsImplementedInterfaces();
});


builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));

builder.Services.Configure<MvcOptions>(opt =>
{
    //opt.Filters.Add<NotLoginFilter>();
    opt.Filters.Add<TransationScopeFilter>();
    opt.Filters.Add<RateLimitFilter>();
    opt.Filters.Add<RequestFilter>();
});

builder.Services.AddDbContext<Auto_Inteligent_Wms_DbContext>(option => {

    /*    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.Development.json", true, true);
        IConfigurationRoot configurationRoot = configurationBuilder.Build();
        string conn = configurationRoot.GetSection("ConnectionStrings:conn").Value;*/

    string conn = builder.Configuration.GetSection("ConnectionStrings:conn").Value;

    option.UseSqlServer(conn);
    //�������� ���� ɾ������
    option.UseBatchEF_MSSQL();

    //������ ����־
    /*   option.LogTo(msg =>
       {
           Console.WriteLine(msg);
       });*/
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(x =>
{
    var jwtOpt = builder.Configuration.GetSection("JWT").Get<JWTOptions>();
    byte[] keyBytes = Encoding.UTF8.GetBytes(jwtOpt.SigningKey);
    var secKey = new SymmetricSecurityKey(keyBytes);
    x.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secKey
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // ����SwaggerĬ�ϲ�չ���ӿڶ���
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}
//�׳��쳣����������� �쳣��־д��log�ļ�
//app.UseMiddleware<ExceptionHandlingMiddleWare>();
app.UseHttpsRedirection();
app.UseAuthentication();//�û���¼��֤ ������app.UseAuthorization()ǰע��
app.UseAuthorization();//�û���ɫȨ����֤

app.MapControllers();

app.Run();
