import React, { Component } from 'react';
import { StoreTile } from './StoreTile';

export class StoresContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            stores: null
        }

        fetch('/api/stores/getall')
            .then(response => response.json())
            .then(data => {
                this.setState({ stores: data });
            });
    }

    render() {
        if (this.state.stores === null)
            return (<h1>Loading...</h1>);

        return (
            <div className="container">
                <div className="row">
                    {this.state.stores.map((v, i, a) =>
                        <div className="col-12 border-bottom mt-2">
                            <StoreTile
                                store={v}
                            />
                        </div>
                    )}
                </div>
            </div>
        );
    }
}