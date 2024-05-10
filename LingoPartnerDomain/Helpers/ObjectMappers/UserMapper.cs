

using LingoPartnerDomain.classes;
using LingoPartnerDomain.enums;
using LingoPartnerInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LingoPartnerDomain.Helpers.ObjectMappers
{
  internal static class UserMapper
  {
    public static UserDTO ToDTO(this User user)
    {
      UserDTO dto = new UserDTO
      {
        FirstName = user.FirstName,
        MiddleName = user.MiddleName,
        LastName = user.LastName,
        DateOfBirth = user.DateOfBirth,
        Email = user.Email.Address,
        Password = user.Password,
        Username = user.Username,
        Role = user.Role.ToString()
      };
      return dto;
    }
    public static User ToDomain(this UserDTO dto)
    {
      UserRole role = Enum.Parse<UserRole>(dto.Role);
      if (dto.Id == null)
      {
        throw new ArgumentNullException(nameof(dto.Id), "Id cannot be null when mapping to a User domain object.");
      }
      int id = dto.Id ?? 0; // use 0 as the default value
      User user = new User(id, dto.FirstName, dto.MiddleName, dto.LastName, dto.DateOfBirth, new System.Net.Mail.MailAddress(dto.Email), dto.Password, dto.Username, role);
      return user;
    }
  }
}