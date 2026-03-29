
using StockControl.Communication.Request.Item;
using StockControl.Domain.Repositories;
using StockControl.Domain.Service;
using Mapster;
using StockControl.Communication.Response.Item;
using StockControl.Service.Validation;
using StockControl.Exception;
using StockControl.Exception.Category;


namespace StockControl.Service.Item
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnityOfWork _unitOfWork;

        public ItemService(
            IItemRepository itemRepository, 
            ICategoryRepository categoryRepository, 
            IUnityOfWork unitOfWork )
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateItemResponse> CreateItemAsync(int userId, CreateItemDto itemDto)
        {
            var categoryExists = await _categoryRepository.GetByIdAsync(itemDto.CategoryId);

            if (categoryExists == null)
            {
                throw new CategoryNotFoundException();
            }

           ValidateCreateItemDto(itemDto);


            var item = itemDto.Adapt<Domain.Entities.Item>();
            item.UserId = userId;

            var result = await _itemRepository.CreateAsync(item);
            await _unitOfWork.Commit();

            var response = result.Adapt<CreateItemResponse>();
            response.Category = categoryExists.Name;
            response.Status = result.Status.ToString();
            return response;
        }

        public async Task<List<ItemListResponse>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllProjectedAsync();
  
            return items;
        }

        public async Task<CreateItemResponse?> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item == null) return null;

            var resp = item.Adapt<CreateItemResponse>();

            resp.Category = item.Category.Name;

            resp.Status = item.Status.ToString();

            return resp;
        }

        public async Task<CreateItemResponse?> GetByNameAsync(string name)
        {
            var item = await _itemRepository.GetByNameAsync(name);

            if (item == null) return null;

            var resp = item.Adapt<CreateItemResponse>();

            resp.Category = item.Category.Name;

            resp.Status = item.Status.ToString();

            return resp;
        }

        // TODO: Refactor this method to receive an UpdateItemDto with only the fields that can be updated
        public async Task UpdateItemAsync(CreateItemDto itemDto)
        {
            ValidateCreateItemDto(itemDto);

            var item = itemDto.Adapt<Domain.Entities.Item>();

            _itemRepository.UpdateItemAsync(item);

            await _unitOfWork.Commit();
        }

        private void ValidateCreateItemDto(CreateItemDto itemDto)
        {
            var validator = new ItemValidator();
            var validationResult = validator.Validate(itemDto);
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
            {
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}