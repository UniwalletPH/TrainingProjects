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

            Console.WriteLine("EMPLOYEE INFORMATION SYSTEM");
            Console.WriteLine("YOUR OPTIONS");
            Console.WriteLine("1 - ADD EMPLOYEE");
            Console.WriteLine("2 - VIEW EMPLOYEES");
            Console.WriteLine("3 - DELETE EMPLOYEE");
            Console.WriteLine("4 - UPDATE EMPLOYEE LASTNAME");
            Console.WriteLine("5 - SEARCH EMPLOYEE");

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

               
                    
                    Console.WriteLine("DATE OF BIRTH:  dd/MM/yyyy");
                    DateTime born = DateTime.Parse(Console.ReadLine());
                    TimeSpan age = DateTime.Today - born;
                    var agee = Math.Floor(age.Days / 365.255);
                    var employeeAge = Convert.ToInt32(agee);

                 


                    Console.WriteLine("ADDRESS");
                    var employeeAddress = Console.ReadLine();


                    
                    EmployeeInformation employeeInformation = new EmployeeInformation
                    {
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName,
                        Address = employeeAddress,
                        Age = employeeAge,
                        DateOfBirth = born     
                    };

                    var checkRes = await Mediator.Send(new CheckEmployeeAgeCommand(employeeInformation.Age));

                    if (checkRes == true)
                    {
                        var res = await Mediator.Send(new SaveInfoCommand(employeeInformation));

                        if (res > 0)
                        {
                            Console.WriteLine("SAVED");
                        }

                        goto start;

                    }

                    else
                    {
                        Console.WriteLine("CAN'T SAVE!! UNDER AGE");
                        goto start;

                    }

                 

                case "2":

                    Console.WriteLine("EMPLOYEES INFORMATION");
                    FetchAllInfoCommand fetchAllInfoCommand = new FetchAllInfoCommand();
                    var _return = await Mediator.Send(fetchAllInfoCommand);


                    Console.WriteLine("EMPLOYEE ID  - NAME      -      ADDRESS");
                    foreach (var item in _return)
                    {
                        
                        Console.WriteLine("{0}             {1} {2} {3}  {4}", item.ID,item.FirstName, item.MiddleName, item.LastName, item.Address);
                    }



                    goto start;


                case "3":

                    Console.WriteLine("EMPLOYEES INFORMATION");

                    FetchAllInfoCommand getAllInfo = new FetchAllInfoCommand();
                    var _retValue = await Mediator.Send(getAllInfo);
                   

                    foreach (var item in _retValue)
                    {
                        Console.WriteLine("{0}   {1}  {2}   {3}",item.ID , item.FirstName, item.MiddleName, item.LastName);
                        
                    }
                    Console.WriteLine("ENTER EMPLOYEE ID NUMBER TO DELETE");
                    var _idChosen = Console.ReadLine();
                    int _selectedID = int.Parse(_idChosen);


                    DeleteInfoCommand deleteInfoCommand = new DeleteInfoCommand(_selectedID);

                    var _returnVal = await Mediator.Send(deleteInfoCommand);
                    if (_returnVal == true) {

                        Console.WriteLine("DELETED");

                    }


                    goto start;

                case "4":
                    FetchAllInfoCommand getAllData = new FetchAllInfoCommand();
                    var _returnValue = await Mediator.Send(getAllData);
                    int count = 0;

                    foreach (var item in _returnValue)
                    {
                        Console.WriteLine("{0}   {1}  {2}   {3}", count, item.FirstName, item.MiddleName, item.LastName);
                        count++;
                    }
                    Console.WriteLine("ENTER EMPLOYEE ID TO UPDATE LASTNAME");
                    var _id = Console.ReadLine();
                    int _indexChosen = int.Parse(_id);
                    var selected = _returnValue[_indexChosen];

                    Console.WriteLine("ENTER NEW LASTNAME");
                    var newLastname = Console.ReadLine();

                    UpdateEmployeeLastNameCommand updateEmployeeLastNameCommand = new UpdateEmployeeLastNameCommand(selected,newLastname);
                    var _r = await Mediator.Send(updateEmployeeLastNameCommand);

                    if (_r == true)
                    {

                        Console.WriteLine("LASTNAME UPDATED");
                    }

                    goto start;

                case "5":

                    Console.WriteLine("SEARCH EMPLOYEE");

                    Console.WriteLine("ENTRY");
                    var searchEntry = Console.ReadLine();

                    SearchEmployeeLastNameQuery searchEmployeeLastNameCommand = new SearchEmployeeLastNameQuery(searchEntry);
                   var  searchedEntries = await Mediator.Send(searchEmployeeLastNameCommand);

                    foreach (var item in searchedEntries)
                    {
                        Console.WriteLine("{0}   {1}   {2}  {3}   {4}", item.LastName, item.FirstName, item.MiddleName, item.DateOfBirth, item.Address);

                    }

                    goto start;

                case "6":
                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;
            }
        }
    }
}
