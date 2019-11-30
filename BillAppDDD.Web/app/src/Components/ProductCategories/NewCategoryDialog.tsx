import React from 'react';
import {Dialog, DialogTitle, FormControl, Input, InputLabel, Button} from '@material-ui/core';
import ProductCategoryService from "../../Api/Services/ProductCategoryService";

interface INewCategoryProps{
    isOpen:boolean;
    handleClose():void;
}

const NewCategoryDialog: React.FC<INewCategoryProps> = props=>{
    const handleSubmit = (event:React.FormEvent)=>{
        event.preventDefault();
        const data = new FormData(event.target as HTMLFormElement);
        
        ProductCategoryService.addCategory({name:data.get('name') as string})
        .then(resp=>props.handleClose())
        .catch(error=>alert(error));
    }

    return(
        <Dialog open={props.isOpen}>
            <DialogTitle>New Category</DialogTitle>
            <form onSubmit={handleSubmit}>
                <FormControl>
                    <InputLabel htmlFor="my-input">Category name</InputLabel>
                    <Input name="name"/>
                </FormControl>
                <Button type="submit">Add category</Button>
            </form>
        </Dialog>
    );
}

export default NewCategoryDialog;