using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class GuestResponse
    {
        #region "Get response from guest"
        /// <summary>
        /// Class to get response from the guest user and validate the response
        /// </summary>
        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Mobile number")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Mobile number contains only numbers")]
        [MaxLength(10, ErrorMessage = "Mobile number must contain only 10 digits")]
        [MinLength(10, ErrorMessage = "Please enter complete mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }
        #endregion
    }
}