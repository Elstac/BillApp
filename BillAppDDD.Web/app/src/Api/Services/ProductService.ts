import IProductCategory from "../../Components/ProductCategories/IProductCategory";
import IAddCategoryRequest from "../../Interfaces/IAddCategoryRequest";

import apiClient from '../apiClient';
import IProduct from "../../Components/Products/IProduct";

export interface IProductService{
    getProducts():Promise<IProduct[]>;
}

const ProductService: IProductService={
    getProducts: ()=>{
        return new Promise<IProduct[]>((resolve,reject)=>{
            apiClient.get('api/products/getall')
            .then(resp=>resolve(resp.data))
            .catch(error => reject(error));
        });
    }
}

export default ProductService;