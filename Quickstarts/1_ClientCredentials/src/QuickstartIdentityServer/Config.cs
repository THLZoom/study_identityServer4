// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;
using System.Collections.Generic;

namespace QuickstartIdentityServer
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            { 
                new ApiResource("thlAPI", "THL API")//注册需要鉴权的api服务
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client //注册客户端访问鉴权服务器的相关信息
                {
                    ClientId = "ClientID",//客户端的账号

                    AllowedGrantTypes = GrantTypes.ClientCredentials,//鉴权模式

                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())//客户端的密码
                    },

                    AllowedScopes = { "thlAPI" } //客户端可访问的api权限,对应ApiResource中注册的信息
                }
            };
        }
    }
}