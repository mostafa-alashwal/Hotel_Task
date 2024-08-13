namespace Hotel_Task.Models.Entities
{
    public class AddAgentViewModel
    {
        public class AddAgentsVeiwModel
        {
            public Guid ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Remake { get; set; }
        }
    }
}
