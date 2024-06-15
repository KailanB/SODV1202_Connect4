


namespace SODV1202_Connect4.Classes
{
    class User
    {
        public string UserName { get; set; }
        private bool IsAI { get; set; } = false;

        /// <summary>
        /// This class is the user information.
        /// </summary>
        /// <param name="userName">First name and last name of player.</param>
        public User(string userName)
        {
            UserName = userName;
        }
        public void ChangeUserIAType()
        {
            IsAI = !IsAI;
        }
        public bool IsAIUser()
        {
            return IsAI;
        }
    }
}
