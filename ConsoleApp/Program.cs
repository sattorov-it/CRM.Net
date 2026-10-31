// using Application.Services;
// using Domain.Models;
// using Infrastructure.Data;
// using Infrastructure.Repositories;

// var context = new AppDbContext();

// var studentService = new StudentService(new StudentRepository(context));
// var courseService = new CourseService(new CourseRepository(context));
// var mentorService = new MentorService(new MentorRepository(context));
// var groupService = new GroupService(new GroupRepository(context));
// var studentGroupService = new StudentGroupService(new StudentGroupRepository(context));
// var statisticsService = new StatisticsService(new StatisticsRepository(context));
// var analyticsService = new AnalyticsService(new AnalyticsRepository(context));

// while (true)
// {
//     Console.WriteLine();
//     Console.WriteLine("===== CRM =====");
//     Console.WriteLine("1. Students");
//     Console.WriteLine("2. Courses");
//     Console.WriteLine("3. Mentors");
//     Console.WriteLine("4. Groups");
//     Console.WriteLine("5. Student groups");
//     Console.WriteLine("6. Statistics");
//     Console.WriteLine("7. Analytics");
//     Console.WriteLine("0. Exit");

//     var choice = Read("Choose");
//     if (choice == "0") break;

//     switch (choice)
//     {
//         case "1": await StudentsMenu(); break;
//         case "2": await CoursesMenu(); break;
//         case "3": await MentorsMenu(); break;
//         case "4": await GroupsMenu(); break;
//         case "5": await StudentGroupsMenu(); break;
//         case "6": await StatisticsMenu(); break;
//         case "7": await analyticsService.GetCompletionRateAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// string Read(string text)
// {
//     Console.Write(text + ": ");
//     return Console.ReadLine()!;
// }

// int ReadInt(string text)
// {
//     return int.Parse(Read(text));
// }

// DateTime ReadDate(string text)
// {
//     return DateTime.Parse(Read(text + " (yyyy-mm-dd)"));
// }

// async Task StudentsMenu()
// {
//     Console.WriteLine("1. Add  2. List  3. Details  4. Edit  5. Delete");
//     Console.WriteLine("6. With groups  7. Without groups  8. Dropped out  9. Graduated");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1":
//             var newStudent = new Students
//             {
//                 Fullname = Read("Full name"),
//                 Email = Read("Email"),
//                 Phone = Read("Phone"),
//                 EnrollmentDate = ReadDate("Enrollment date")
//             };
//             await studentService.AddStudentAsync(newStudent);
//             break;
//         case "2":
//             await studentService.GetAllStudentsAsync();
//             break;
//         case "3":
//             await studentService.GetStudentAsync(ReadInt("Student id"));
//             break;
//         case "4":
//             var editStudent = new Students
//             {
//                 StudentsId = ReadInt("Student id"),
//                 Fullname = Read("Full name"),
//                 Email = Read("Email"),
//                 Phone = Read("Phone"),
//                 EnrollmentDate = ReadDate("Enrollment date")
//             };
//             await studentService.UpdateStudentAsync(editStudent);
//             break;
//         case "5":
//             await studentService.DeleteStudentAsync(ReadInt("Student id"));
//             break;
//         case "6": await studentService.GetStudentsWithGroupsAsync(); break;
//         case "7": await studentService.GetStudentsWithoutGroupsAsync(); break;
//         case "8": await studentService.GetDroppedOutStudentsAsync(); break;
//         case "9": await studentService.GetGraduatedStudentsAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// async Task CoursesMenu()
// {
//     Console.WriteLine("1. Add  2. List  3. Details  4. Edit  5. Delete");
//     Console.WriteLine("6. Students per course  7. Most popular  8. Least popular (3)  9. Top 3");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1":
//             var newCourse = new Course
//             {
//                 Title = Read("Title"),
//                 Description = Read("Description"),
//                 DurationWeeks = ReadInt("Duration (weeks)")
//             };
//             await courseService.AddCourseAsync(newCourse);
//             break;
//         case "2":
//             await courseService.GetAllCoursesAsync();
//             break;
//         case "3":
//             await courseService.GetCourseAsync(ReadInt("Course id"));
//             break;
//         case "4":
//             var editCourse = new Course
//             {
//                 CourseId = ReadInt("Course id"),
//                 Title = Read("Title"),
//                 Description = Read("Description"),
//                 DurationWeeks = ReadInt("Duration (weeks)")
//             };
//             await courseService.UpdateCourseAsync(editCourse);
//             break;
//         case "5":
//             await courseService.DeleteCourseAsync(ReadInt("Course id"));
//             break;
//         case "6": await courseService.GetStudentsPerCourseAsync(); break;
//         case "7": await courseService.GetMostPopularCourseAsync(); break;
//         case "8": await courseService.GetLeastPopularCoursesAsync(); break;
//         case "9": await courseService.GetTopThreeCoursesAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// async Task MentorsMenu()
// {
//     Console.WriteLine("1. Add  2. List  3. Details  4. Edit  5. Delete");
//     Console.WriteLine("6. Mentor with most students  7. Mentors with multiple courses");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1":
//             var newMentor = new Mentors
//             {
//                 FullName = Read("Full name"),
//                 Email = Read("Email"),
//                 Phone = Read("Phone"),
//                 Specialization = Read("Specialization")
//             };
//             await mentorService.AddMentorAsync(newMentor);
//             break;
//         case "2":
//             await mentorService.GetAllMentorsAsync();
//             break;
//         case "3":
//             await mentorService.GetMentorAsync(ReadInt("Mentor id"));
//             break;
//         case "4":
//             var editMentor = new Mentors
//             {
//                 MentorId = ReadInt("Mentor id"),
//                 FullName = Read("Full name"),
//                 Email = Read("Email"),
//                 Phone = Read("Phone"),
//                 Specialization = Read("Specialization")
//             };
//             await mentorService.UpdateMentorAsync(editMentor);
//             break;
//         case "5":
//             await mentorService.DeleteMentorAsync(ReadInt("Mentor id"));
//             break;
//         case "6": await mentorService.GetMentorWithMostStudentsAsync(); break;
//         case "7": await mentorService.GetMentorsWithMultipleCoursesAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// async Task GroupsMenu()
// {
//     Console.WriteLine("1. Add  2. List  3. Details  4. Edit  5. Delete");
//     Console.WriteLine("6. Students per group  7. Empty groups");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1":
//             var newGroup = new Groups
//             {
//                 GroupName = Read("Group name"),
//                 CourseId = ReadInt("Course id"),
//                 MentorId = ReadInt("Mentor id"),
//                 StartDate = ReadDate("Start date"),
//                 EndDate = ReadDate("End date")
//             };
//             await groupService.AddGroupAsync(newGroup);
//             break;
//         case "2":
//             await groupService.GetAllGroupsAsync();
//             break;
//         case "3":
//             await groupService.GetGroupAsync(ReadInt("Group id"));
//             break;
//         case "4":
//             var editGroup = new Groups
//             {
//                 GroupId = ReadInt("Group id"),
//                 GroupName = Read("Group name"),
//                 CourseId = ReadInt("Course id"),
//                 MentorId = ReadInt("Mentor id"),
//                 StartDate = ReadDate("Start date"),
//                 EndDate = ReadDate("End date")
//             };
//             await groupService.UpdateGroupAsync(editGroup);
//             break;
//         case "5":
//             await groupService.DeleteGroupAsync(ReadInt("Group id"));
//             break;
//         case "6": await groupService.GetStudentsPerGroupAsync(); break;
//         case "7": await groupService.GetEmptyGroupsAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// async Task StudentGroupsMenu()
// {
//     Console.WriteLine("1. Add student to group  2. Students in group  3. Update status  4. Remove from group");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1":
//             var studentGroup = new StudentGroups
//             {
//                 StudentId = ReadInt("Student id"),
//                 GroupId = ReadInt("Group id"),
//                 Status = "Активен"
//             };
//             await studentGroupService.AddStudentToGroupAsync(studentGroup);
//             break;
//         case "2":
//             await studentGroupService.GetStudentsInGroupAsync(ReadInt("Group id"));
//             break;
//         case "3":
//             var id = ReadInt("Student group id");
//             var status = Read("Status (Активен / Отчислен / Завершил)");
//             await studentGroupService.UpdateStatusAsync(id, status);
//             break;
//         case "4":
//             await studentGroupService.RemoveStudentFromGroupAsync(ReadInt("Student group id"));
//             break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }

// async Task StatisticsMenu()
// {
//     Console.WriteLine("1. Students count  2. Groups count  3. Courses count  4. Mentors count  5. All start dates");
//     var choice = Read("Choose");

//     switch (choice)
//     {
//         case "1": await statisticsService.GetTotalStudentsCountAsync(); break;
//         case "2": await statisticsService.GetTotalGroupsCountAsync(); break;
//         case "3": await statisticsService.GetTotalCoursesCountAsync(); break;
//         case "4": await statisticsService.GetTotalMentorsCountAsync(); break;
//         case "5": await statisticsService.GetAllStartDatesAsync(); break;
//         default: Console.WriteLine("Wrong choice!"); break;
//     }
// }