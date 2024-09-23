namespace IUniversity.Common.Constants
{
    public static class ApiConstants
    {
        //public const string ApiUrl = "https://learningplatformapi.azurewebsites.net";
        public const string ApiUrl = "http://b0fc-141-136-90-133.ngrok.io"; //local tunnel

        #region Controllers endpoints

        public const string LoginEndpoint = "api/Auth/login";
        public const string LogoutEndpoint = "api/Auth/logout";
        public const string RefreshEndpoint = "api/Auth/refresh";
        public const string RegisterEndpoint = "api/Auth/register";
        public const string PingEndpoint = "api/Auth/ping";
        public const string AdminsEndpoint = "api/admins";
        public const string StudentsEndpoint = "api/students";
        public const string TeachersEndpoint = "api/teachers";
        public const string TeacherAssignmentEndpoint = "api/teacherAssignments";
        public const string CoursesEndpoint = "api/courses";
        public const string CoursesAssignmentEndpoint = "api/courseassignments";

        #endregion
    }
}