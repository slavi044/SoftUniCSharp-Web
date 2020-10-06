﻿namespace MyFirstMvcApp
{
    using SIS.MvcFramework;
    
    using System.Threading.Tasks;
    
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }     
    }
}
