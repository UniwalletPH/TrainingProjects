using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudentEnrollmentSystem.Domain.Entities;
using StudentEnrollmentSystem.Application.Students.Commands;
using StudentEnrollmentSystem.Application.Students.Queries;
using StudentEnrollmentSystem.Application.Schedule.Commands;
using StudentEnrollmentSystem.Application.Professors.Commands;

namespace Student_Enrollment_System
{
    public class Program
    {
        private static StudentBasicInfo myStudentBasicInfo;

        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<IMediator>();
            }
        }

        static async Task Main(string[] args)
        {

            List<StudentBasicInfo> _studentBasicInfos = new List<StudentBasicInfo>();

            Console.WriteLine("STUDENT ENROLLMENT SYSTEM");
            Console.WriteLine();
            Console.WriteLine("1 - Create Student Information");
            Console.WriteLine("2 - Read Student Information");
            Console.WriteLine("3 - Update Student Information");
            Console.WriteLine("4 - Delete Student Information");
            Console.WriteLine("5 - Search Student By ID");
            Console.WriteLine("6 - Search Student By Keyword");
            Console.WriteLine("7 - Add Subjects");
            Console.WriteLine("8 - Search Student Subjects By ID");
            Console.WriteLine("9 - Delete Student Subjects By ID");
            Console.WriteLine("10 - Student Daily Time Record - Time In");
            Console.WriteLine("11 - Student Daily Time Record - Time Out");
            Console.WriteLine("15 - EXIT");

        start:
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();
            Console.WriteLine();

            switch (_cmdNumber)
            {
                //case 1: Create Student Information
                #region Create Student Information
                case "1":

                    Console.Write("Enter Student Last Name: ");
                    var _StudentLastName = Console.ReadLine();

                    Console.Write("Enter Student First Name: ");
                    var _StudentFirstName = Console.ReadLine();

                    Console.Write("Enter Student Middle Name: ");
                    var _StudentMiddleName = Console.ReadLine();

                    Console.Write("Enter Student Age: ");
                    var _StudentAge = Console.ReadLine();

                    Console.Write("Enter Student Gender: ");
                    var _StudentGender = Console.ReadLine();

                    Console.Write("Enter Student Address: ");
                    var _StudentAddress = Console.ReadLine();

                    Console.Write("Enter Student Email Address: ");
                    var _StudentEmailAddress = Console.ReadLine();

                    Console.Write("Enter Student Contact Number: ");
                    var _StudentContactNumber = Console.ReadLine();

                    StudentBasicInfo _studentBasicInfo = new StudentBasicInfo
                    {
                        StudentLastName = _StudentLastName,
                        StudentFirstName = _StudentFirstName,
                        StudentMiddleName = _StudentMiddleName,
                        StudentAge = _StudentAge,
                        StudentGender = _StudentGender,
                        StudentAddress = _StudentAddress,
                        StudentEmailAddress = _StudentEmailAddress,
                        StudentContactNumber = _StudentContactNumber
                    };


                    var _addStudentInfo = await Mediator.Send(new CreateStudentInfoCommand(_studentBasicInfo));

                    if (_addStudentInfo == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student Information Added!");
                    }
                    goto start;
                #endregion


                //case 2: Read Student Information
                #region Read Student Information
                case "2":

                    var _readStudentInfo = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}", item.ID);
                        Console.WriteLine("Last Name: {0}", item.StudentLastName);
                        Console.WriteLine("First Name: {0}", item.StudentFirstName);
                        Console.WriteLine("Middle Name: {0}", item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }

                    goto start;
                #endregion


                //case 3: Update Student Information
                #region Update Student Information
                case "3":

                    var _readStudentInfo1 = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID {0}  |  Last Name: {1}  |  First Name: {2}  |  Middle Name: {3}", item.ID, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }
                    Console.WriteLine();
                    Console.Write("Enter Student ID to update: ");
                    var _updateStudentID = Console.ReadLine();
                    int _updatedStudentSelectedID = int.Parse(_updateStudentID);

                    Console.WriteLine();
                    Console.Write("Enter Student Last Name: ");
                    var _updatedStudentLastName = Console.ReadLine();

                    Console.Write("Enter Student First Name: ");
                    var _updatedStudentFirstName = Console.ReadLine();

                    Console.Write("Enter Student Middle Name: ");
                    var _updatedStudentMiddleName = Console.ReadLine();

                    Console.Write("Enter Student Age: ");
                    var _updatedStudentAge = Console.ReadLine();

                    Console.Write("Enter Student Gender: ");
                    var _updatedStudentGender = Console.ReadLine();

                    Console.Write("Enter Student Address: ");
                    var _updatedStudentAddress = Console.ReadLine();

                    Console.Write("Enter Student Email Address: ");
                    var _updatedStudentEmailAddress = Console.ReadLine();

                    Console.Write("Enter Student Contact Number: ");
                    var _updatedStudentContactNumber = Console.ReadLine();


                    StudentBasicInfo _updatedStudentBasicInfo = new StudentBasicInfo
                    {
                        ID = _updatedStudentSelectedID,
                        StudentLastName = _updatedStudentLastName,
                        StudentFirstName = _updatedStudentFirstName,
                        StudentMiddleName = _updatedStudentMiddleName,
                        StudentAge = _updatedStudentAge,
                        StudentGender = _updatedStudentGender,
                        StudentAddress = _updatedStudentAddress,
                        StudentEmailAddress = _updatedStudentEmailAddress,
                        StudentContactNumber = _updatedStudentContactNumber
                    };

                    UpdateStudentInfoCommand _updateStudentInfoCommand = new UpdateStudentInfoCommand(_updatedStudentBasicInfo);
                    var _updatedStudentInfo = await Mediator.Send(_updateStudentInfoCommand);

                    if (_updatedStudentInfo == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student Information Updated!");
                    }

                    goto start;
                #endregion


                //case 4: Delete Student Information
                #region Delete Student Information
                case "4":

                    var _readStudentInfo2 = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}  |  Last Name: {1}  |  First Name: {2}  |  Middle Name: {3}", item.ID, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }

                    Console.WriteLine();
                    Console.Write("Enter Student ID to delete: ");
                    var _deleteStudentID = Console.ReadLine();
                    int _deleteStudentSelectedID = int.Parse(_deleteStudentID);


                    try
                    {
                        var _deleteStudentInfo = await Mediator.Send(new DeleteStudentInfoCommand(_deleteStudentSelectedID));
                        if (_deleteStudentInfo == true)
                        {
                            Console.WriteLine("Student ID {0} is Deleted!", _deleteStudentID);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                    }

                    goto start;
                #endregion


                //case 5: Search Student By ID
                #region Search Student By ID

                case "5":
                    Console.WriteLine();
                    Console.Write("Enter ID to find: ");
                    var _searchStudentID = Console.ReadLine();
                    var _searchedStudentID = int.Parse(_searchStudentID);

                    var _searchedStudentByIDDetails = await Mediator.Send(new SearchStudentByIDQuery(_searchedStudentID));


                    if (_searchedStudentByIDDetails != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID successfully searched!");
                        Console.WriteLine();
                        Console.WriteLine("Searched ID: {0}   |   Last Name: {1}  ,  First Name: {2}  ,  Middle Name: {3}",
                                            _searchedStudentID,
                                            _searchedStudentByIDDetails.StudentLastName,
                                            _searchedStudentByIDDetails.StudentFirstName,
                                            _searchedStudentByIDDetails.StudentMiddleName);
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID does not exist!");
                    }

                    goto start;

                #endregion;


                //case 6: Search Student By Keyword
                #region Search Student By Keyword

                case "6":

                    Console.Write("Enter Keyword to find: ");
                    var _searchKeywordToFind = Console.ReadLine();

                    var _searchedKeywordToFind = await Mediator.Send(new SearchByKeywordQuery(_searchKeywordToFind));

                    if (_searchedKeywordToFind != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Keyword successfully searched!");
                        Console.WriteLine();

                        foreach (var item in _searchedKeywordToFind)
                        {
                            Console.WriteLine("Searched Keyword: {0}   |    Last Name: {1}  ,  First Name: {2}  ,  Middle Name: {3}", _searchKeywordToFind, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Keyword!");
                    }

                    goto start;
                #endregion


                //case 7: Add Subjects
                #region Add Student Subjects
                case "7":
                here:

                    var _readStudentInfo3 = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}  |  Last Name: {1}  |  First Name: {2}  |  Middle Name: {3}", item.ID, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }

                    Console.WriteLine();
                    Console.Write("Enter ID to add subjects: ");
                    var _subjectSearchStudentID = Console.ReadLine();
                    var _subjectSearchedStudentID = int.Parse(_subjectSearchStudentID);

                    var _subjectSearchedStudentByIDDetails = await Mediator.Send(new SearchStudentByIDQuery(_subjectSearchedStudentID));


                    if (_subjectSearchedStudentByIDDetails != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID successfully searched!");
                        Console.WriteLine();
                        Console.WriteLine("Searched ID: {0}   |   Last Name: {1}  ,  First Name: {2}  ,  Middle Name: {3}",
                                            _subjectSearchedStudentID,
                                            _subjectSearchedStudentByIDDetails.StudentLastName,
                                            _subjectSearchedStudentByIDDetails.StudentFirstName,
                                            _subjectSearchedStudentByIDDetails.StudentMiddleName);
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID does not exist!");
                        goto here;
                    }

                    choosedetails:

                    Console.WriteLine();
                    Console.WriteLine("Subject List: ");
                    Console.WriteLine("1 - Math");
                    Console.WriteLine("2 - Science");
                    Console.WriteLine("3 - English");
                    Console.WriteLine("4 - Filipino");
                    Console.WriteLine("5 - Religion");

                    Console.WriteLine();
                    Console.Write("Add Subject ID for Student ID {0}: ", _subjectSearchedStudentID);
                    var _addSubject = Console.ReadLine();
                    var _addedSubject = int.Parse(_addSubject);

                    var _addedSubjectsCommand = await Mediator.Send(new AddSubjectsCommand(_addedSubject));


                    Console.WriteLine();
                    Console.WriteLine("Professor List: ");
                    Console.WriteLine("1 - Prof - Math");
                    Console.WriteLine("2 - Prof - Science");
                    Console.WriteLine("3 - Prof - English");
                    Console.WriteLine("4 - Prof - Filipino");
                    Console.WriteLine("5 - Prof - Religion");

                    Console.WriteLine();
                    Console.Write("Add professor for Subject ID {0}: ", _addedSubject);
                    var _addProfessor = Console.ReadLine();
                    var _addedProfessor = int.Parse(_addProfessor);

                    var _addedProfessorCommand = await Mediator.Send(new AddProfessorCommand(_addedProfessor));


                    Console.WriteLine();
                    Console.WriteLine("Semester and Year ID: ");
                    Console.WriteLine("1 - 1st Semester | SY: 2019");
                    Console.WriteLine("2 - 2nd Semester | SY: 2019");
                    Console.WriteLine("3 - 1st Semester | SY: 2020");
                    Console.WriteLine("4 - 2nd Semester | SY: 2020");

                    Console.WriteLine();
                    Console.Write("Choose semester and year ID for the subject chosen: ");
                    var _addSched = Console.ReadLine();
                    var _addedSched = int.Parse(_addSched);

                    var _selectedSemester = await Mediator.Send(new FindSemesterQuery(_addedSched));


                    if (_addedSubject != _addedProfessor)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your chosen Professor ID [{0}] is not compatible for Subject ID [{1}]", _addedSubject, _addedProfessor);
                        Console.WriteLine("Please try again!");
                        goto choosedetails;
                    }

                    var _subjectDetailsCheckerCommand = await Mediator.Send(new SubjectDetailsCheckerCommand(_addedSubject, _addedProfessor, _addedSched));


                    if (_subjectDetailsCheckerCommand != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You already enrolled Subject ID [{0}]", _addedSubject);
                        Console.WriteLine("Please try again!");
                        goto choosedetails;
                    }

                    else
                    {
                        var _addedSubjectDetailsCommand = await Mediator.Send(new AddSubjectDetailsCommand(_subjectSearchedStudentByIDDetails.ID, _addedSubjectsCommand.ID, _addedProfessorCommand.ID, _selectedSemester.ID));

                        if (_addedSubjectDetailsCommand == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Student Subject Added!");
                        }
                    }

                    goto start;
                #endregion


                //case 8: Search Students Subjects
                #region Search Students Subjects
                case "8":

                    var _readStudentInfo4 = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}  |  Last Name: {1}  |  First Name: {2}  |  Middle Name: {3}", item.ID, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }

                    Console.WriteLine();
                    Console.Write("Enter Student ID: ");
                    var _searchStudentSubjects = Console.ReadLine();
                    var _searchedStudentSubjects = int.Parse(_searchStudentSubjects);

                    var _searchedStudentSubjectsCommand = await Mediator.Send(new SearchStudentSubjectsQuery(_searchedStudentSubjects));

                    Console.WriteLine();
                    Console.WriteLine("Subject List: ");
                    Console.WriteLine("1 - Math");
                    Console.WriteLine("2 - Science");
                    Console.WriteLine("3 - English");
                    Console.WriteLine("4 - Filipino");
                    Console.WriteLine("5 - Religion");

                    Console.WriteLine();
                    Console.WriteLine("Semester and Year ID: ");
                    Console.WriteLine("1 - 1st Semester | SY: 2019");
                    Console.WriteLine("2 - 2nd Semester | SY: 2019");
                    Console.WriteLine("3 - 1st Semester | SY: 2020");
                    Console.WriteLine("4 - 2nd Semester | SY: 2020");

                    if (_searchedStudentSubjectsCommand != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Student ID successfully searched!");
                        Console.WriteLine();

                        foreach (var item in _searchedStudentSubjectsCommand)
                        {
                            Console.WriteLine("Searched ID: {0}   |    Subject ID: {1}  ,  Schedule ID: {2}",
                                item.StudentBasicInfoID, item.StudentSubjectsID, item.EnrollmentDetailsID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student ID does not have any registered subjects!");
                    }



                    goto start;
                #endregion


                //case 9: Delete Students Subjects
                #region Delete Students Subjects
                case "9":

                    #region READ STUDENT LISTS
                    var _readStudentInfo5 = await Mediator.Send(new ReadStudentInfoQuery());

                    foreach (var item in _readStudentInfo5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}  |  Last Name: {1}  |  First Name: {2}  |  Middle Name: {3}", item.ID, item.StudentLastName, item.StudentFirstName, item.StudentMiddleName);
                        Console.WriteLine("Age: {0}", item.StudentAge);
                        Console.WriteLine("Gender: {0}", item.StudentGender);
                        Console.WriteLine("Address: {0}", item.StudentEmailAddress);
                        Console.WriteLine("Email Address: {0}", item.StudentAddress);
                        Console.WriteLine("Contact Number: {0}", item.StudentContactNumber);
                    }
                    #endregion

                    #region READ STUDENT SUBJECTS
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter Student ID to delete subjects: ");
                    var _deleteStudentSubject = Console.ReadLine();
                    int _deleteStudentSubjectID = int.Parse(_deleteStudentSubject);


                    var _searchedDeleteStudentSubjectsCommand = await Mediator.Send(new SearchStudentSubjectsQuery(_deleteStudentSubjectID));

                    if (_searchedDeleteStudentSubjectsCommand.Any())
                    {
                        Console.WriteLine();
                        Console.WriteLine();

                        foreach (var item in _searchedDeleteStudentSubjectsCommand)
                        {
                            Console.WriteLine("Student ID: {0}   |   Subject Details ID: {1}   |   Subject ID: {2}  ,  Schedule ID: {3}",
                                item.StudentBasicInfoID, item.ID, item.StudentSubjectsID, item.EnrollmentDetailsID);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student ID does not have any registered subjects!");
                    }
                    #endregion

                    #region DELETE STUDENT SUBJECT
                    Console.WriteLine();
                    Console.Write("Enter Subject Details ID to delete: ");
                    var _selectSubjectIDToDelete = Console.ReadLine();
                    var _selectedSubjectIDToDelete = int.Parse(_selectSubjectIDToDelete);


                    StudentSubjectList _deleteStudentSubjectInfoID = new StudentSubjectList
                    {
                        ID = _selectedSubjectIDToDelete
                    };


                    DeleteStudentSubjectCommand _deleteStudentSubjectCommand = new DeleteStudentSubjectCommand(_deleteStudentSubjectInfoID);
                    var _deleteStudentSubjectInfo = await Mediator.Send(_deleteStudentSubjectCommand);

                    if (_deleteStudentSubjectInfo == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student ID: {0}   |  Subject Detail ID: {1} is Deleted!", _deleteStudentSubjectID, _selectedSubjectIDToDelete);
                    } 
                    #endregion

                    goto start;
                #endregion


                //case 10: Daily Time Record - Time In
                #region Student Daily Time Record - Time In
                case "10":

                    Console.WriteLine("Good day!");
                    timeinhere:
                    Console.Write("Enter Student ID to Time In: ");
                    var _studIDIn = Console.ReadLine();
                    var _studIDTimeIn = int.Parse(_studIDIn);


                    try
                    {
                        var _studentTimeIn = await Mediator.Send(new TimeInStudentIDCommand(_studIDTimeIn));

                        if (_studentTimeIn == true)
                        {
                            Console.WriteLine("Student ID: {0} | Time In: {1} ", _studIDTimeIn, DateTime.Now);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time in failed!");
                        Console.WriteLine(ex.Message);
                        goto timeinhere;
                    }

                    goto start;
                #endregion


                //case 11: Daily Time Record - Time Out
                #region Student Daily Time Record - Time Out
                case "11":

                    Console.WriteLine("Good day!");
                    timeouthere:
                    Console.WriteLine("Enter Student ID to Time Out: ");
                    var _studIDOut = Console.ReadLine();
                    var _studIDTimeOut = int.Parse(_studIDOut);


                    try
                    {
                        var _studentTimeOut = await Mediator.Send(new TimeOutStudentIDCommand(_studIDTimeOut));

                        if (_studentTimeOut != null)
                        {
                            Console.WriteLine("Student ID: {0}", _studIDTimeOut);
                            Console.WriteLine("Time In: {0} | Time Out: {1} ", _studentTimeOut, DateTime.Now);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Time in failed!");
                        Console.WriteLine(ex.Message);
                        goto timeouthere;
                    }

                    goto start;
                #endregion

                case "12":

                    Console.Write("Enter Student ID to Time Out: ");
                    var _studentIDOut = Console.ReadLine();
                    var _studentIDTimeOut = int.Parse(_studentIDOut);

                    goto start;

                //case 15: Exit Program
                #region Exit Program
                case "15":

                    break;
                #endregion


                //Invalid Case
                #region Invalid Command!
                default:
                    Console.WriteLine("Invalid Command!");
                    goto start;
                    #endregion

            }

            //add prof
            //check subject conflict
        }
    }
}
