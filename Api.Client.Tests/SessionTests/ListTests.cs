using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nexosis.Api.Client.Model;
using Xunit;

namespace Api.Client.Tests.SessionTests
{
    public class ListTests : NexosisClient_TestsBase
    {
        public ListTests() : 
            base(new
            {
                items = new List<SessionResponse>
                {
                    new SessionResponse { SessionId = Guid.NewGuid(), Type = SessionType.Forecast }
                }
            })
        {
        }

        [Fact]
        public async Task FormatsPropertiesForListSessions()
        {
            var result = await target.Sessions.List("alpha", "zulu", DateTimeOffset.Parse("2017-01-01"), DateTimeOffset.Parse("2017-01-11"));

            Assert.NotNull(result);
            Assert.Equal(handler.Request.RequestUri, new Uri(baseUri, $"sessions?dataSetName=alpha&eventName=zulu&startDate={DateTimeOffset.Parse("2017-01-01"):O}&endDate={DateTimeOffset.Parse("2017-01-11"):O}"));
        }

        [Fact]
        public async Task ExcludesPropertiesWhenNoneGiven()
        {
            var result = await target.Sessions.List();

            Assert.NotNull(result);
            Assert.Equal(handler.Request.RequestUri, new Uri(baseUri, "sessions"));
        }

    }
}
