import React, { useState, useEffect } from 'react';
import IProductCategory from './IProductCategory';
import ProductCategoryService from '../../Api/Services/ProductCategoryService';
import NewCategoryDialog from './NewCategoryDialog'

import { Typography,Container, Button } from "@material-ui/core";
const ProductCategoriesContainer: React.FC =props=>{
    const [categories,setCategories] = useState<IProductCategory[]>([]);
    const [dialogOpen,setDialogOpen] = useState(false);

    useEffect(()=>{
        ProductCategoryService.getCategories().then(data=>setCategories(data)).catch(error=>alert(error));
    },[]);

    if (categories.length === 0) {
        return (
            <h1>No categories</h1>
        );
    }

    return(
        <Container>
            <h1>Categiries</h1>
            {categories.map(s =>
                    <Typography component="h4" variant="h4" className="store-row">{s.name}</Typography>
                )}
            <Button style={{marginTop:"30px"}} onClick={()=>setDialogOpen(true)}>Add category</Button>
            <NewCategoryDialog isOpen={dialogOpen} handleClose={()=>setDialogOpen(false)}/>
        </Container>
    );
}

export default ProductCategoriesContainer;