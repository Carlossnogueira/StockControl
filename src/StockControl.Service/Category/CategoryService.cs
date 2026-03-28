using Mapster;
using StockControl.Communication.Request.Catogory;
using StockControl.Communication.Response.Category;
using StockControl.Domain.Repositories;
using StockControl.Domain.Service;
using StockControl.Exception;
using StockControl.Exception.Category;
using StockControl.Service.Validation;

namespace StockControl.Service.Category;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnityOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnityOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Category> CreateCategoryAsync(int userId, CreateCategoryDto categoryDto)
    {
        ValidateCreateCategoryDto(categoryDto);
        var existingCategory = await _categoryRepository.GetByNameAsync(categoryDto.Name);

        if (existingCategory != null)
        {
            throw new CategoryAlreadyExistsException();
        }

        var category = categoryDto.Adapt<Domain.Entities.Category>();
        category.UserId = userId;

        var result = await _categoryRepository.CreateAsync(category);
        await _unitOfWork.Commit();

        return result;
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        if (categories.Count == 0)
        {
            return new List<CategoryResponse>();
        }

        var categoryResponse = new List<CategoryResponse>();

        foreach (var category in categories)
        {
            categoryResponse.Add(category.Adapt<CategoryResponse>());
        }

        return categoryResponse;
    }

    private void ValidateCreateCategoryDto(CreateCategoryDto categoryDto)
    {
        var validator = new CategoryValidator();
        var validationResult = validator.Validate(categoryDto);
        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        if (!validationResult.IsValid)
        {
            throw new ErrorOnValidationException(errors);
        }
    }
}


