import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class StoreTile extends Component {
    render() {
        return (
            <div className="container">
                <h2>{this.props.store.name}</h2>
                <div className="row">
                    <div className="col-6">
                        <Link to={'/storeDetails/' + this.props.store.id}>
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