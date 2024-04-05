using Assignment3.Utility;


namespace Assignment3.Tests
{
    //summary comments at the top of ILinkedListADT.cs
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {

            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.IsTrue(users.Count() == deserializedUsers.Count());

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }

        //The linked list is empty
        [Test]
        public void TestIsEmpty()
        {

            ILinkedListADT users = new SLL();


            int count = users.Count();


            Assert.That(count, Is.EqualTo(0), "Linked list is not empty.");
        }

        //An item is inserted at index
        [Test]
        public void TestAddAtIndex()
        {

            User userToAdd = users.GetValue(0);


            users.Add(userToAdd, 1);


            Assert.That(users.GetValue(1), Is.EqualTo(userToAdd));
        }


        //An item is appended
        [Test]
        public void TestAppendItem()
        {
            User userToAppend = users.GetValue(0);

            users.AddLast(userToAppend);

            Assert.AreEqual(userToAppend, users.GetValue(users.Count() - 1));
        }


        //An item is prepended
        [Test]
        public void TestPrependItem()
        {
            User userToPrepend = users.GetValue(0);

            users.AddFirst(userToPrepend);

            Assert.AreEqual(userToPrepend, users.GetValue(0));
        }


        //An item is replaced
        [Test]
        public void TestReplaceItem()
        {
            User userToReplace = users.GetValue(0);

            users.Replace(userToReplace, 1);

            Assert.AreEqual(userToReplace, users.GetValue(0));
        }


        //An item is deleted from the beginning of the list
        [Test]
        public void TestRemoveFirstItem()
        {
            User firstUserBeforeRemove = users.GetValue(0);

            users.RemoveFirst();

            User firstUserAfterRemove = users.GetValue(0);
            Assert.AreNotEqual(firstUserBeforeRemove, firstUserAfterRemove);
        }

        //An item is deleted from the end of the list
        [Test]
        public void TestRemoveLastItem()
        {
            User lastUserBeforeRemove = users.GetValue(users.Count() - 1);

            users.RemoveLast();

            User lastUserAfterRemove = users.GetValue(users.Count() - 1);
            Assert.AreNotEqual(lastUserBeforeRemove, lastUserAfterRemove);
        }


        //an item is deleted from the middle of the list
        [Test]
        public void TestRemoveExistingItem()
        {
            User userToRemove = users.GetValue(1);
            int indexToRemove = users.IndexOf(userToRemove);
            users.Remove(indexToRemove);

            int indexAfterRemove = users.IndexOf(userToRemove);
            Assert.AreEqual(-1, indexAfterRemove);
        }

        //an existing item is found and retrieved
        [Test]
        public void TestFindExistingItem()
        {
            User expectedUser = users.GetValue(0);
            users.AddLast(expectedUser);

            int index = users.IndexOf(expectedUser);
            User actualUser = users.GetValue(index);

            Assert.AreEqual(expectedUser, actualUser);
        }


        //Additional functionality
        //Join two or more linked lists together to create a single linked list
        [Test]
        public void TestJoinLists()
        {
            ILinkedListADT secondList = new SLL();
            secondList.AddLast(new User(5, "John Doe", "jdoe@gmail.com", "password123"));
            secondList.AddLast(new User(6, "Jane Doe", "jane.doe@outlook.com", "password456"));

            int usersCountBeforeJoin = users.Count();
            int secondListCount = secondList.Count();

            users.JoinLists(secondList);

            Assert.AreEqual(usersCountBeforeJoin + secondListCount, users.Count());


            User lastUser = users.GetValue(users.Count() - 1);
            Assert.AreEqual("Jane Doe", lastUser.Name);
        }
    }
}