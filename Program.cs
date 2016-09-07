using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using BookService.Models;

namespace BookService
{
    public class Program
    {
        public static List<Book> BookList = new List<Book>();
        public static int NextId = 1;
        public static void Main(string[] args)
        {
            BookList.Add(new Book("Livro 01", 20.90));
            BookList.Add(new Book("Livro 02", 19.25));
            BookList.Add(new Book("Livro 03", 47.50));
            BookList.Add(new Book("Livro 04", 33.10));
            BookList.Add(new Book("Livro 05", 10.20));
            BookList.Add(new Book("Livro 06", 23.45));
            BookList.Add(new Book("Livro 07", 79.90));
            
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();
            
            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
        
    }
}
