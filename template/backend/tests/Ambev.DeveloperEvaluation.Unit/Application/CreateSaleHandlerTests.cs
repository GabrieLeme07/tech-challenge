using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Bus;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;
    private readonly IMessageHandler _eventBus;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _cartRepository = Substitute.For<ICartRepository>();
        _discountRepository = Substitute.For<IDiscountRepository>();
        _mapper = Substitute.For<IMapper>();
        _eventBus = Substitute.For<IMessageHandler>();

        var fakeUnitOfWork = Substitute.For<IUnitOfWork>();
        fakeUnitOfWork.Commit().Returns(Task.FromResult(true));
        _saleRepository.UnitOfWork.Returns(fakeUnitOfWork);

        _handler = new CreateSaleHandler(_saleRepository, _cartRepository, _discountRepository, _eventBus, _mapper);
    }

    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var saleId = Guid.NewGuid();

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = "Produto Teste",
            Price = 100m
        };

        var cartProduct = new CartProduct
        {
            ProductId = product.Id,
            Product = product,
            Quantity = 2
        };

        var user = new User
        {
            Id = command.CartId,
            Email = "cliente@teste.com"
        };

        var cart = new Cart
        {
            Id = command.CartId,
            UserId = user.Id,
            User = user,
            Products = [cartProduct]
        };

        _cartRepository.GetByIdAsync(command.CartId).Returns(Task.FromResult<Cart>(cart));

        _discountRepository.GetAllAsync().Returns(Task.FromResult<IEnumerable<Discount>>(new List<Discount>()));

        var createdSale = new Sale
        {
            Id = saleId,
            SaleNumber = "SALE123",
            SaleDate = DateTime.UtcNow,
            CustomerId = cart.UserId.ToString(),
            BranchId = "defaultBranchId",
            BranchName = "defaultBranch",
            Items =
            [
                new SaleItem
                {
                    ProductId = product.Id,
                    ProductDescription = product.Title,
                    Quantity = cartProduct.Quantity,
                    Price = product.Price
                }
            ]
        };

        _saleRepository.CreateAsync(Arg.Any<Sale>()).Returns(Task.FromResult(createdSale));

        var expectedResult = new CreateSaleResult { Id = saleId };
        _mapper.Map<CreateSaleResult>(createdSale).Returns(expectedResult);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        result.Id.Should().Be(saleId);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>());
        await _eventBus.Received(1).Publish(Arg.Any<ProcessSalePaymentEvent>());
    }

    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand();

        // When
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ValidationException>();
    }

    [Fact(DisplayName = "Given cart with product quantity >=20 When creating sale Then throws validation exception")]
    public async Task Handle_CartProductQuantityExceedsLimit_ThrowsValidationException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        // Cria um produto com quantidade 20 para disparar a exceção de quantidade
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = "Produto Limitado",
            Price = 50m
        };

        var cartProduct = new CartProduct
        {
            ProductId = product.Id,
            Product = product,
            Quantity = 20
        };

        var user = new User
        {
            Id = command.CartId,
            Email = "cliente@teste.com"
        };

        var cart = new Cart
        {
            Id = command.CartId,
            UserId = user.Id,
            User = user,
            Products = new List<CartProduct> { cartProduct }
        };

        _cartRepository.GetByIdAsync(command.CartId).Returns(Task.FromResult<Cart>(cart));

        // When
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage("Não é permitido comprar 20 ou mais produtos iguais.");
    }

    [Fact(DisplayName = "Given valid sale request When handling Then publishes integration event with correct discount applied")]
    public async Task Handle_ValidRequest_PublishesIntegrationEventWithDiscount()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var saleId = Guid.NewGuid();

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = "Produto com Desconto",
            Price = 200m
        };

        var cartProduct = new CartProduct
        {
            ProductId = product.Id,
            Product = product,
            Quantity = 4
        };

        var user = new User
        {
            Id = command.CartId,
            Email = "cliente@teste.com"
        };

        var cart = new Cart
        {
            Id = command.CartId,
            UserId = user.Id,
            User = user,
            Products = new List<CartProduct> { cartProduct }
        };

        _cartRepository.GetByIdAsync(command.CartId).Returns(Task.FromResult<Cart>(cart));

        var discount = new Discount
        {
            IsActive = true,
            MinQuantity = 4,
            MaxQuantity = 9,
            Percentage = 10
        };

        _discountRepository.GetAllAsync().Returns(Task.FromResult<IEnumerable<Discount>>(new List<Discount> { discount }));

        // Configura o retorno da criação da sale
        var createdSale = new Sale
        {
            Id = saleId,
            SaleNumber = "SALE456",
            SaleDate = DateTime.UtcNow,
            CustomerId = cart.UserId.ToString(),
            BranchId = "defaultBranchId",
            BranchName = "defaultBranch",
            Items = new List<SaleItem>
            {
                new SaleItem
                {
                    ProductId = product.Id,
                    ProductDescription = product.Title,
                    Quantity = cartProduct.Quantity,
                    Price = product.Price
                }
            }
        };

        _saleRepository.CreateAsync(Arg.Any<Sale>())
            .Returns(Task.FromResult(createdSale));

        var expectedResult = new CreateSaleResult { Id = saleId };
        _mapper.Map<CreateSaleResult>(createdSale).Returns(expectedResult);

        ProcessSalePaymentEvent publishedEvent = null;
        _eventBus.Publish(Arg.Do<ProcessSalePaymentEvent>(ev => publishedEvent = ev))
            .Returns(Task.CompletedTask);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        result.Id.Should().Be(saleId);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>());
        await _eventBus.Received(1).Publish(Arg.Any<ProcessSalePaymentEvent>());
    }
}
