import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { NewBill } from './components/Bills/NewBill';
import { BillList } from './components/Bills/BillList';
import { BillDetailedWindow } from './components/Bills/DetailedBillWindow';
import { StatiticsContainer } from './components/Statistics/StatiticsContainer';
import { StoresContainer } from './components/Stores/StoresContainer';
import { StoreDetails } from './components/Stores/StoreDetails';
import { CategoryDetails } from './components/Products/Categories/CategoryDetails';
import { ProductCategoryContainer } from './components/Products/Categories/ProductCategoryContainer';
import { ProductContainer } from './components/Products/ProductContainer';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/newBill' component={NewBill} />
            <Route exact path='/stores' component={StoresContainer} />
            <Route exact path='/categories' component={ProductCategoryContainer} />
            <Route exact path='/billList' component={BillList} />
            <Route exact path='/products' component={ProductContainer} />
            <Route exact path='/statistics' component={StatiticsContainer} />
            <Route exact path='/billDetails/:id' component={BillDetailedWindow} />
            <Route exact path='/storeDetails/:id' component={StoreDetails} />
            <Route exact path='/categoryDetails/:id' component={CategoryDetails} />
        </Layout>
    );
  }
}
