using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PatientManagementSys.Application;
using PatientManagementSys.Application.PatientCommands;
using PatientManagementSys.Domain.Entities;

namespace PatientManagementSys.UI
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

        static async System.Threading.Tasks.Task Main(string[] args)
        {
        start:
            Console.Clear();
            Console.WriteLine("Welcome to Patient Management System!");
            Console.WriteLine("1. Create Patient");
            Console.WriteLine("2. Read Patient");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Search Patient By ID");
            Console.WriteLine("6. Search Patient By Keyword");
            Console.WriteLine("7. Add Patient Diagnosis");
            Console.WriteLine("8. Exit");
            Console.Write("Please enter a number to proceed: ");
            string _mainMenu = Console.ReadLine();
            
            switch (_mainMenu)
            {
                case "1":
                    Console.WriteLine("\nRegistration");
                    Console.WriteLine("Please enter your details:\n");
                    Console.Write("Please enter your last name:");
                    string _patientLastName = Console.ReadLine();
                    Console.Write("Please enter your first name:");
                    string _patientFirstName = Console.ReadLine();
                    Console.Write("Please enter your middle name:");
                    string _patientMiddleName = Console.ReadLine();

                    PatientRecords patientRecords = new PatientRecords
                    {
                        LastName = _patientLastName,
                        FirstName = _patientFirstName,
                        MiddleName = _patientMiddleName
                    };

                    await Mediator.Send(new AddPatientCommand(patientRecords));
                    Console.WriteLine("Patient added successfully!");
                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string check = Console.ReadLine();
                    if(check.Contains("Y") || check.Contains("y"))
                    {
                        goto start;
                    }else if (check.Contains("N") || check.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;

                case "2":
                    ReadPatientQuery _readPatientCommand = new ReadPatientQuery();
                    var _readPatientCommand1 = await Mediator.Send(_readPatientCommand);
                    Console.Write("Here are the list of patients:\n");
                    foreach (var item in _readPatientCommand1)
                    {
                        Console.WriteLine("\nPatient ID: {0}\nLast Name: {1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): {4}\n", item.ID, item.LastName, item.FirstName, item.MiddleName, item.diseases);
                    }

                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _readCheck = Console.ReadLine();
                    if (_readCheck.Contains("Y") || _readCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_readCheck.Contains("N") || _readCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;
                case "3":
                    input:
                    try
                    {
                        Console.Write("Please enter the patient ID:");
                        string _patientId = Console.ReadLine();
                        long _patientId1 = long.Parse(_patientId);
                        var _idFlag = await Mediator.Send(new SearchPatientByIdQuery(_patientId1));
                        if (_idFlag != null)
                        {
                            Console.Write("Please enter updated Last Name:");
                            string _patientUpdateLastName = Console.ReadLine();
                            Console.Write("Please enter updated First Name:");
                            string _patientUpdateFirstName = Console.ReadLine();
                            Console.Write("Please enter updated Middle Name:");
                            string _patientUpdateMiddleName = Console.ReadLine();


                            PatientRecords patientRecord = new PatientRecords
                            {
                                ID = _patientId1,
                                LastName = _patientUpdateLastName,
                                FirstName = _patientUpdateFirstName,
                                MiddleName = _patientUpdateMiddleName

                            };

                            await Mediator.Send(new UpdatePatientRecordCommand(patientRecord));
                            Console.WriteLine("Patient updated successfully!");
                        }
                       

                    }
                    catch(Exception e)
                    {
                            Console.WriteLine(e.Message);
                            goto input;
                    }

                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _updateCheck = Console.ReadLine();
                    if (_updateCheck.Contains("Y") || _updateCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_updateCheck.Contains("N") || _updateCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;

                case "4":
                    Console.Write("Please enter the patient ID:");
                    string _patientIdDelete = Console.ReadLine();

                    long _patientIdDelete1 = long.Parse(_patientIdDelete);


                    await Mediator.Send(new DeletePatientCommand(_patientIdDelete1));
                    Console.WriteLine("Patient deleted successfully!");

                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _deleteCheck = Console.ReadLine();
                    if (_deleteCheck.Contains("Y") || _deleteCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_deleteCheck.Contains("N") || _deleteCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;

                case "5":
                searchById:
                    try
                    {
                        Console.Write("Please enter the patient ID:");
                        string _patientIdFind = Console.ReadLine();
                        long _patientIdFind1 = long.Parse(_patientIdFind);

                        SearchPatientByIdQuery _searchPatient = new SearchPatientByIdQuery(_patientIdFind1);
                        var _searchPatient1 = await Mediator.Send(_searchPatient);
                        if(_searchPatient1 != null)
                        {
                            Console.WriteLine("Here is the patient record:");
                            Console.WriteLine("\nPatient ID: {0}\nLast Name: " +
                                "{1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): " +
                                "{4}\n", _searchPatient1.ID, _searchPatient1.LastName, _searchPatient1.FirstName, _searchPatient1.MiddleName, _searchPatient1.diseases);

                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto searchById;
                    }

                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _searchByIdCheck = Console.ReadLine();
                    if (_searchByIdCheck.Contains("Y") || _searchByIdCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_searchByIdCheck.Contains("N") || _searchByIdCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;
                case "6":
                  searchByKeyword:  
                    try
                    {
                        Console.Write("Please enter any information of the patient:");
                        string _patientLastNameFind = Console.ReadLine();

                        SearchPatientByKeywordQuery _searchPatientLastName = new SearchPatientByKeywordQuery(_patientLastNameFind);
                        var _searchPatientLastName1 = await Mediator.Send(_searchPatientLastName);
                        if (_searchPatientLastName1 != null)
                        {
                            Console.WriteLine("Here is the patient record:");
                            foreach (var item in _searchPatientLastName1)
                            {
                                Console.WriteLine("\nPatient ID: {0}\nLast Name: " +
                                "{1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): " +
                                "{4}\n", item.ID, item.LastName, item.FirstName, item.MiddleName, item.diseases);
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto searchByKeyword;
                    }


                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _searchByKeywordCheck = Console.ReadLine();
                    if (_searchByKeywordCheck.Contains("Y") || _searchByKeywordCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_searchByKeywordCheck.Contains("N") || _searchByKeywordCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;

                case "7":
                    addDiagnosis:
                    try
                    {
                        
                        Console.Write("Please enter the patient ID:");
                        string _patientIdDiagnosis = Console.ReadLine();
                        long _patientIdDiagnosis1 = long.Parse(_patientIdDiagnosis);
                        var _idFlag = await Mediator.Send(new SearchPatientByIdQuery(_patientIdDiagnosis1));
                        if (_idFlag != null)
                        {
                            Console.Write("Please enter diagnosis:");
                            string _patientDiagnosis = Console.ReadLine();

                            await Mediator.Send(new AddPatientDiagnosisCommand(_patientIdDiagnosis1, _patientDiagnosis));
                            Console.WriteLine("Patient updated successfully!");
                        }
                        
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto addDiagnosis;
                    }
                    Console.WriteLine("\nDo you want to continue? [Y/N]: ");
                    string _diagnosisCheck = Console.ReadLine();
                    if (_diagnosisCheck.Contains("Y") || _diagnosisCheck.Contains("y"))
                    {
                        goto start;
                    }
                    else if (_diagnosisCheck.Contains("N") || _diagnosisCheck.Contains("n"))
                    {
                        Console.WriteLine("Thank you for using the system!");
                    }
                    break;

            }
        }


    }
}
