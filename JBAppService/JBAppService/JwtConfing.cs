﻿using JBAppService.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBAppService
{
    public class JwtConfing
    {
        public JwtConfing()
        {

        }

        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddSingleton<JwtHelpers>();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true; // WWW-Authenticate 會顯示詳細錯誤原因

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = Configuration.GetValue<string>("JwtSettings:NameClaim"),
                        RoleClaimType = Configuration.GetValue<string>("JwtSettings:RoleClaim"),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),
                        ValidateAudience = false,
                        //ValidAudience = Configuration.GetValue<string>("JwtSettings:Issuer"),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false, // 如果 JWT 包含 key 才需要驗證，一般都只有簽章而已
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SignKey")))
                    };
                });
            return services;
        }
    }
}
