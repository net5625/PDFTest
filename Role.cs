namespace TestPDF
{
    public enum Role
    {
        /// <summary>
        /// Admin can everything.
        /// </summary>
        Administrator,
        /// <summary>
        /// Director can Create, Update(with column Realization) and Delete in Newses. 
        /// Also can create and delete users.
        /// </summary>
        Dyrektor,
        /// <summary>
        /// Employee can Create, Update(without column Realization) and Delete(only own) in Newses.
        /// </summary>
        Pracownik,
        /// <summary>
        /// Volunteer can Create, Update and Delete in Newses but only own records.
        /// </summary>
        Wolontariusz
    }
}