
using StockControl.Communication.Request.Item;
using StockControl.Domain.Repositories;
using StockControl.Domain.Service;
using Mapster;
using StockControl.Communication.Response.Item;
using StockControl.Service.Validation;
using StockControl.Exception;
using StockControl.Exception.Category;
using StockControl.Exception.Item;
using StockControl.Domain.Enum;


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
            IUnityOfWork unitOfWork)
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

        public async Task<ItemListResponse> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item == null) throw new ItemNotFoundException();
        
            var resp = item.Adapt<ItemListResponse>();

            resp.Category = item.Category.Name;
            resp.CreatedBy = item.User.Name;
            resp.Status = item.Status.ToString();

            return resp;
        }

        public async Task<ItemListResponse> GetByNameAsync(string name)
        {
            var item = await _itemRepository.GetByNameAsync(name);

            if (item == null) throw new ItemNotFoundException();
        

            var resp = item.Adapt<ItemListResponse>();

            resp.Category = item.Category.Name;
            resp.CreatedBy = item.User.Name;
            resp.Status = item.Status.ToString();

            return resp;
        }

        public async Task<CreateItemResponse> UpdateItem(int id, UpdateItemDto itemDto)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            var categoryExists = await _categoryRepository.GetByIdAsync(itemDto.CategoryId);

            if (categoryExists == null)
            {
                throw new CategoryNotFoundException();
            }

            item.CategoryId = categoryExists.Id!;

            var tempItem = MapUpdateDtoToItem(item, itemDto);

            ValidateUpdateItemDto(itemDto);

            _itemRepository.UpdateItem(tempItem);
            await _unitOfWork.Commit();

            var resp = tempItem.Adapt<CreateItemResponse>();

            resp.Category = tempItem.Category.Name;

            resp.Status = tempItem.Status.ToString();

            return resp;
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

        private void ValidateUpdateItemDto(UpdateItemDto itemDto)
        {
            var validator = new UpdateItemValidator();
            var validationResult = validator.Validate(itemDto);
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
            {
                throw new ErrorOnValidationException(errors);
            }
        }

        private Domain.Entities.Item MapUpdateDtoToItem(Domain.Entities.Item item, UpdateItemDto itemDto)
        {

            if (itemDto.Name != null) item.Name = itemDto.Name;
            if (itemDto.SKU != null) item.SKU = itemDto.SKU;
            if (itemDto.Quantity.HasValue) item.Quantity = itemDto.Quantity.Value;
            if (itemDto.Price.HasValue) item.Price = itemDto.Price.Value;
            if (itemDto.SalePrice.HasValue) item.SalePrice = itemDto.SalePrice.Value;
            if (itemDto.Supplier != null) item.Supplier = itemDto.Supplier;
            if (itemDto.Status.HasValue) item.Status = (ItemStatus)itemDto.Status.Value;
            if (itemDto.Description != null) item.Description = itemDto.Description;

            return item;
        }
    }
}