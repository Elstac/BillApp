import React, { Component } from 'react';
import apiClient from '../API/apiClient';

export class ProductDetails extends Component {
    constructor(props) {
        super(props);

        this.state = {
            product: null
        };

        apiClient.get('api/products/details/' + this.props.match.params.id)
                .then(
                    data => {
                        this.setState({ product: data });
                    })
                .catch(() => alert('Unable to load product: ' + this.props.match.params.id));

    }

    render() {
        let product = this.state.product;
        if (product === null)
            return (
                <h1>Loading...</h1>
            );

        return (
            <div className={'container jumbotron text-center py-3 mt-5'}>
                <h1>Bill details</h1>
                <div className="row mt-2">
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Name:</h2>
                            <p>{product.name}</p>
                        </div>
                    </div>
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Barcode:</h2>
                            <p>{product.barcode}</p>
                        </div>
                    </div>
                    <div className="col-4">
                        <div>
                            <h2 className="m-0">Price:</h2>
                            <p>{product.price} PLN</p>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}