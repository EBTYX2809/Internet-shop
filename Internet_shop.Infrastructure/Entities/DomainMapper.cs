using Internet_shop.Domain.Models;
using Internet_shop.Domain.Models.Categorization;
using Internet_shop.Infrastructure.Entities.CategoryEntities;
using Internet_shop.Infrastructure.Entities.ProductEntities;
using Internet_shop.Infrastructure.Entities.UserEntities;

namespace Internet_shop.Infrastructure.Entities;

internal static class DomainMapper
{
    // User mappers
    public static UserEntity UserToEntity(User user)
    {
        return new UserEntity
        {
            Id = user.Id,
            Email = user.Email,
            Phone = user.Phone,
            AddressCountry = user.Address.Country,
            AddressCity = user.Address.City,
            AddressStreet = user.Address.Street,
            WishList = user.WishList.Select(ProductToEntity).ToList(),
            OrdersHistory = user.OrdersHistory.Select(OrderToEntity).ToList(),
            ShoppingCart = user.ShoppingCart.Products.Select(p => new ShoppingCartItemEntity { ProductId = p.Id, UserId = user.Id }).ToList()
        };
    }

    public static User UserToModel(UserEntity userEntity)
    {
        string emailOrPhone = userEntity.Email ?? userEntity.Phone;

        var user = new User(userEntity.Id, emailOrPhone);

        // lazy initialization
        try
        {
            user.SetEmail(userEntity.Email);
            user.SetPhone(userEntity.Phone);
            user.SetAddress(new UserAddress(userEntity.AddressCountry, userEntity.AddressCity, userEntity.AddressStreet));
            foreach (var productEntity in userEntity.WishList)
            {
                user.AddToWishList(ProductToModel(productEntity));
            }
            foreach (var orderEntity in userEntity.OrdersHistory)
            {
                user.AddOrder(OrderToModel(orderEntity));
            }
            foreach (var cartItemEntity in userEntity.ShoppingCart)
            {               
                user.ShoppingCart.AddProduct(ProductToModel(cartItemEntity.Product));
            }
        }
        catch(Exception ex) { }

        return user;
    }

    // Product mappers
    public static ProductEntity ProductToEntity(Product product)
    {
        return new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = new CategoryEntity { Id = product.Category.Id, Name = product.Category.Name }, // SubCategories missed
            SubCategory = new SubCategoryEntity { Id = product.SubCategory.Id, Name = product.SubCategory.Name, CategoryId = product.Category.Id }, // Specifications missed
            // specs
            Reviews = product.Reviews.Select(r => new ProductReviewEntity
            {
                ProductId = r.ProductId,
                UserId = r.UserId,
                Score = r.Score,
                Review = r.Review
            }).ToList(),
            Rating = (float)product.Rating
        };
    }

    public static Product ProductToModel(ProductEntity productEntity)
    {
        var product = new Product(
            productEntity.Id,
            productEntity.Name,
            productEntity.Description,
            productEntity.Price,
            new CategoryInfo(productEntity.Category.Id, productEntity.Category.Name),
            new CategoryInfo(productEntity.SubCategory.Id, productEntity.SubCategory.Name),
            productEntity.SpecificationList.ToDictionary(s => s.Specification.Name, s => s.SpecificationValue.Value)
        );

        foreach (var reviewEntity in productEntity.Reviews)
        {
            var review = new ProductReview(reviewEntity.UserId, reviewEntity.ProductId, reviewEntity.Score, reviewEntity.Review);
            product.AddReview(review);
        }

        return product;
    }

    // Category mappers
    public static CategoryEntity CategoryToEntity(Category category)
    {
        return new CategoryEntity
        {
            Id = category.CategoryInfo.Id,
            Name = category.CategoryInfo.Name,
            SubCategories = category.SubCategories?.Select(SubCategoryToEntity).ToList() ?? new List<SubCategoryEntity>()
        };
    }

    public static Category CategoryToModel(CategoryEntity categoryEntity)
    {
        return new Category(
            new CategoryInfo(categoryEntity.Id, categoryEntity.Name),
            categoryEntity.SubCategories?.Select(SubCategoryToModel).ToList()
        );
    }

    public static SubCategoryEntity SubCategoryToEntity(SubCategory subCategory)
    {
        return new SubCategoryEntity
        {
            Id = subCategory.CategoryInfo.Id,
            Name = subCategory.CategoryInfo.Name,
            Specifications = subCategory.Specifications.Select(spec => new SpecificationEntity
            {
                Name = spec.Key,
                SpecificationValues = spec.Value.Select(v => new SpecificationValueEntity { Value = v }).ToList()
            }).ToList()
        };
    }

    public static SubCategory SubCategoryToModel(SubCategoryEntity subCategoryEntity)
    {
        return new SubCategory(
            new CategoryInfo(subCategoryEntity.Id, subCategoryEntity.Name),
            subCategoryEntity.CategoryId,
            subCategoryEntity.Specifications.ToDictionary(
                spec => spec.Name,
                spec => spec.SpecificationValues.Select(v => v.Value).ToArray()
            )
        );
    }

    // Order mappers
    public static OrderEntity OrderToEntity(Order order)
    {
        return new OrderEntity
        {
            Id = order.Id,
            UserId = order.UserId,
            CreatedDate = order.CreatedDate,
            DeliveredDate = order.DeliveredDate,
            Products = order.Products.Select(p => new OrderItemEntity { ProductId = p.Id, OrderId = order.Id }).ToList(), // Id missing here
            SummaryPrice = order.SummaryPrice
        };
    }

    public static Order OrderToModel(OrderEntity orderEntity)
    {
        return new Order(
            orderEntity.Id,
            orderEntity.UserId,
            orderEntity.CreatedDate,            
            orderEntity.Products.Select(oi => ProductToModel(oi.Product)).ToList()
        );
    }    
}
