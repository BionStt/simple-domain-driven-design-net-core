using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalDDD.Domain.Aggregations.Users
{
    [Table("User")]
    public class User : BaseValidation
    {
        public User(){}

        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public override List<Error> Validate() =>
            ValidationConcern()
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
                .SelfAssertArgumentLength(Email, 200, MessageService.Message(MessageSystem.InvalidEmail))
         .Push();
    }
}
