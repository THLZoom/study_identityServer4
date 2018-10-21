// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            //配置当前API方案
            services.AddAuthentication("Bearer")//默认方案
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";//配置鉴权服务器地址
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "thlAPI";//配置当前api服务在鉴权服务器中的昵称
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}