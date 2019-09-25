import React, { Component } from 'react';

export class CRUDContainer extends Component {
    constructor(props,dataFetchUrl) {
        super(props);

        this.state = {
            data: null
        }

        fetch(dataFetchUrl)
            .then(response => response.json())
            .then(data => {
                this.setState({ data });
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