import React, { useEffect } from 'react';
import {Dialog, DialogTitle, Paper, Tabs, Tab, FormControl, InputLabel, Select, MenuItem} from "@material-ui/core";
import TabPanel from '../../Shared/TabPanel';
import ExistingProductPanel from './ExistingProductPanel';
import NewProductPanel from './NewProductPanel';
import INewPurchase from './INewPurchase';

interface NewPurchaseDialogProps{
    isOpen:boolean;
    handlePurchaseAdd(purchase:INewPurchase):void;
}

const NewPurchaseDialog:React.FC<NewPurchaseDialogProps>= props =>{
    const [openedTab, setOpenedTab] = React.useState(0);

    return(
        <Dialog open={props.isOpen}>
            <DialogTitle>New purchase</DialogTitle>
            <Tabs value={openedTab}  onChange={(e,nv)=>setOpenedTab(nv)}>
                <Tab label="Existing Product" value={0}/>
                <Tab label="New Product" value={1}/>
            </Tabs>
            <TabPanel index={0} tabValue={openedTab}>
                <ExistingProductPanel handelPurchaseAdd={p=>props.handlePurchaseAdd(p)}/>
            </TabPanel>
            <TabPanel index={1} tabValue={openedTab}>
               <NewProductPanel handelPurchaseAdd={p=>props.handlePurchaseAdd(p)}/>
            </TabPanel>
        </Dialog>
    );
}

export default NewPurchaseDialog;