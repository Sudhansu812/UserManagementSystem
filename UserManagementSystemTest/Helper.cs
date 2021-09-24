using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystemApi.Models.Dto;

namespace UserManagementSystemTest
{
    class Helper
    {
        public static bool CheckObject(UserReadDto user1, UserReadDto user2)
        {
            Console.WriteLine(user1.UserId + " | " + user2.UserId);
            Console.WriteLine(user1.UserFirstName + " | " + user2.UserFirstName);
            Console.WriteLine(user1.UserLastName + " | " + user2.UserLastName);
            Console.WriteLine(user1.UserContactNumber + " | " + user2.UserContactNumber);
            Console.WriteLine(user1.UserAddress + " | " + user2.UserAddress);

            if (user1.UserId == user2.UserId && user1.UserFirstName == user2.UserFirstName && user1.UserLastName == user2.UserLastName &&
                user1.UserContactNumber == user2.UserContactNumber && user1.UserAddress == user2.UserAddress)
            {
                Console.WriteLine("True");
                return true;
            }
            Console.WriteLine("False");
            return false;
        }

        public static bool CheckList(List<UserReadDto> user1, List<UserReadDto> user2)
        {
            if (user1.Count != user2.Count)
            {
                return false;
            }
            for (int i = 0; i < user1.Count; i++)
            {
                if (user1[i].UserId == user2[i].UserId && user1[i].UserFirstName == user2[i].UserFirstName && user1[i].UserLastName == user2[i].UserLastName &&
                user1[i].UserContactNumber == user2[i].UserContactNumber && user1[i].UserAddress == user2[i].UserAddress)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
