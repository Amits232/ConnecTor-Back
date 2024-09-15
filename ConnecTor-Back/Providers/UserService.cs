using ConnecTor_Back.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


public class UserService : IUserService
{
    private readonly ConnecTorDbContext _context;

    public UserService(ConnecTorDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .Select(u => new UserDto
            {
                UserID = u.UserID,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
            })
            .ToListAsync();
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        UserDto userDto = null;

        var connection = _context.Database.GetDbConnection();

        try
        {
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "GetUserById";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserId", id));

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                userDto = new UserDto
                {
                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                    UserType = reader.IsDBNull(reader.GetOrdinal("UserType")) ? null : reader.GetString(reader.GetOrdinal("UserType")),
                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
                    Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region")),
                    Profession = reader.IsDBNull(reader.GetOrdinal("Profession")) ? null : reader.GetString(reader.GetOrdinal("Profession")),
                    LicenseCode = reader.IsDBNull(reader.GetOrdinal("LicenseCode")) ? null : reader.GetString(reader.GetOrdinal("LicenseCode")),
                    UserImage = reader.IsDBNull(reader.GetOrdinal("UserImage")) ? null : (byte[])reader["UserImage"],
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                    Telephone = reader.IsDBNull(reader.GetOrdinal("Telephone")) ? null : reader.GetString(reader.GetOrdinal("Telephone"))
                };
            }
        }
        finally
        {
            connection.Close();
        }

        return userDto;
    }



    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);

        if (existingUser == null)
        {
            return null;
        }

        existingUser.UserPassword = user.UserPassword;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.RegionID = user.RegionID;
        existingUser.ProfessionID = user.ProfessionID;
        existingUser.ActiveStatus = user.ActiveStatus;
        existingUser.Email = user.Email;
        existingUser.Telephone = user.Telephone;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }


}

