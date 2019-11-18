import React, { Component } from 'react';
import { StoreTile } from './StoreTile';
import { CRUDContainer } from '../Shared/CRUDContainer';
import { CRUDTile } from '../Shared/CRUDTile';

export class StoresContainer extends CRUDContainer {
    constructor(props) {
        super(props, '/api/stores/getall');
    }

    render() {
        if (this.state.data === null)
            return (
                <div>
                    {super.render(null)}
                </div>
            );

        var content = this.state.data.map((v, i, a) =>
            <div className="col-12 border-bottom mt-2">
                <CRUDTile
                    key={i}
                    data={v}
                    detailsLink={'/storeDetails/'+v.id}
                />
            </div>
        );

        return (
            <div className="container">
                {super.render(content)}
            </div>
        );
    }
}