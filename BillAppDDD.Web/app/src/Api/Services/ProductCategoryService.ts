import IProductCategory from "../../Components/ProductCategories/IProductCategory";
import IAddCategoryRequest from "../../Interfaces/IAddCategoryRequest";

import apiClient from '../apiClient';

export interface IProductCategoryService{
    getCategories():Promise<IProductCategory[]>;
    addCategory(request:IAddCategoryRequest):Promise<boolean>;
}

const ProductCategoryService: IProductCategoryService={
    getCategories: ()=>{
        return new Promise<IProductCategory[]>((resolve,reject)=>{
            apiClient.get('api/products/categories/getall')
            .then(resp=>resolve(resp.data))
            .catch(error => reject(error));
        });
    },
    addCategory: (request)=>{

        return new Promise<boolean>((resolve,reject)=>{
            apiClient
                .post('api/products/categories/add',{name:request.name})
                .then(resp=> resolve(true))
                .catch(error=> reject(error));
        });
    }
}

export default ProductCategoryService;