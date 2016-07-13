/// Root Component - Renders The App In DOM

import React from 'react';
import { Provider } from 'react-redux';
import AppContainer from './AppContainer.jsx';

const Root = (props) => {
    return (
        <Provider store = {props.store} >
            <AppContainer />
        </Provider>
    );      
};

export default Root;