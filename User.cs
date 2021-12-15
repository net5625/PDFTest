namespace TestPDF
{
    public class User
    {
        /// <summary>
        /// Name of user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Password of user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// First Name of user.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of user.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User role in newsroom.
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// Theme of application (true - dark; false - light(Default)).
        /// </summary>
        public bool Theme { get; set; } = false;
        public bool Off { get; set; } = false;
    }
}