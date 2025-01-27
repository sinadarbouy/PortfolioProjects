﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CatalogItem : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }

        public CatalogItem(int catalogTypeId,
            int catalogBrandId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }
    }
}
