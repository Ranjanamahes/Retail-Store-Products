﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RetailStore.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class RetailStoreEntities : DbContext
    {
        public RetailStoreEntities()
            : base("name=RetailStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<RetailStore_spr_GetAllProducts_Result> RetailStore_spr_GetAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetailStore_spr_GetAllProducts_Result>("RetailStore_spr_GetAllProducts");
        }
    
        public virtual ObjectResult<Nullable<int>> RetailStore_spUpsert_Product(Nullable<int> productId, Nullable<bool> delete, string sKU, string name, string category)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var deleteParameter = delete.HasValue ?
                new ObjectParameter("delete", delete) :
                new ObjectParameter("delete", typeof(bool));
    
            var sKUParameter = sKU != null ?
                new ObjectParameter("SKU", sKU) :
                new ObjectParameter("SKU", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var categoryParameter = category != null ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("RetailStore_spUpsert_Product", productIdParameter, deleteParameter, sKUParameter, nameParameter, categoryParameter);
        }
    
        public virtual ObjectResult<RetailStore_spr_GetProductByID_Result> RetailStore_spr_GetProductByID(Nullable<int> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetailStore_spr_GetProductByID_Result>("RetailStore_spr_GetProductByID", productIdParameter);
        }
    
        public virtual ObjectResult<RetailStore_spr_GetProductByCategoryName_Result> RetailStore_spr_GetProductByCategoryName(string categoryName)
        {
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetailStore_spr_GetProductByCategoryName_Result>("RetailStore_spr_GetProductByCategoryName", categoryNameParameter);
        }
    }
}
