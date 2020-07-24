using CampiShopAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampiShopAPI.Utilities
{
    public class ProductIdComparer: IEqualityComparer<ProductSpecificationViewModel>
    {
        public bool Equals(ProductSpecificationViewModel x, ProductSpecificationViewModel y)
        {
            if (x.ProductId == y.ProductId)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(ProductSpecificationViewModel obj)
        {
            return obj.ProductId.GetHashCode();
        }
    }
}
