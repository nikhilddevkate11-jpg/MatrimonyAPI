using AutoMapper;
using Matrimony.API.Common;
using Matrimony.API.Models.Entities;
using Matrimony.API.Services.Implementations;
using Matrimony.Models.DTOs;
using Matrimony.Repositories.Interfaces;
using Matrimony.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Matrimony.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher, 
            IJwtTokenService jwtTokenService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new ApiResponse<object>(
                    false,
                    "Email already exists."
                );
            }

            //var user = new User
            //{
            //    FirstName = dto.FirstName,
            //    LastName = dto.LastName,
            //    Email = dto.Email,
            //    Mobile = dto.Mobile
            //};

            var user = _mapper.Map<User>(dto);

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new ApiResponse<object>(
                true,
                "User registered successfully."
            );
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
            {
                return new ApiResponse<LoginResponseDto>(
                    false,
                    "Invalid email or password."
                );
            }

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return new ApiResponse<LoginResponseDto>(
                    false,
                    "Invalid email or password."
                );
            }

            var token = _jwtTokenService.GenerateToken(user);

            var response = new LoginResponseDto
            {
                Token = token,
                Expires = DateTime.UtcNow.AddMinutes(60),
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return new ApiResponse<LoginResponseDto>(
                true,
                "Login successful.",
                response
            );
        }
    }
}
