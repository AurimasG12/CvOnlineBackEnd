
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models

{
    public class SocialNetworkAccounts
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
