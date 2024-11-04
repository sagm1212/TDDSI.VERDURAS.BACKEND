using TDDSI.VERDURAS.BACKEND.Domain.WeatherForecasts;

namespace TDDSI.VERDURAS.BACKEND.Domain.Tests;
[TestClass]
public class WeatherForecastServiceTests {

    [TestMethod]
    public void WeatherForecastList_Success() {
        //Arrange

        //Act
        var result = WeatherForecastService.WeatherForecastList();

        //Assert
        Assert.IsNotNull( result );
    }
}
