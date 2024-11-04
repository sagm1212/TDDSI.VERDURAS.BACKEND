using System.ComponentModel.DataAnnotations;
using TDDSI.VERDURAS.BACKEND.Application.Messaging;

namespace TDDSI.VERDURAS.BACKEND.Application.Features.Users.CreateUser;
public record UserCommand(
    [Required] string FirstName
    , string? SecondName
    , [Required] string SurName
    , string? SecondSurName
    ) : ICommand<UserCommandResponse>;
