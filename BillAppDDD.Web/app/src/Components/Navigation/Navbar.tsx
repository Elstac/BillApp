import React, { Component } from 'react';
import {AppBar, Toolbar, Typography, Link, Container, createStyles, Button} from '@material-ui/core';
import { Routes } from '../Routing/Routes';
import "./Navbar.css";
import { NavLink } from 'react-router-dom';

const Navbar : React.FC = props=>{
    return(
        <AppBar position="static">
            <Container className="navlinks-container">
                <NavLink to={Routes.home} className="link">BillApp</NavLink>
                <NavLink to={Routes.billList} className="link">BillList</NavLink>
                <NavLink to={Routes.storeList} className="link">StoreList</NavLink>
                <NavLink to={Routes.productList} className="link">Products</NavLink>
                <NavLink to={Routes.categoryList} className="link">ProducCategories</NavLink>
            </Container>
        </AppBar>
    );
}

export default Navbar;