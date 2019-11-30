import React, { Component, useState, useEffect } from 'react';
import apiClient from '../../Api/apiClient';
import IStore from './IStore';
import { AxiosRequestConfig } from 'axios';
import { Table, TableHead, TableRow, TableCell, TableBody, Container, Button, Typography } from '@material-ui/core';
import NewStoreDialog from "./NewStoreDialog";
import './StoreContainer.css';

const StoreContainer : React.FC = props=>{
    const [stores,setStores] = useState<IStore[]>([]);
    const [dialogOpen,setDialogOpen] = useState(false);

    useEffect(()=>{
        apiClient.get('/api/stores/getall')
            .then(
                data => {
                    setStores(data.data);
                });
    },[]);

    if (stores.length === 0) {
        return (
            <h1>No stores</h1>
        );
    }

    var keys = Object.keys(stores[0]).filter((value,index,arr)=>value!=='id');
    return (
        <Container>
            <h1>Stores</h1>
            {stores.map(s =>
                    <Typography component="h4" variant="h4" className="store-row">{s.name}</Typography>
                )}
            <Button style={{marginTop:"30px"}} onClick={()=>setDialogOpen(true)}>Add store</Button>
            <NewStoreDialog isOpen={dialogOpen} handleClose={()=>setDialogOpen(false)}/>
        </Container>
    );
}

export default StoreContainer;