
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System.Reflection;

namespace SignalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Apinin test k�sm�
            //Registration
            builder.Services.AddDbContext<SignalRContext>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDAL, EfAboutDal>();

            builder.Services.AddScoped<IBookingService, BookingManager>();
            builder.Services.AddScoped<IBookingDAL, EfBookingDal>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDAL, EfCategoryDal>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDAL, EfContactDal>();

            builder.Services.AddScoped<IDiscountService, DiscountManager>();
            builder.Services.AddScoped<IDiscountDAL, EfDiscountDal>();


            builder.Services.AddScoped<IFeatureService, FeatureManager>();
            builder.Services.AddScoped<IFeatureDAL, EfFeatureDal>();


            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDAL, EfProductDal>();


            builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
            builder.Services.AddScoped<ISocialMediaDAL, EfSocialMediaDal>();


            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<ITestimonialDAL, EfTestimonialDal>();


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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
