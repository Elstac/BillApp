import React, { Component } from 'react';
import { ProductCategoryTile } from './ProductCategoryTile';
import { NewCategoryPopUp } from './NewCategoryPopUp';
import apiClient from '../../API/apiClient';

export class ProductCategoryContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            categories: null,
            newCategory: false
        };

        apiClient.get('/api/Products/Categories/GetAll')
            .then(
                data => {
                    this.setState({ categories: data.data });
                });
    }

    handleNewCategoryCreation(category) {
        apiClient.post('/api/products/categories/add', {Name: category.name})
            .catch((error) => alert('Error during operation. ' + error))
            .finally(() => {
                var categories = this.state.categories;
                categories.push(category);
                this.setState({ categories });
            });
    }

    render() {
        if (this.state.categories === null)
            return (
                <h2>Loading...</h2>
            );

        return (
            <div className="container">
                <div className="row">
                    {this.state.categories.map((v, i, a) =>
                        <div className="col-12 border-bottom mt-2">
                            <ProductCategoryTile
                                category={v}
                            />
                        </div>
                    )}
                </div>
                <div className="container text-center">
                    <button type="button" className="btn btn-success text-center w-50" onClick={() => this.setState({ newCategory: true })}>Add category</button>
                </div>
                <NewCategoryPopUp
                    handleCancel={() => this.setState({ newCategory: false })}
                    handleConfirm={this.handleNewCategoryCreation.bind(this)}
                    hidden={!this.state.newCategory}
                />
            </div>
            
        );
    }
}