
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestThiBackEnd;
using TestThiBackEnd.Models;
using TestThiBackEnd.Repository;

var builder = WebApplication.CreateBuilder(args);

// --- PHẦN 1: ĐĂNG KÝ DỊCH VỤ (Phải làm TRƯỚC Build) ---

// 1. Thêm Controllers (Bắt buộc cho API)
builder.Services.AddControllers();

// 2. Đăng ký DbContext (Đưa lên trên Build)
// --- BỔ SUNG DÒNG NÀY ---
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
// ------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// 3. Cấu hình JWT (Giữ nguyên code của bạn)
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();

// --- PHẦN 2: BUILD APP ---
var app = builder.Build();

// --- PHẦN 3: CẤU HÌNH PIPELINE ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication phải đặt trước Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map Controllers để API hoạt động
app.MapControllers();

app.Run();