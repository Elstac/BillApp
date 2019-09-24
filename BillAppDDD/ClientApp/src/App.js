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

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/newBill' component={NewBill} />
            <Route exact path='/stores' component={StoresContainer} />
            <Route exact path='/billList' component={BillList} />
            <Route exact path='/statistics' component={StatiticsContainer} />
            <Route exact path='/billDetails/:id' component={BillDetailedWindow} />
            <Route exact path='/storeDetails/:id' component={StoreDetails} />
        </Layout>
    );
  }
}
