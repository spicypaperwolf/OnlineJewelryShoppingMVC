//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentTools;
using OnlineJewelryShoppingMVC.DataBase;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineJewelryShoppingMVC.App_Start), "PreStart")]

namespace OnlineJewelryShoppingMVC {
    public static class App_Start {
        public static void PreStart() {
            FluentStartup.Initialize(typeof(DbContextLocal));
        }
    }
}