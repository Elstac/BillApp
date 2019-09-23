namespace BillAppDDD.Modules.Bills.Application.Products.AddProduct
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public float Price { get; set; }
        public string ProductCategoryId { get; set; }
    }
}
