using Application.DTOs;

namespace UI.WinForms
{
    public static class CurrentUserSession
    {
        public static UserDto CurrentUser { get; private set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public static void SignIn(UserDto user)
        {
            CurrentUser = user;
        }

        public static void SignOut()
        {
            CurrentUser = null;
        }
    }
}
