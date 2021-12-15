using System;
namespace TestPDF
{
    public class News
    {
        /// <summary>
        /// Identyficator of record in table - KEY.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Date of event - Required.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Name of event - Required.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The place where the event takes place - Required.
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// Information of event.
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// Data of contact to organisators of event.
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// Notes of detalis event.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Bool flag mean whether must create a site article.
        /// </summary>
        public bool Enrollment { get; set; } = false;
        /// <summary>
        /// Bool flag mean whether event must be realized.
        /// </summary>
        public bool Realization { get; set; } = false;
        /// <summary>
        /// User who's assigned to create site article.
        /// </summary>
        public User EnrolmentUser { get; set; }
        /// <summary>
        /// User who's assigned to realization from event.
        /// </summary>
        public User RealizationUser { get; set; }
        /// <summary>
        /// User which typed the event to newsroom - Required.
        /// </summary>
        public User Creator { get; set; }
    }
}
