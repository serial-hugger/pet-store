using Moq;
using pet_store.Data;

namespace pet_store.tests;

[TestClass]
public class ProductLogicTests
{
    private readonly Mock<IProductRepository> _productRepoMock;
    private readonly Mock<IOrderRepository> _orderRepoMock;
    
    private readonly ProductLogic _productLogic;
    public ProductLogicTests()
    {
        _productRepoMock = new Mock<IProductRepository>();
        _orderRepoMock = new Mock<IOrderRepository>();
        
        _productLogic = new ProductLogic(_productRepoMock.Object);
    }
    [TestMethod]
    public void GetProductById_CallsRepo()
    {
        // Arrange
        _productRepoMock.Setup(x => x.GetProductById(10))
            .Returns(new Product { ProductId = 10, Name = "test product" });
        // Act
        _productLogic.GetProductById(10);
        // Assert
        _productRepoMock.Verify(x => x.GetProductById(10), Times.Once);
    }
}