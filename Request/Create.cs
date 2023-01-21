using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Internal;
using MovieMania.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieMania.Request
{
    public static class Create
    {
        public class Command : IRequest<CommandResult>
        {
            public Command(string code, FormModel form)
            {
                Code = code;
                Form = form;
            }

            public string Code { get; }
            public FormModel Form { get; }
        }

        public class CommandHandler : IRequestHandler<Command, CommandResult>
        {
            private readonly IdentityErrorDescriber _errors;
            private readonly UserManager<ApplicationUser> _userManager;

            public CommandHandler(UserManager<ApplicationUser> userManager, IdentityErrorDescriber errors)
            {
                _errors = errors;
                _userManager = userManager;
            }

            public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Form.Email);

                if (user == null)
                {
                    return CommandResult.Empty;
                }

                return CommandResult.Empty;
            }
        }

        public class FormModel
        {
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public class Query : IRequest<ViewModel>
        {
            public Query(string code, string email = null)
            {
                Code = code;
                Email = email;
            }

            public Query(string code, FormModel form)
            {
                Code = code;
                Form = form;
            }

            public string Code { get; }
            public string Email { get; }
            public FormModel Form { get; }
        }

        public class QueryHandler : IRequestHandler<Query, ViewModel>
        {
            public QueryHandler()
            {
            }

            public Task<ViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new ViewModel
                {
                    Code = request.Code,
                    Form = request.Form ?? CreateDefaultForm()
                });

                FormModel CreateDefaultForm()
                {
                    return new FormModel
                    {
                        Email = request.Email
                    };
                }
            }
        }

        public class ViewModel
        {
            public string Code { get; set; }
            public FormModel Form { get; set; }
        }
    }
}
