using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Entities;
using TaskTracker.Entities.Base;

namespace TaskTracker.UnitTests.Mock
{
    public class MockData
    {
        private Dictionary<Type, object> _data;

        public MockData()
        {
            Initialize();
        }

        #region Initialize static data

        private void Initialize()
        {
            _data = new Dictionary<Type, object>
            {
                {
                    typeof(Location), new List<Location>
                    {
                        new Location
                        {
                            Id = 1,
                            Country = "Ukraine",
                            City = "Kyiv"
                        }
                    }
                },
                {
                    typeof(UserContacts), new List<UserContacts>
                    {
                        new UserContacts
                        {
                            Id = 1,
                            Location = new Location
                            {
                                Id = 1,
                                Country = "Ukraine",
                                City = "Kyiv"
                            },
                            Mail = "helloworld@mail.com",
                            PhoneNumber = "38045678912"
                        },
                        new UserContacts
                        {
                            Id = 2,
                            Location = new Location
                            {
                                Id = 1,
                                Country = "Ukraine",
                                City = "Kyiv"
                            },
                            Mail = "helloworld1@mail.com",
                            PhoneNumber = "000000000000"
                        },
                        new UserContacts
                        {
                            Id = 3,
                            Location = new Location
                            {
                                Id = 1,
                                Country = "Ukraine",
                                City = "Kyiv"
                            },
                            Mail = "helloworld2@mail.com",
                            PhoneNumber = "12345678901"
                        }
                    }
                },
                {
                    typeof(WorkTaskUser), new List<WorkTaskUser>
                    {
                        new WorkTaskUser
                        {
                            Id = 1,
                            UserContacts = new UserContacts
                            {
                                Id = 1,
                                Location = new Location
                                {
                                    Id = 1,
                                    Country = "Ukraine",
                                    City = "Kyiv"
                                },
                                Mail = "helloworld@mail.com",
                                PhoneNumber = "38045678912"
                            },
                            Name = "Bob",
                            Role = 1,
                            WorkTasks = new List<WorkTask>()
                            
                        },
                        new WorkTaskUser
                        {
                            Id = 2,
                            UserContacts = new UserContacts
                            {
                                Id = 2,
                                Location = new Location
                                {
                                    Id = 1,
                                    Country = "Ukraine",
                                    City = "Kyiv"
                                },
                                Mail = "helloworl2@mail.com",
                                PhoneNumber = "00000000000"
                            },
                            Name = "Jhon",
                            Role = 2,
                            WorkTasks = new List<WorkTask>()
                        },
                    }

                },
                {
                    typeof(WorkTask), new List<WorkTask>()
                    {
                        new WorkTask
                        {
                            Id = 1,
                            Name = "QwertyTask",
                            Manager = new WorkTaskUser
                            {
                                Id = 2,
                                UserContacts = new UserContacts
                                {
                                    Id = 2,
                                    Location = new Location
                                    {
                                        Id = 1,
                                        Country = "Ukraine",
                                        City = "Kyiv"
                                    },
                                    Mail = "helloworl2@mail.com",
                                    PhoneNumber = "00000000000"
                                },
                                Name = "Jhon",
                                Role = 2,
                            },
                            DateInfo = new WorkTaskDateInfo
                            {
                                Id = 1,
                                CreationDate = DateTime.Now,
                                Deadline = DateTime.MaxValue
                            },
                            Progress = new WorkTaskProgress
                            {
                                Id = 1,
                                WorkTaskState = 1,
                                ExecutedPercent = 0
                            },

                            WorkTaskUsers = new List<WorkTaskUser>(),
                            WorkTaskPoints = new List<WorkTaskPoint>()
                        },
                        new WorkTask
                        {
                            Id = 2,
                            Name = "QwertyTas2",
                            Manager = new WorkTaskUser
                            {
                                Id = 2,
                                UserContacts = new UserContacts
                                {
                                    Id = 2,
                                    Location = new Location
                                    {
                                        Id = 1,
                                        Country = "Ukraine",
                                        City = "Kyiv"
                                    },
                                    Mail = "helloworl2@mail.com",
                                    PhoneNumber = "00000000000"
                                },
                                Name = "Jhon",
                                Role = 2,
                            },
                            DateInfo = new WorkTaskDateInfo
                            {
                                Id = 2,
                                CreationDate = DateTime.Now,
                                Deadline = DateTime.MaxValue
                            },
                            Progress = new WorkTaskProgress
                            {
                                Id = 1,
                                WorkTaskState = 1,
                                ExecutedPercent = 0
                            },
                            WorkTaskUsers = new List<WorkTaskUser>(),
                            WorkTaskPoints = new List<WorkTaskPoint>()

                        }
                    }
                },
                {
                    typeof(WorkTaskPoint), new List<WorkTaskPoint>()
                    {
                        
                    }
                }
            };

        }
        #endregion

        public List<T> Get<T>()
            => _data[typeof(T)] as List<T>;

        public T Find<T>(int id) where T : BaseIntIdEntity
            => (_data[typeof(T)] as List<T>).Find(x => x.Id == id);
    }
}
