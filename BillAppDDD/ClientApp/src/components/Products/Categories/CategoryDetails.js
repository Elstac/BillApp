import React, { Component } from 'react';

export class CategoryDetails extends Component {
    render() {
        return (
            <div className="container">
                <h2>{this.props.store.name}</h2>
            </div>
        );
    }
}