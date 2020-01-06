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
                    Console.WriteLine("ENTER YOUR ID NUMBER TO TIME IN");
                    var empID = Console.ReadLine();
                    var employeeID = Convert.ToInt32(empID);
                    var time = DateTime.Now;


                    EmployeeTimeRecords timeRecord = new EmployeeTimeRecords
                    {
                        EmployeeInformationID = employeeID,
                        Time = time,
                        RecordType = RecordType.TimeIn
                    };

                    SaveTimeRecordCommand saveTimeRecordCommand = new SaveTimeRecordCommand(timeRecord);
                    var savingRes = await Mediator.Send(saveTimeRecordCommand);

                    if (savingRes == true)

                    {
                        Console.WriteLine("TIME IN RECORDED");
                    }
                    else
                    {
                        Console.WriteLine("TIME IN NOT RECORDED");
                    }

                    goto start;

                    



                case "2":

                    Console.WriteLine("TIME OUT");
                    Console.WriteLine("ENTER YOUR ID NUMBER TO TIME OUT");
                    var _empID = Console.ReadLine();
                    var _employeeID = Convert.ToInt32(_empID);
                    var _time = DateTime.Now;


                    EmployeeTimeRecords _timeRecord = new EmployeeTimeRecords
                    {
                        EmployeeInformationID = _employeeID,
                        Time = _time,
                        RecordType = RecordType.TimeOut
                    };

                    SaveTimeRecordCommand _saveTimeRecordCommand = new SaveTimeRecordCommand(_timeRecord);
                    var _savingRes = await Mediator.Send(_saveTimeRecordCommand);


                    if (_savingRes == true)

                    {
                        Console.WriteLine("TIME OUT RECORDED");
                    }
                    else
                    {
                        Console.WriteLine("TIME OUT NOT RECORDED");
                    }

                    goto start;



       
                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;
            }


        }
    }
}
