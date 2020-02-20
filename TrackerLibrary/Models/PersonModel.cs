namespace TrackerLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents one person.
    /// </summary>
    public  class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person.
        /// </summary>
        [Display(Name = "Given Name")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the person.
        /// </summary>
        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The primary email address of the person.
        /// </summary>
        [Display(Name = "Email Address")]
        [StringLength(200, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The primary cell phone number of the person.
        /// </summary>
        [Display(Name = "Cellphone Number")]
        [StringLength(20, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string CellphoneNumber { get; set; }

        public string FullName 
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
