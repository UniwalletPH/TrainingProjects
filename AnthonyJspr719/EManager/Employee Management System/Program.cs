using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using EManager.Domain.Entities;
using EManager.Application.SystemCommand.Commands;
using Microsoft.Extensions.Configuration;
using System.IO;
using EManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EManager.Application.Interfaces;

namespace Employee_Management_System
{
    public class Program 
    {
        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<IMediator>();
            }
        }


        static async Task Main(string[] args)
        {

            var  _services = new ServiceCollection();

            var _builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true);

            var _config = _builder.Build();

            _services.AddDbContext<EManagerDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("EManagerConStr"));
            })
            .AddScoped<IEManagerDbContext>(provider => provider.GetService<EManagerDbContext>());

          
            var _serviceProvider = _services.BuildServiceProvider();












            Console.WriteLine("EMPLOYEE INFORMATION SYSTEM");
            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine("1 - ADD EMPLOYEE INFORMATION");
            Console.WriteLine("2 - UPDATE EMPLOYEE INFORMATION");
            Console.WriteLine("3 - DELETE EMPLOYEE INFORMATION");
            Console.WriteLine("4 - VIEW EMPLOYEES INFORMATIONS");

        start:
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":
                    Console.WriteLine("ADD EMPLOYEE INFORMATION");

                    Console.WriteLine("FIRST NAME");
                    var firstName = Console.ReadLine();

                    Console.WriteLine("MIDDLE NAME");
                    var middleName = Console.ReadLine();

                    Console.WriteLine("LAST NAME");
                    var lastName = Console.ReadLine();

                    EmployeeInformation employeeInformation = new EmployeeInformation { 
                    
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName
                    
                    };

                    var res = await Mediator.Send(new SaveInfoCommand(employeeInformation));

                    if (res == true) {

                        Console.WriteLine("INFORMATION SAVED");

                    }
                    else
                    {
                        Console.WriteLine("INFORMATION NOT SAVED");

                    }


                    goto start;

                case "2":

                   
                    goto start;


                case "3":
                   
                    

                    goto start;

                case "4":
                  
                   

                    goto start;

                case "5":
                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;
            }



        }
    }
}
