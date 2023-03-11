namespace NajotEdu.Application.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string? PhotoPath { get; set; }
        public ICollection<GroupViewModel> Groups { get; set; }
    }
}
