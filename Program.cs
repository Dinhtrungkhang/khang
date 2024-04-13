using SIMS.DataContext;
using SIMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<CourseContext>(provider =>
{
    string filePath = "CSV_Files/Course.csv";

    return new CourseContext(filePath);
}
);

builder.Services.AddScoped<StudentService>();

builder.Services.AddScoped<StudentContext>(provider =>
{
    string filePath = "CSV_Files/Student.csv";

    return new StudentContext(filePath);
}
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
