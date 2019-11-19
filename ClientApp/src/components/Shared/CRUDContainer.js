import React, { Component } from 'react';
import apiClient from '../API/apiClient';

export class CRUDContainer extends Component {
    constructor(props,dataFetchUrl) {
        super(props);

        this.state = {
            data: null
        }

        apiClient.get(dataFetchUrl)
        .then(
            data => {
                this.setState({ data: data.data });
            });
    }

    render(content) {
        if (this.state.data === null)
            return (<h1>Loading...</h1>);

        return (
            <div className="container">
                {content}
            </div>
        );
    }
}