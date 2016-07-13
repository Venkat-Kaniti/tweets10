/// Application Bootstrapper.

import React from 'react';
import { render } from 'react-dom';
import Root from './components/Root.jsx';
import configureStore from './configureStore';

const store = configureStore();

export const bootStrapApp = () => {
    render(<Root store = { store } />, document.getElementById('root'));
};