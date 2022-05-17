using ContactApp.Controllers;
using ContactApp.Repositories;
using Moq;
using Xunit;

namespace xUnitTest.CoreTest
{
    public class UnitTest
    {
        public Mock<IContactRepository> contactMock = new Mock<IContactRepository>();
        public Mock<IReportRepository> reportMock = new Mock<IReportRepository>();
        public ApiController apiController;
        public UnitTest() => apiController = new ApiController(contactMock.Object, reportMock.Object);
        
        #region Contact
        [Fact]
        public async void GetContactsAsyncTest()
        {
            var result = await apiController.GetContactsAsync();
            Assert.Equal(contactMock.Object.GetContactsAsync().Result, result);
        }
        [Fact]
        public async void GetContactAsyncTest()
        {
            var result = await apiController.GetContactAsync(1);
            Assert.Equal(contactMock.Object.GetContactAsync(1).Result, result);
        }
        [Fact]
        public async void CreateContactAsync()
        {
            var result = await apiController.CreateContact(new Contact.Infrastructure.Contact());
            Assert.Equal(contactMock.Object.CreateContactAsync(new Contact.Infrastructure.Contact()).Result, result);
        }
        [Fact]
        public void DeleteContactAsync()
        {
            var result = apiController.DeleteContactAsync(1).IsCompletedSuccessfully;
            Assert.True(result);
        }
        #endregion

        #region ContactDetail
        [Fact]
        public async void InsertContactDetailAsync()
        {
            var result = await apiController.InsertContactDetailAsync(new Contact.Infrastructure.ContactDetail());
            Assert.Equal(contactMock.Object.InsertContactDetailAsync(new Contact.Infrastructure.ContactDetail()).Result, result);
        }

        [Fact]
        public async void RemoveContactDetailAsync()
        {
            var result = apiController.RemoveContactDetailAsync(1).IsCompletedSuccessfully;
            Assert.True(result);
        }
        #endregion

        #region Report
        [Fact]
        public async void CreateReportAsync()
        {
            var result = await apiController.CreateReportAsync();
            Assert.Equal(reportMock.Object.CreateReportAsync().Result, result);
        }

        [Fact]
        public async void GetReportAsync()
        {
            var result = await apiController.GetReportAsync(1);
            Assert.Equal(reportMock.Object.GetReportAsync(1).Result, result);
        }

        [Fact]
        public async void GetReportsAsync()
        {
            var result = await apiController.GetReportsAsync();
            Assert.Equal(reportMock.Object.GetReportsAsync().Result, result);
        }

        #endregion
    }
}
