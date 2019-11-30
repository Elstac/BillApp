import React from 'react';
import AppRouter from '../Routing/AppRouter';
import Navbar from '../Navigation/Navbar';

const Layout: React.FC = props=>{
    return(
        <div>
            <Navbar/>
            {props.children}
        </div>
    );
}

export default Layout;