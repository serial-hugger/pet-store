using System.Data;
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
        
        _productLogic = new ProductLogic(_productRepoMock.Object,_orderRepoMock.Object);
    }
    [TestMethod]
    public void GetProductById_CallsRepo()
    {
        // Arrange
        _productRepoMock.Setup(x => x.GetProductByIdAsync(10))
            .ReturnsAsync(new Product { ProductId = 10, Name = "test product" });
        // Act
        _productLogic.GetProductByIdAsync(10).Wait();
        // Assert
        _productRepoMock.Verify(x => x.GetProductByIdAsync(10), Times.Once);
    }
    [TestMethod]
    public void GetOrderById_CallsRepo()
    {
        // Arrange
        _orderRepoMock.Setup(x => x.GetOrderByIdAsync(10))
            .ReturnsAsync(new Order { OrderId = 10, OrderDate = new DateTime(2023,4,19) });
        // Act
        _productLogic.GetOrderByIdAsync(10).Wait();
        // Assert
        _orderRepoMock.Verify(x => x.GetOrderByIdAsync(10), Times.Once);
    }
    [TestMethod]
    public void GetAllProducts_CallsRepo()
    {
        // Arrange
        _productRepoMock.Setup(x => x.GetAllProductsAsync())
            .ReturnsAsync([new Product { ProductId = 10, Name = "test product" }]);
        // Act
        _productLogic.GetAllProductsAsync().Wait();
        // Assert
        _productRepoMock.Verify(x => x.GetAllProductsAsync(), Times.Once);
    }
    [TestMethod]
    public void GetAllOrders_CallsRepo()
    {
        // Arrange
        _orderRepoMock.Setup(x => x.GetAllOrdersAsync())
            .ReturnsAsync([new Order { OrderId = 1, OrderDate = new DateTime(2023,4,19) }]);
        // Act
        _productLogic.GetAllOrdersAsync().Wait();
        // Assert
        _orderRepoMock.Verify(x => x.GetAllOrdersAsync(), Times.Once);
    }
}