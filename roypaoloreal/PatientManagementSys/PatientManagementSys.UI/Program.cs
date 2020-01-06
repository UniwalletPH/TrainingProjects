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
            start:
            switch(_mainMenu)
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
                    goto start;
                case "2":
                    ReadPatientCommand _readPatientCommand = new ReadPatientCommand();
                    var _readPatientCommand1 = await Mediator.Send(_readPatientCommand);
                    Console.Write("Here are the list of patients:\n");
                    foreach (var item in _readPatientCommand1)
                    {
                        Console.WriteLine("\nPatient ID: {0}\nLast Name: {1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): {4}\n",item.ID, item.LastName, item.FirstName,item.MiddleName,item.diseases);
                    }
                    //await Mediator.Send(new ReadPatientCommand(patientRecords));
                    break;
                case "3":
                    Console.Write("Please enter the patient ID:");
                    string _patientId = Console.ReadLine();
                    Console.Write("Please enter updated Last Name:");
                    string _patientUpdateLastName = Console.ReadLine();
                    Console.Write("Please enter updated First Name:");
                    string _patientUpdateFirstName = Console.ReadLine();
                    Console.Write("Please enter updated Middle Name:");
                    string _patientUpdateMiddleName = Console.ReadLine();

                    long _patientId1 = long.Parse(_patientId);

                    PatientRecords patientRecord = new PatientRecords
                    {
                        ID = _patientId1,
                        LastName = _patientUpdateLastName,
                        FirstName = _patientUpdateFirstName,
                        MiddleName = _patientUpdateMiddleName

                    };

                    await Mediator.Send(new UpdatePatientRecordCommand(patientRecord));
                    Console.WriteLine("Patient updated successfully!");
                    break;
                case "4":
                    Console.Write("Please enter the patient ID:");
                    string _patientIdDelete = Console.ReadLine();

                    long _patientIdDelete1 = long.Parse(_patientIdDelete);

                    PatientRecords deletePatientRecord = new PatientRecords
                    {
                        ID = _patientIdDelete1

                    };
                    await Mediator.Send(new DeletePatientCommand(deletePatientRecord));
                    Console.WriteLine("Patient deleted successfully!");
                    break;
                case "5":
                    Console.Write("Please enter the patient ID:");
                    string _patientIdFind = Console.ReadLine();
                    long _patientIdFind1 = long.Parse(_patientIdFind);

                    PatientRecords _patient = new PatientRecords
                    {
                        ID = _patientIdFind1
                    };

                    SearchPatientByIdQuery _searchPatient = new SearchPatientByIdQuery(_patient);
                    var _searchPatient1 = await Mediator.Send(_searchPatient);

                    Console.WriteLine("Here is the patient record:");
                    Console.WriteLine("\nPatient ID: {0}\nLast Name: " +
                        "{1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): " +
                        "{4}\n", _searchPatient1.ID, _searchPatient1.LastName, _searchPatient1.FirstName, _searchPatient1.MiddleName, _searchPatient1.diseases);
                    break;
                  case "6":
                    Console.Write("Please enter any information of the patient:");
                    string _patientLastNameFind = Console.ReadLine();

                    SearchPatientByKeywordQuery _searchPatientLastName = new SearchPatientByKeywordQuery(_patientLastNameFind);
                    var _searchPatientLastName1 = await Mediator.Send(_searchPatientLastName);

                    Console.WriteLine("Here is the patient record:");
                    foreach (var item in _searchPatientLastName1)
                    {
                        Console.WriteLine("\nPatient ID: {0}\nLast Name: " +
                        "{1}\nFirst Name: {2}\nMiddle Name: {3}\nDiseases(?): " +
                        "{4}\n", item.ID, item.LastName, item.FirstName, item.MiddleName, item.diseases);
                    }
                    
                    break;

                case "7":
                    Console.Write("Please enter the patient ID:");
                    string _patientIdDiagnosis = Console.ReadLine();
                    Console.Write("Please enter diagnosis:");
                    string _patientDiagnosis = Console.ReadLine();

                    long _patientIdDiagnosis1 = long.Parse(_patientIdDiagnosis);

                    PatientRecords patientRecordDiagnosis = new PatientRecords
                    {
                        ID = _patientIdDiagnosis1,
                        diseases = _patientDiagnosis

                    };

                    await Mediator.Send(new AddPatientDiagnosisCommand(patientRecordDiagnosis));
                    Console.WriteLine("Patient updated successfully!");
                    break;

            }
        }


    }
}
