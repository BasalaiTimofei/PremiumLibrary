using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PremiumLibrary.Context;
using Microsoft.EntityFrameworkCore;
using PremiumLibrary.Interfaces.Repositories;
using PremiumLibrary.Interfaces.Services;
using PremiumLibrary.Mapping;
using PremiumLibrary.Repositories;
using PremiumLibrary.Services;

namespace PremiumLibrary
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("PremiumLibrary");
            services.AddDbContext<ApplicationContext>(options => 
                options.UseLazyLoadingProxies()
                    .UseSqlServer(connection));

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IDependencyRepository, DependencyRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAutoFillRepository, AutoFillRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IDependencyService, DependencyService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ILikeService, LikeService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAutoFillService, AutoFillService>();
            services.AddAutoMapper(
                typeof(AuthorCommentProfile),
                typeof(AuthorProfile),
                typeof(BookCommentProfile),
                typeof(BookProfile),
                typeof(GenreProfile),
                typeof(RoleProfile),
                typeof(UserProfile));

            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}