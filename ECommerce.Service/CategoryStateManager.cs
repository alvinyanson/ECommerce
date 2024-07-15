using ECommerce.Service.DTO;

namespace ECommerce.Service.Services;

public class CategoryStateManager
{
    protected HashSet<int> _selectedCategories = [];

    public IEnumerable<CategoryReadDto> CategoryReadDtos { get; protected set; } = default!;

    protected CategoryStateManager() { }

    public void Toggle(int categoryId)
    {
        if (!_selectedCategories.Add(categoryId))
        {
            _selectedCategories.Remove(categoryId);
        }
    }

    public bool HasCategory(int categoryId)
    {
        return _selectedCategories.Contains(categoryId);
    }

    public IEnumerable<CategoryReadDto> GetCategories()
    {
        return CategoryReadDtos;
    }

    public bool Any()
    {
        return _selectedCategories.Count != 0;
    }

    public void Clear()
    {
        CategoryReadDtos = [];
        _selectedCategories.Clear();
    }


    public IEnumerable<ProductCategoryDto> ToProductCategoryDtos(int productId)
    {
        return _selectedCategories.Select(categoryId => new ProductCategoryDto
        {
            ProductId = productId,
            CategoryId = categoryId
        });
    }
}
