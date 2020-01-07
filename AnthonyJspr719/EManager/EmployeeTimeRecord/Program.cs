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
using Employee_Management_System;
using EManager.Domain.Enums;

namespace EmployeeTimeRecord
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

            Console.WriteLine("EMPLOYEE TIME RECORD");

            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine("1 -  TIME IN");
            Console.WriteLine("2 - TIME OUT");

        start:
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                    Console.WriteLine("TIME IN");
                    Console.WriteLine("ENTER YOUR ID NUMBER");
                    var empID = Console.ReadLine();
                    var employeeID = Convert.ToInt32(empID);

                    SaveTimeInCommand saveTimeRecordCommand = new SaveTimeInCommand(employeeID);
                    var savingRes = await Mediator.Send(saveTimeRecordCommand);

                    Console.WriteLine("Time In Success!! ID# {0} NAME: {1} {2} {3} TIME: {4}", savingRes.ID, savingRes.FirstName, savingRes.MiddleName,savingRes.LastName, DateTime.Now);

                    goto start;


                case "2":

                    Console.WriteLine("TIME OUT");
                    Console.WriteLine("ENTER YOUR ID NUMBER");
                    var _empID = Console.ReadLine();
                    var _employeeID = Convert.ToInt32(_empID);
                   

                    SaveTimeOutCommand _saveTimeRecordCommand = new SaveTimeOutCommand(_employeeID);
                    var _savingRes = await Mediator.Send(_saveTimeRecordCommand);

                    Console.WriteLine("Time Out Success!! ID# {0} NAME: {1} {2} {3} TIME: {4}", _savingRes.ID, _savingRes.FirstName, _savingRes.MiddleName, _savingRes.LastName, DateTime.Now);


                    goto start;



       
                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;
            }


        }
    }
}
