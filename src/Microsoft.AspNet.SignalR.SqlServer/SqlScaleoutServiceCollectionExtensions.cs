﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNet.SignalR.SqlServer;
using Microsoft.Framework.ConfigurationModel;

namespace Microsoft.Framework.DependencyInjection
{
    public static class SqlScaleoutServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalRSqlScaleout(this IServiceCollection services, Action<SqlScaleoutConfiguration> configureOptions = null)
        {
            return services.AddSignalRSqlScaleout(configuration: null, configureOptions: configureOptions);
        }
        public static IServiceCollection AddSignalRSqlScaleout(this IServiceCollection services, IConfiguration configuration, Action<SqlScaleoutConfiguration> configureOptions = null)
        {
            var describe = new ServiceDescriber(configuration);

            // SignalR services
            services.Add(describe.Singleton<IMessageBus, SqlMessageBus>());
           
            if (configuration != null)
            {
                services.Configure<SqlScaleoutConfiguration>(configuration);
            }

            if (configureOptions != null)
            {
                services.Configure(configureOptions);
            }

            return services;
        }
    }
}
