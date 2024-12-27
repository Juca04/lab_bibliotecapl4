using FluentAssertions.Common;
using lab_biblioteca.Data;
using lab_biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

        // Adiciona o contexto do banco de dados
        builder.Services.AddDbContext<lab_biblioteca.Data.BibliotecaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Configuração do Identity
        builder.Services.AddDefaultIdentity<Bibliotecario>(options =>
            options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<lab_biblioteca.Data.BibliotecaContext>();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        //app.UseHttpsRedirection();
        //app.UseStaticFiles();

        //app.UseRouting();

        //app.UseAuthentication();
        //app.UseAuthorization();

        //app.MapControllerRoute(
        //  name: "default",
        //pattern: "{controller=Home}/{action=Index}/{id?}");
        //app.MapRazorPages();

        //app.Run();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); // Adicionar autenticação
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}