import React from 'react';
import {Route,BrowserRouter as Router} from 'react-router-dom';
import {Routes} from './Routes';
import LandingPage from '../LandingPage/LangingPage';
import BillContainer from '../Bills/BillsContainer';
import NewBill from '../Bills/NewBill/NewBill';
import StoreContainer from '../Stores/StoreContainer';
import ProductCategoriesContainer from '../ProductCategories/ProductCategoryContainer';
import ProductContainer from "../Products/ProductsContainer";

const AppRouter: React.FC = ()=>{
    return(
        <>
            <Route path={Routes.home} exact component={LandingPage}/>
            <Route path={Routes.billList} component={NewBill}/>
            <Route path={Routes.storeList} component={StoreContainer}/>
            <Route path={Routes.productList} component={ProductContainer}/>
            <Route path={Routes.categoryList} component={ProductCategoriesContainer}/>
        </>
    );
}

export default AppRouter;