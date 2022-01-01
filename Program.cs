using System;

namespace ClassVSStruct
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
              1) Assignments
              2) Interface implentation
              3) Struct cannot be null, can be nullable
              4) Parameterless constructor ( Array calls parameterless ) (C# 10 made it possible)
              5) Pass to method to change the value
              6) What if a struct references itself

              Performance - Should be tested
                - Arrays
                  Struct one array container. Easy to find the object and null
                  Object can be distributed

                - Struct memory problem
                  - when too many object to copy/pass parameter
            */

            // Assingments();
            // InterfaceImplementation();

            ChangeValueTest();
        }

        private static void ChangeValueTest()
        {
            var userc = new UserClass();
            userc.Id = 10;
            ChangeValue(userc);

            var users = new UserStruct();
            users.Id = 10;
            ChangeValue(users);

            System.Console.WriteLine($"UserClass.Id: {userc.Id}");
            System.Console.WriteLine($"UserStruct.Id: {users.Id}");
        }

        private static void ParameterlessConstructor()
        {

        }
        private static void StructNull()
        {
            UserClass user = null;

            UserStruct userc = new UserStruct();

        }
        private static void InterfaceImplementation()
        {
            IUser user = new UserClass();
            user.Id = 1;
            IUser user2 = user;
            user2.Id = 10;

            System.Console.WriteLine(user.Id);

            IUser users = new UserStruct();
            user.Id = 1;
            IUser users2 = user;
            user2.Id = 10;

            System.Console.WriteLine(user.Id);
        }
        private static void Assingments()
        {
            var userc = new UserClass();
            userc.Id = 1;

            var u = userc;
            u.Id = 10;

            System.Console.WriteLine(u.Id);
        }

        public static void ChangeValue(UserClass user)
        {
            user.Id = -1;
        }

        public static void ChangeValue(UserStruct user)
        {
            user.Id = -1;
        }

        public class UserClass : IUser
        {
            public int Id { get; set; }

            public string FullName { get; set; }

            public UserClass InlineUserClass { get; set; }
        }

        public struct UserStruct : IUser
        {
            public UserStruct()
            {
                Id = 0;
                FullName = string.Empty;
            }


            public int Id { get; set; }

            public string FullName { get; set; }

            public UserStruct2 InlineUserStruct { get; set; }
        }

        public struct UserStruct2{}

        public interface IUser
        {
            public int Id { get; set; }

            public string FullName { get; set; }
        }

    }
}
