using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TutoringSystemAPI.Identity;
using TutoringSystemLib.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using TutoringSystemLib.Models;
using TutoringSystemAPI.Validators;
using TutoringSystemAPI.Repositories;
using FluentValidation.AspNetCore;

namespace TutoringSystemAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtOptions = new JwtOptions();
            Configuration.GetSection("jwt").Bind(jwtOptions);
            services.AddSingleton(jwtOptions);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptions.JwtIssuer,
                    ValidAudience = jwtOptions.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey))
                };
            });

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddControllers().AddFluentValidation();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidation>();
            services.AddScoped<IValidator<OrderDetailsDto>, OrderValidation>();
            services.AddScoped<IValidator<PasswordDto>, PasswordValidation>();

            services.AddDbContext<AppDbContext>();

            #region Repositories
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITutorRepository, TutorRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
            services.AddTransient<IIntervalRepository, IntervalRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            #endregion

            services.AddScoped<Seeder>();
            services.AddAutoMapper(GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            seeder.Seed();
        }
    }
}
