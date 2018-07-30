using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities;

namespace TaskTracker.UnitTests.Mock
{
    public static class MockData
    {
        private static Dictionary<Type, object> data;

        static MockData()
        {
            Initialize();
        }

        private static void Initialize()
        {
            data = new Dictionary<Type, object>
            {
                {
                    typeof(Location), new List<Location>
                    {

                    }

                }
            };

        }

        public static List<T> Get<T>()
            => data[typeof(T)] as List<T>;
    }
}
