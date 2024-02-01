using HiredFirst.Domain.DbEntities;
using HiredFirst.Domain.DTO;
using HiredFirst.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.Services.Implementations
{
    public class ProductService : IProductService
    {
        IBaseRepository<Product> _productRepo;
        public ProductService(IBaseRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public List<ProductDTO> GetProductListByUserId(string UserId)
        {
            var dbEntities = _productRepo.GetAll().Where(a => a.UserId == UserId).ToList();
            var result = new List<ProductDTO>();
            MapDbEntitiesToDTO(dbEntities, result);
            return result;

        }
        public void InsertProduct(ProductDTO productDTO)
        {
            var product=new Product();
            product.Id = new Guid();
            MapDTOToEntities(productDTO, product);
            _productRepo.CreateAsync(product);
        }
        public void UpdateProduct(ProductDTO productDTO)
        {
            var product = _productRepo.GetById(productDTO.Id);
            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;
            _productRepo.UpdateAsync(productDTO.Id, product);
        }
        public void DeleteProduct(string productId)
        {
            var product = _productRepo.GetById(productId);
            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            
            _productRepo.DeleteAsync(productId);
        }

        private void MapDbEntitiesToDTO(List<Product> dbEntities, List<ProductDTO> dtos)
        {
            foreach (var data in dbEntities)
            {
                ProductDTO dto = new ProductDTO();
                dto.Name = data.Name;
                dto.Id = data.Id.ToString();
                dto.Price = data.Price;
                dto.Description = data.Description;
                dtos.Add(dto);
            }
        }
        private void MapDTOToEntities(ProductDTO dto, Product dbEntity)
        {
            dbEntity.Name = dto.Name;
            dbEntity.Price = dto.Price;
            dbEntity.Description = dto.Description;
            dbEntity.UserId = dto.UserId;
        }

    }
}
