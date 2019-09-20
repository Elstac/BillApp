import React, { Component } from 'react';
import { Spendings } from './Spendings/Spendings';

export class StatiticsContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            bills: null
        }

        fetch('/api/bill')
            .then(response => response.json())
            .then(data => {
                this.setState({ bills: data });
            })
    }

    render() {
        return (
            <div className="container">
                <h1>Statistics</h1>

                <div className="row">
                    <div className="col-6">
                        <Spendings
                            bills={this.state.bills}
                        />
                    </div>
                </div>
            </div>
        );
    }
}