//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Web.Mvc;

namespace Assignment.Models
{    
    public partial class userResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowHtml]
        public string Comments { get; set; }
    }
}
