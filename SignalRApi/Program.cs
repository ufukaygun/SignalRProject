
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalRApi.Hubs;
using System.Reflection;
using AutoMapper;

namespace SignalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Cors metdonu çaðýrdýk.
            builder.Services.AddCors(opt =>
            {
                //Cors politikasý ekledik
                opt.AddPolicy("CorsPolicy", builder => //Anonim bir deðer ekledik builder
                {
                    //Kaynaklara izin verildi
                    builder.AllowAnyHeader() //Herhangi bir baþlýða izin ver
                    .AllowAnyMethod() //gelen herhangi bir metoda izin ver
                    .SetIsOriginAllowed((host) => true) //Gelen herhangi bir kaynaða izin ver
                    .AllowCredentials(); //Gelen herhangi bir kimliðe izin ver
                });
            
            });
            builder.Services.AddSignalR(); //SignalR kütüphanesinide eklemiþ olduk.

            //Apinin test kýsmý
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

            builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
            builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

            builder.Services.AddScoped<IOrderService, OrderManager>();
            builder.Services.AddScoped<IOrderDal, EfOrderDal>();

            builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

            builder.Services.AddScoped<IMenuTableService, MenuTableManager>();
            builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();

            builder.Services.AddScoped<ISliderService, SliderManager>();
            builder.Services.AddScoped<ISliderDAL, EfSliderDal>();

            builder.Services.AddScoped<IBasketService, BasketManager>();
            builder.Services.AddScoped<IBasketDal, EfBasketDal>();


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

            app.UseCors("CorsPolicy"); //Yukarýdaki tanýmladýðýmýz keyi burada çaðýrdýk.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

			//Cors yazýldýktan sonra bir endpoint yazmamýz gerekiyor.
			//Anlamý
			//örneðin localhost://1234/category/index 1234 den sonra istekte bulunmak istediðimiz yer aslýnda signalRhub
			//örneðin localhost://1234/signalRhub bu þekilde istekte bulunmuþ olucaz
			app.MapHub<SignalRHub>("/signalrhub");

            app.Run();
        }
    }
}
