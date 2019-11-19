import React, { Component } from 'react';
import Spendings from './Spendings/Spendings';
import { StoreSpendingChart } from './Spendings/StoreSpendingChart';
import { TimeSpan } from '../Shared/TimeSpan';
import apiClient from '../API/apiClient';

export class StatiticsContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            bills: null,
            storeSpendings: null,
            span: {from:null,to:null}
        }

        apiClient.get('/api/bill/getall')
        .then(data => {
            this.setState({ bills: data });
        });

        apiClient.get('/api/Stores/Spendings/GetAll')
        .then(data => {
            this.setState({ storeSpendings: data });
        });
    }

    render() {
        return (
            <div className="container">
                <h1>Statistics</h1>
                <div className="row">
                    <div className="col-12 mb-2">
                        <TimeSpan
                            handleSpanChange={(span)=>this.setState({span})}
                        />
                    </div>
                    <div className="col-6">
                        <Spendings
                            bills={this.state.bills}
                            span={this.state.span}
                        />
                    </div>
                    <div className="col-6">
                        <StoreSpendingChart
                            stores={this.state.storeSpendings}
                            span={this.state.span}
                        />
                    </div>
                </div>
            </div>
        );
    }
}