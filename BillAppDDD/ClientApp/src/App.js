import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { NewBill } from './components/Bills/NewBill';
import { BillList } from './components/Bills/BillList';
import { BillDetailedWindow } from './components/Bills/DetailedBillWindow';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/newBill' component={NewBill} />
            <Route exact path='/billList' component={BillList} />
            <Route exact path='/billDetails/:id' component={BillDetailedWindow} />
        </Layout>
    );
  }
}
