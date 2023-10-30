
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Ex1
{
    public class User
    {
        //[EmailAddress]
        public string Email{ get; set; }

        public string Password { get; set; }
        [MaxLength(10)]
        public string FirstName { get; set; }
        [MaxLength(10)]
        public string LastName { get; set; }
        public int Id { get; set; }
     
    }
}
