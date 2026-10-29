// using Application.Services;
// using Domain.Models;
// using Infrastructure.Data;
// using Infrastructure.Repositories;

// var appDbContext = new AppDbContext();

// var studentRepository = new StudentRepository(appDbContext);
// var courseRepository = new CourseRepository(appDbContext);
// var groupRepository = new GroupRepository(appDbContext);
// var mentorRepository = new MentorsRepository(appDbContext);
// var studentGroupRepository = new StudentGroupRepository(appDbContext);

// var studentService = new StudentService(studentRepository);
// var courseService = new CourseService(courseRepository);
// var groupService = new GroupService(groupRepository);
// var mentorService = new MentorService(mentorRepository);
// var studentGroupService = new StudentGroupService(studentGroupRepository);

// while (true)
// {
//     System.Console.WriteLine("==================================");
//     System.Console.WriteLine(@"1 - Show all students.
// 2 - Show student.
// 3 - Add new student.
// 4 - Update student.
// 5 - Delete student.
// 6 - Show all courses.
// 7 - Show course.
// 8 - Add new course.
// 9 - Update course.
// 10 - Delete course.
// 11 - Show all groups.
// 12 - Show group.
// 13 - Add new group.
// 14 - Update group.
// 15 - Delete group.
// 16 - Show all mentors.
// 17 - Show mentor.
// 18 - Add new mentor.
// 19 - Update mentor.
// 20 - Delete mentor.
// 21 - Show all student groups.
// 22 - Show student group.
// 23 - Add new student group.
// 24 - Update student group.
// 25 - Delete student group.
// 0 - Exit.");
//     var option = Console.ReadLine();
//     System.Console.WriteLine("==================================");

//     switch (option)
//     {
//         case "1":
//             await studentService.GetAllStudentsAsync();
//             break;
//         case "2":
//             System.Console.Write("Enter id: ");
//             var student_id = Convert.ToInt32(Console.ReadLine());
//             await studentService.GetStudentAsync(student_id);
//             break;
//         case "3":
//             System.Console.Write("Enter fullname: ");
//             var fullname = Console.ReadLine()!;
//             System.Console.Write("Enter email: ");
//             var email = Console.ReadLine()!;
//             System.Console.Write("Enter phone: ");
//             var phone = Console.ReadLine()!;
//             System.Console.Write("Enter enrollment date: ");
//             var enrollmentDate = Convert.ToDateTime(Console.ReadLine());
//             var student = new Student()
//             {
//                 Fullname = fullname,
//                 Email = email,
//                 Phone = phone,
//                 EnrollmentDate = DateOnly.FromDateTime(enrollmentDate)
//             };
//             await studentService.AddStudentAsync(student);
//             break;
//         case "4":
//             System.Console.Write("Enter id: ");
//             var uStudentId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter fullname: ");
//             var uFullname = Console.ReadLine()!;
//             System.Console.Write("Enter email: ");
//             var uEmail = Console.ReadLine()!;
//             System.Console.Write("Enter phone: ");
//             var uPhone = Console.ReadLine()!;
//             System.Console.Write("Enter enrollment date: ");
//             var uEnrollmentDate = Convert.ToDateTime(Console.ReadLine());
//             var uStudent = new Student()
//             {
//                 StudentId = uStudentId,
//                 Fullname = uFullname,
//                 Email = uEmail,
//                 Phone = uPhone,
//                 EnrollmentDate = DateOnly.FromDateTime(uEnrollmentDate)
//             };
//             await studentService.UpdateStudentAsync(uStudent);
//             break;
//         case "5":
//             System.Console.Write("Enter id: ");
//             var dStudentId = Convert.ToInt32(Console.ReadLine());
//             await studentService.DeleteStudentAsync(dStudentId);
//             break;

//         case "6":
//             await courseService.GetAllCoursesAsync();
//             break;
//         case "7":
//             System.Console.Write("Enter id: ");
//             var courseId = Convert.ToInt32(Console.ReadLine());
//             await courseService.GetCourseAsync(courseId);
//             break;
//         case "8":
//             System.Console.Write("Enter title: ");
//             var title = Console.ReadLine()!;
//             System.Console.Write("Enter description: ");
//             var description = Console.ReadLine()!;
//             System.Console.Write("Enter duration weeks: ");
//             var durationWeeks = Convert.ToInt32(Console.ReadLine());
//             var course = new Course()
//             {
//                 Title = title,
//                 Description = description,
//                 DurationWeeks = durationWeeks
//             };
//             await courseService.AddCourseAsync(course);
//             break;
//         case "9":
//             System.Console.Write("Enter id: ");
//             var uCourseId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter title: ");
//             var uTitle = Console.ReadLine()!;
//             System.Console.Write("Enter description: ");
//             var uDescription = Console.ReadLine()!;
//             System.Console.Write("Enter duration weeks: ");
//             var uDurationWeeks = Convert.ToInt32(Console.ReadLine());
//             var uCourse = new Course()
//             {
//                 CourseId = uCourseId,
//                 Title = uTitle,
//                 Description = uDescription,
//                 DurationWeeks = uDurationWeeks
//             };
//             await courseService.UpdateCourseAsync(uCourse);
//             break;
//         case "10":
//             System.Console.Write("Enter id: ");
//             var dCourseId = Convert.ToInt32(Console.ReadLine());
//             await courseService.DeleteCourseAsync(dCourseId);
//             break;

//         case "11":
//             await groupService.GetAllGroupsAsync();
//             break;
//         case "12":
//             System.Console.Write("Enter id: ");
//             var groupId = Convert.ToInt32(Console.ReadLine());
//             await groupService.GetGroupAsync(groupId);
//             break;
//         case "13":
//             System.Console.Write("Enter group name: ");
//             var groupName = Console.ReadLine()!;
//             System.Console.Write("Enter course id: ");
//             var gCourseId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter mentor id: ");
//             var gMentorId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter start date: ");
//             var startDate = Convert.ToDateTime(Console.ReadLine());
//             System.Console.Write("Enter end date: ");
//             var endDate = Convert.ToDateTime(Console.ReadLine());
//             var group = new Groups()
//             {
//                 GroupName = groupName,
//                 CourseId = gCourseId,
//                 MentorId = gMentorId,
//                 StartDate = DateOnly.FromDateTime(startDate),
//                 EndDate = DateOnly.FromDateTime(endDate)
//             };
//             await groupService.AddGroupAsync(group);
//             break;
//         case "14":
//             System.Console.Write("Enter id: ");
//             var uGroupId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter group name: ");
//             var uGroupName = Console.ReadLine()!;
//             System.Console.Write("Enter course id: ");
//             var uGCourseId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter mentor id: ");
//             var uGMentorId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter start date: ");
//             var uStartDate = Convert.ToDateTime(Console.ReadLine());
//             System.Console.Write("Enter end date: ");
//             var uEndDate = Convert.ToDateTime(Console.ReadLine());
//             var uGroup = new Groups()
//             {
//                 GroupId = uGroupId,
//                 GroupName = uGroupName,
//                 CourseId = uGCourseId,
//                 MentorId = uGMentorId,
//                 StartDate = DateOnly.FromDateTime(uStartDate),
//                 EndDate = DateOnly.FromDateTime(uEndDate)
//             };
//             await groupService.UpdateGroupAsync(uGroup);
//             break;
//         case "15":
//             System.Console.Write("Enter id: ");
//             var dGroupId = Convert.ToInt32(Console.ReadLine());
//             await groupService.DeleteGroupAsync(dGroupId);
//             break;

//         case "16":
//             await mentorService.GetAllMentorsAsync();
//             break;
//         case "17":
//             System.Console.Write("Enter id: ");
//             var mentorId = Convert.ToInt32(Console.ReadLine());
//             await mentorService.GetMentorAsync(mentorId);
//             break;
//         case "18":
//             System.Console.Write("Enter fullname: ");
//             var mFullname = Console.ReadLine()!;
//             System.Console.Write("Enter email: ");
//             var mEmail = Console.ReadLine()!;
//             System.Console.Write("Enter phone: ");
//             var mPhone = Console.ReadLine()!;
//             System.Console.Write("Enter specialization: ");
//             var specialization = Console.ReadLine()!;
//             var mentor = new Mentors()
//             {
//                 FullName = mFullname,
//                 Email = mEmail,
//                 Phone = mPhone,
//                 Specialization = specialization
//             };
//             await mentorService.AddMentorAsync(mentor);
//             break;
//         case "19":
//             System.Console.Write("Enter id: ");
//             var uMentorId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter fullname: ");
//             var uMFullname = Console.ReadLine()!;
//             System.Console.Write("Enter email: ");
//             var uMEmail = Console.ReadLine()!;
//             System.Console.Write("Enter phone: ");
//             var uMPhone = Console.ReadLine()!;
//             System.Console.Write("Enter specialization: ");
//             var uSpecialization = Console.ReadLine()!;
//             var uMentor = new Mentors()
//             {
//                 MentorId = uMentorId,
//                 FullName = uMFullname,
//                 Email = uMEmail,
//                 Phone = uMPhone,
//                 Specialization = uSpecialization
//             };
//             await mentorService.UpdateMentorAsync(uMentor);
//             break;
//         case "20":
//             System.Console.Write("Enter id: ");
//             var dMentorId = Convert.ToInt32(Console.ReadLine());
//             await mentorService.DeleteMentorAsync(dMentorId);
//             break;

//         case "21":
//             await studentGroupService.GetAllStudentGroupsAsync();
//             break;
//         case "22":
//             System.Console.Write("Enter id: ");
//             var studentGroupId = Convert.ToInt32(Console.ReadLine());
//             await studentGroupService.GetStudentGroupAsync(studentGroupId);
//             break;
//         case "23":
//             System.Console.Write("Enter student id: ");
//             var sgStudentId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter group id: ");
//             var sgGroupId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter status (number): ");
//             var status = Convert.ToInt32(Console.ReadLine());
//             var studentGroup = new StudentGroups()
//             {
//                 StudentId = sgStudentId,
//                 GroupId = sgGroupId,
//                 Status = (StudentGroupStatus)status
//             };
//             await studentGroupService.AddStudentGroupAsync(studentGroup);
//             break;
//         case "24":
//             System.Console.Write("Enter id: ");
//             var uStudentGroupId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter student id: ");
//             var uSgStudentId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter group id: ");
//             var uSgGroupId = Convert.ToInt32(Console.ReadLine());
//             System.Console.Write("Enter status (number): ");
//             var uStatus = Convert.ToInt32(Console.ReadLine());
//             var uStudentGroup = new StudentGroups()
//             {
//                 StudentGroupId = uStudentGroupId,
//                 StudentId = uSgStudentId,
//                 GroupId = uSgGroupId,
//                 Status = (StudentGroupStatus)uStatus
//             };
//             await studentGroupService.UpdateStudentGroupAsync(uStudentGroup);
//             break;
//         case "25":
//             System.Console.Write("Enter id: ");
//             var dStudentGroupId = Convert.ToInt32(Console.ReadLine());
//             await studentGroupService.DeleteStudentGroupAsync(dStudentGroupId);
//             break;

//         case "0":
//             System.Console.WriteLine("Exiting ...");
//             return;
//     }
// }