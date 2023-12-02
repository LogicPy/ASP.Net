//C# code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
 public class Startup
 {
   public void ConfigureServices(IServiceCollection services)
   {
     services.AddControllersWithViews();
   }

   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
     if (env.IsDevelopment())
     {
       app.UseDeveloperExceptionPage();
     }
     app.UseRouting();
     app.UseEndpoints(endpoints =>
     {
       endpoints.MapControllers();
     });
   }
 }

 [Route("api/[controller]")]
 [ApiController]
 public class LoginController : ControllerBase
 {
   //function to authenticate user
   [HttpPost]
   public async Task<ActionResult> Login([FromBody] User user)
   {
     //check if user exists in database
     if (user.Username == "admin" && user.Password == "admin123")
     {
       return Ok();
     }
     else
     {
       return BadRequest();
     }
   }
 }
}
