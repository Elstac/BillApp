import React, { useState, useEffect } from 'react';
import { Typography,Container, Button } from "@material-ui/core";
import IProduct from './IProduct';
import ProductService from '../../Api/Services/ProductService';

const ProductContainer: React.FC =props=>{
    const [products,setProducts] = useState<IProduct[]>([]);
    const [dialogOpen,setDialogOpen] = useState(false);

    useEffect(()=>{
        ProductService.getProducts().then(data=>setProducts(data)).catch(error=>alert(error));
    },[]);

    if (products.length === 0) {
        return (
            <h1>No products</h1>
        );
    }

    return(
        <Container>
            <h1>Products</h1>
            {products.map(s =>
                <div>
                    <Typography component="h4" variant="h4">{s.name}</Typography>
                    <Typography component="h5" variant="body1">Barcode: {s.barcode}</Typography>
                    <Typography component="h5" variant="body1">Actual price: {s.price}</Typography>
                </div>
                )}
        </Container>
    );
}

export default ProductContainer;