import React from 'react';

interface TabPanelProps{
    index:number;
    tabValue:number;
}

const TabPanel:React.FC<TabPanelProps> = props =>{
    return(
        <div style={props.tabValue === props.index?{}:{display:"none"}}>
            {props.children}
        </div>
    )
}

export default TabPanel;