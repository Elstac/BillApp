import React from 'react';
import {Dialog, DialogTitle, FormControl, Input, InputLabel, Button} from '@material-ui/core';
import StoreService from "../../Api/Services/StoreService";
import { useHistory } from 'react-router';
import IStore from './IStore';
interface INewStoreDialogProps{
    isOpen:boolean;
    handleClose():void;
}

const NewStoreDialog: React.FC<INewStoreDialogProps> = props=>{
    const handleSubmit = (event:React.FormEvent)=>{
        event.preventDefault();
        const data = new FormData(event.target as HTMLFormElement);
        
        StoreService.addStore({name:data.get('name') as string})
        .then(resp=>props.handleClose())
        .catch(error=>alert(error));
    }

    return(
        <Dialog open={props.isOpen}>
            <DialogTitle>New Store</DialogTitle>
            <form onSubmit={handleSubmit}>
                <FormControl>
                    <InputLabel htmlFor="my-input">Store name</InputLabel>
                    <Input name="name"/>
                </FormControl>
                <Button type="submit">Add store</Button>
            </form>
        </Dialog>
    );
}

export default NewStoreDialog;