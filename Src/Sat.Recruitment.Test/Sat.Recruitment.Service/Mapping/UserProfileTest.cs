using Xunit;
using AutoMapper;
using Sat.Recruitment.Service.Dto;
using Sat.Recruitment.Domain.Entity;
using Sat.Recruitment.Service.Mapping;

namespace Sat.Recruitment.Test.Sat.Recruitment.Service.Mapping
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserProfileTest
    {
        [Fact]
        public void ValidateMappingConfigurationTest()
        {
            var config = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            var mapper = config.CreateMapper();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void AutoMapperIsValid()
        {
            var userDto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            var mapper = config.CreateMapper();
            var entity = mapper.Map<User>(userDto);

            Assert.NotNull(entity);
        }

        [Fact]
        public void AutoMapperUserTypeIsNotValid()
        {
            var userDto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Invalid",
                Money = 124
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
            var mapper = config.CreateMapper();
            
            Assert.Throws<AutoMapperMappingException>(() => mapper.Map<User>(userDto));
        }
    }
}
