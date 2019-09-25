import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class ProductCategoryTile extends Component {
    render() {
        return (
            <div className="container">
                <h2>{this.props.category.name}</h2>
                <div className="row">
                    <div className="col-6">
                        <Link to={'/categoryDetails/' + this.props.category.id}>
                            Details
                        </Link>
                    </div>
                    <div className="col-6">
                        <button className="btn btn-danger mb-2" type="button">Remove</button>
                    </div>
                </div>
            </div>
        );
    }
}